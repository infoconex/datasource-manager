param(
    [ValidateSet('Portable', 'WindowsLegacy', 'All')]
    [string] $Stage = 'Portable'
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$PSNativeCommandUseErrorActionPreference = $true
$repoRoot = Split-Path -Parent $PSScriptRoot
Set-Location $repoRoot

function Invoke-Checked {
    param([string] $Executable, [string[]] $Arguments)

    Write-Host "Running $Executable $($Arguments -join ' ')"
    & $Executable @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "$Executable exited with $LASTEXITCODE"
    }
}

function Test-NuGetPackage {
    param([string] $PackagePath)

    $archive = [System.IO.Compression.ZipFile]::OpenRead($PackagePath)
    try {
        $names = @($archive.Entries | ForEach-Object { $_.FullName })
        $assemblies = @($names | Where-Object { $_ -like 'lib/netstandard2.0/*.dll' })
        $otherLibraries = @($names | Where-Object {
            $_ -match '^lib/[^/]+\.dll$' -or
            ($_ -match '^lib/[^/]+/[^/]+\.dll$' -and $_ -notmatch '^lib/netstandard2\.0/')
        })
        if ($assemblies.Count -ne 1 -or $otherLibraries.Count -ne 0) {
            throw "Unexpected package framework asset layout: $PackagePath"
        }
        if (@($names | Where-Object { $_ -like '*.nuspec' }).Count -ne 1) {
            throw "Expected one nuspec: $PackagePath"
        }
        $nuspecEntry = @($archive.Entries | Where-Object { $_.FullName -like '*.nuspec' })[0]
        $reader = [System.IO.StreamReader]::new($nuspecEntry.Open())
        try {
            [xml] $manifest = $reader.ReadToEnd()
        }
        finally {
            $reader.Dispose()
        }
        $dependencies = @($manifest.SelectNodes("//*[local-name()='dependency']") |
            ForEach-Object { $_.GetAttribute('id') })
        $forbiddenDependencies = @($dependencies | Where-Object {
            $_ -match '^(?:Polly|Microsoft\.Extensions\.DependencyInjection|Microsoft\.Data\.SqlClient|Npgsql|MySqlConnector|SSH\.NET)'
        })
        if ($forbiddenDependencies.Count -gt 0) {
            throw "Forbidden core dependency in $PackagePath : $($forbiddenDependencies -join ', ')"
        }
        if ($PackagePath -like '*DataSourceManager.Core.*' -and
            $dependencies -notcontains 'Infoconex.DataSourceManager.Abstractions') {
            throw 'Core package must depend on portable Abstractions.'
        }
        if ($PackagePath -like '*DataSourceManager.Abstractions.*' -and
            $dependencies -contains 'Infoconex.DataSourceManager.Core') {
            throw 'Abstractions must not depend on Core.'
        }
        Write-Host "Package dependencies: $($dependencies -join ', ')"
        Write-Host "Validated portable package $PackagePath"
    }
    finally {
        $archive.Dispose()
    }
}

$packageDirectory = Join-Path $repoRoot 'artifacts/packages'
$consumerConfig = Join-Path $repoRoot 'eng/consumer.nuget.config'

if ($Stage -eq 'Portable' -or $Stage -eq 'All') {
    Invoke-Checked 'dotnet' @('--info')
    Invoke-Checked 'dotnet' @('sln', 'DataSourceManager.slnx', 'list')
    $sourceEpoch = (& git log -1 --format=%ct).Trim()
    if ($sourceEpoch -notmatch '^[0-9]+$') {
        throw 'A Git commit timestamp is required for deterministic package creation.'
    }
    Write-Host "Package deterministic timestamp (commit epoch): $sourceEpoch"
    New-Item -ItemType Directory -Force -Path $packageDirectory | Out-Null

    foreach ($project in @(
        'src/DataSourceManager.Abstractions/DataSourceManager.Abstractions.csproj',
        'src/DataSourceManager.Core/DataSourceManager.Core.csproj'
    )) {
        Invoke-Checked 'dotnet' @('restore', $project)
        Invoke-Checked 'dotnet' @('build', $project, '-c', 'Release', '--no-restore')
        Invoke-Checked 'dotnet' @('pack', $project, '-c', 'Release', '--no-restore', '--output', $packageDirectory,
            '-p:IncludeSymbols=true', '-p:SymbolPackageFormat=snupkg', "-p:DeterministicTimestamp=$sourceEpoch")
    }

    $packages = @(Get-ChildItem -LiteralPath $packageDirectory -Filter '*.nupkg' -File)
    if ($packages.Count -ne 2) {
        throw "Expected exactly two local foundation packages, found $($packages.Count)"
    }
    foreach ($package in $packages) {
        Test-NuGetPackage $package.FullName
        $hash = Get-FileHash -Algorithm SHA256 -LiteralPath $package.FullName
        Write-Host "SHA256 $($package.Name): $($hash.Hash)"
    }
    $symbols = @(Get-ChildItem -LiteralPath $packageDirectory -Filter '*.snupkg' -File)
    if ($symbols.Count -ne 2) {
        throw "Expected two portable symbol packages, found $($symbols.Count)"
    }

    $modernConsumer = 'tests/Consumers/Net10Consumer/Net10Consumer.csproj'
    Invoke-Checked 'dotnet' @('restore', $modernConsumer, '--configfile', $consumerConfig)
    Invoke-Checked 'dotnet' @('run', '--project', $modernConsumer, '-c', 'Release', '--no-restore')

    $unitTests = 'tests/DataSourceManager.Core.Tests/DataSourceManager.Core.Tests.csproj'
    Invoke-Checked 'dotnet' @('restore', $unitTests)
    Invoke-Checked 'dotnet' @('test', $unitTests, '-c', 'Release', '--no-restore', '--logger', 'trx')
}

if ($Stage -eq 'WindowsLegacy' -or $Stage -eq 'All') {
    if (-not $IsWindows) {
        throw 'WindowsLegacy verification requires Windows with .NET Framework 4.8.'
    }
    if (-not (Test-Path -LiteralPath $packageDirectory)) {
        throw 'Run Portable package verification first.'
    }

    $legacyProject = 'tests/Consumers/Net48LegacyConsumer/Net48LegacyConsumer.csproj'
    $legacyPackages = 'tests/Consumers/Net48LegacyConsumer/packages.config'
    Invoke-Checked 'nuget' @('restore', $legacyPackages, '-PackagesDirectory', 'packages',
        '-ConfigFile', $consumerConfig, '-NonInteractive')

    $vsWhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio/Installer/vswhere.exe'
    if (-not (Test-Path -LiteralPath $vsWhere)) {
        throw 'Visual Studio MSBuild discovery utility is missing.'
    }
    $msbuild = @(& $vsWhere -latest -products '*' -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe') |
        Select-Object -First 1
    if (-not $msbuild) {
        throw 'A supported Windows MSBuild installation was not found.'
    }
    Invoke-Checked $msbuild @($legacyProject, '/t:Build', '/p:Configuration=Release', '/p:Platform=AnyCPU', '/verbosity:minimal')

    $legacyExecutable = 'tests/Consumers/Net48LegacyConsumer/bin/Release/Net48LegacyConsumer.exe'
    if (-not (Test-Path -LiteralPath $legacyExecutable)) {
        throw 'Expected the legacy .NET Framework 4.8 executable.'
    }
    Invoke-Checked (Join-Path $repoRoot $legacyExecutable) @()
}

Write-Host "Foundation verification stage '$Stage' passed; no POC scenarios were exercised."
