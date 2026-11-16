# Verification plan and evidence

The executable checks are:

| Command (PowerShell 7) | Host | Purpose |
| --- | --- | --- |
| `./eng/check-docs.ps1` | Windows or Linux | Relative Markdown links; 37 ADR files; 21 unique POC scenario IDs |
| `./eng/verify.ps1 -Stage Portable` | Windows and Linux | Restore/build, local NuGet packing, TFM assets, symbols, modern consumer execution, NUnit |
| `./eng/verify.ps1 -Stage WindowsLegacy` | Windows with VS/MSBuild, NuGet CLI and .NET Framework 4.8 | Non-SDK C# 7.3 restore/build/execute against **locally packed** assemblies |
| `./eng/verify.ps1 -Stage All` | Windows | Both portable and legacy stages in sequence |

GitHub Actions runs the same scripts. `global.json` pins .NET 11 SDK feature-band with servicing roll-forward; SDK choice **does not** elevate .NET 11 to official runtime support. Modern consumers target .NET 10. The legacy consumer is deliberately non-SDK and C# 7.3; it cannot be tested on Linux by compiling a `netstandard2.0` library.

NuGet packages are packed with a deterministic timestamp derived from the checked-out commit's Git epoch. Compare Windows/Linux hashes as evidence; differing hashes must be disclosed and investigated before claiming byte-identical reproducibility.

Package-load consumers use the dedicated `eng/consumer.nuget.config` only after local packages have been produced. It maps `Infoconex.DataSourceManager.*` to the local package feed and leaves the root configuration independent of temporary test artifacts.

Dependency review, CodeQL and NuGet's restore audit provide separate signals. GitHub secret scanning and push protection are repository settings, not tests and not asserted active merely because they are recommended. No CI job runs SQL, SFTP, or other external providers.

## Initial evidence ledger

| Check | State before first PR CI run |
| --- | --- |
| Local .NET/PowerShell execution | **Not run** — authoring environment has neither `dotnet` nor `pwsh` |
| GitHub-hosted Linux | Pending first CI run |
| GitHub-hosted Windows, including net48 | Pending first CI run |
| CodeQL and dependency review | Pending first PR run |
| Full POC-001 (21 scenarios) | Not run — separately authorized future work |
| Independent security signoff | Pending, before implementing security behavior |

After the first PR CI run, place its job URLs, SHA, exact test counts, hashes, and any limitations in the PR rather than rewriting history or claiming checks executed earlier. Generated packages are ephemeral verification artifacts only: no NuGet push, release or publication.

