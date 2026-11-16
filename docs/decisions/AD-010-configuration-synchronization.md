# AD-010 — Configuration synchronization

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Keeping local configuration consistent through disconnections and updates.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Version-aware polling as reliable sync; optional push notifications trigger refresh; atomic activation and offline reconciliation.

## Rationale

Polling is the dependable mechanism while push improves timeliness (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 10, Option C: version-aware polling as the reliable synchronization mechanism, with optional push notifications that trigger refresh, atomic configuration activation, and offline reconciliation.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

Version monotonicity, atomic cache activation, reconciliation; EXP-001. Exact SCNs unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 12 requires secret-version refresh; no supersession.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-010 extraction, lines 128–137](../archive/conversations/architecture-discovery.md#L128-L137)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
