# Engineering foundation

This directory documents the **proposed and then implemented engineering foundation** independently of approved architecture and the 21 unexecuted POC scenarios. It is not another architecture-decision register.

- [Foundation acceptance criteria](foundation-acceptance.md): new `FND-AC-*` checks, never historical requirements.
- [Verification plan and evidence](verification.md): commands, runner matrix and limitations.
- [Compatibility matrix](../compatibility/matrix.md): what an actual test does and does not establish.
- [Security threat model](../security/threat-model.md): trust boundaries and gates, not an implementation claim.
- [Architecture decisions](../decisions/README.md): the 37 authoritative ADR files.
- [Approved POC-001 scenarios](../requirements/POC-001.md): 21 separate acceptance criteria; none is exercised by foundation packaging checks.

The initial production projects are deliberately small: `Abstractions` for portable public contracts and `Core` for inward policy dependencies. The two internal assembly markers exist solely to validate packaging and load behavior. They do **not** establish acquisition, security, configuration or provider functionality and should be removed or replaced during the approved contract implementation increment.

Every change uses one GitHub issue and one PR. Merging, release and publication require separate owner approval.

