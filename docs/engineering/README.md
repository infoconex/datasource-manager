# Engineering foundation

This directory documents the engineering foundation independently of the approved architecture. The I1 no-provider acceptance test is tracked separately from foundation checks; no result is claimed before candidate verification. It is not another architecture-decision register.

- [Foundation acceptance criteria](foundation-acceptance.md): new `FND-AC-*` checks, never historical requirements.
- [Verification plan and evidence](verification.md): commands, runner matrix and limitations.
- [Compatibility matrix](../compatibility/matrix.md): what an actual test does and does not establish.
- [Security threat model](../security/threat-model.md): trust boundaries and gates, not an implementation claim.
- [Architecture decisions](../decisions/README.md): the 37 authoritative ADR files.
- [Approved POC-001 scenarios](../requirements/POC-001.md): 21 separate acceptance criteria; the new I1 contract checks target only POC-SCN-01, never POC-SCN-04.

The initial production projects remain deliberately small: `Abstractions` for portable public contracts and `Core` for the zero-provider implementation. The foundation's assembly markers were replaced by genuine public contract types for package-load verification. I1 does not implement registration, credential security, authorization, configuration or real providers.

Every change uses one GitHub issue and one PR. Merging, release and publication require separate owner approval.

