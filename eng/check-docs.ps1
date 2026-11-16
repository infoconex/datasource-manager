$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$repoRoot = Split-Path -Parent $PSScriptRoot
Set-Location $repoRoot

$adrs = @(Get-ChildItem -LiteralPath 'docs/decisions' -Filter 'AD-*.md' -File)
if ($adrs.Count -ne 37) {
    throw "Expected 37 ADR files, found $($adrs.Count)"
}
$pocText = Get-Content -LiteralPath 'docs/requirements/POC-001.md' -Raw
$scenarioIds = @([regex]::Matches($pocText, 'POC-SCN-(?:0[1-9]|1[0-9]|2[01])') |
    ForEach-Object { $_.Value } | Sort-Object -Unique)
if ($scenarioIds.Count -ne 21) {
    throw "Expected 21 distinct POC scenarios, found $($scenarioIds.Count)"
}

$files = @(Get-Item -LiteralPath 'README.md') + @(Get-ChildItem -Path @(
    'docs/decisions', 'docs/requirements', 'docs/engineering', 'docs/security', 'docs/compatibility'
) -Filter '*.md' -Recurse -File)

$broken = [System.Collections.Generic.List[string]]::new()
foreach ($file in $files) {
    $source = Get-Content -LiteralPath $file.FullName -Raw
    foreach ($match in [regex]::Matches($source, '\[[^\]]+\]\(([^)]+)\)')) {
        $destination = $match.Groups[1].Value.Trim('<', '>')
        if ($destination -match '^(?:[a-z][a-z0-9+.-]*:|#)' -or $destination -eq '') {
            continue
        }
        $withoutAnchor = ($destination -split '#', 2)[0]
        if (-not $withoutAnchor) {
            continue
        }
        $relative = [uri]::UnescapeDataString($withoutAnchor)
        $candidate = Join-Path $file.DirectoryName $relative
        if (-not (Test-Path -LiteralPath $candidate)) {
            $broken.Add("$($file.FullName): $destination")
        }
    }
}
if ($broken.Count -gt 0) {
    throw "Broken relative Markdown links:`n$($broken -join "`n")"
}

Write-Host "Documentation links valid; $($adrs.Count) ADRs and $($scenarioIds.Count) POC scenario IDs preserved."
