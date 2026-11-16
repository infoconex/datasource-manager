# Engineering foundation acceptance checks

These are **new November 2026 engineering checks**, not recovered requirement IDs, and do not count as POC-001 scenario passes. Actual results appear in [verification](verification.md).

| New ID | Required result | Primary evidence |
| --- | --- | --- |
| FND-AC-01 | 37 ADRs and all original POC/archive materials are unmodified and navigable | Git change list; `eng/check-docs.ps1` |
| FND-AC-02 | Minimal solution builds with `Abstractions` and `Core`, inward dependency direction | project references; build |
| FND-AC-03 | No provider driver, dynamic loader, Polly or DI package in portable core | project/package graph and NUnit architecture checks |
| FND-AC-04 | Exactly two unpublished local packages contain portable `netstandard2.0` assets | `eng/verify.ps1` package ZIP checks |
| FND-AC-05 | Real non-SDK C# 7.3 `net48` Windows consumer restores, compiles and loads the local packages | Windows job; MSBuild/NuGet tool log |
| FND-AC-06 | Actual `net10.0` consumer loads local packages on Windows and Linux | separate Windows/Linux jobs |
| FND-AC-07 | NUnit discovers and executes pure assembly-boundary tests on both OSs | NUnit TRX output |
| FND-AC-08 | Both operating systems use the repository-controlled verification scripts | workflow definitions and CI logs |
| FND-AC-09 | Docs, analyzers, NuGet vulnerability audit and available GitHub security checks produce explicit outcomes | documentation, build, CodeQL and dependency review jobs |
| FND-AC-10 | Package contents, direct dependencies, symbol artifacts and SHA-256 are recorded; nothing published | package inspection and job logs |
| FND-AC-11 | Threat assumptions and traceability are documented without pretending a security implementation exists | [threat model](../security/threat-model.md) and indexes |
| FND-AC-12 | Issue-specific branch, one PR, exact candidate SHA and owner merge gate | GitHub issue/PR and recorded checks |

Important limits:

- Package load is not managed acquisition and does not satisfy `POC-SCN-01` or `POC-SCN-04`.
- `REQ-01`–`REQ-20` and `D-01`–`D-20` in the approved charter are consolidated **planning aliases**, not recovered original requirement identifiers.
- `EXP-001` retrospective themes, numbered EXP-002/003/004 cases and `POC-SCN-*` are distinct namespaces. No crosswalk is invented by these foundation checks.
- No supported capability is inferred from an assembly TFM, file name or synthetic test.

