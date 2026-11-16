# AD-011 — Trust-aware credential delivery

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Secret distribution across managed versus customer-owned devices.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Central secret stores, platform-protected caches, optional device-specific encryption, brokered/delegated customer-owned access; shared centrally managed credentials not sent to customer-owned devices by default.

## Rationale

Reduces secret exposure across trust boundaries (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 11, Option C: trust-aware credential delivery using central secret stores, platform-protected local caches, optional device-specific encryption, and brokered or delegated access for customer-owned systems. Shared centrally managed credentials must not be distributed to customer-owned devices by default.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-A credential protection; individual EXP-002 SCN mapping unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decisions 12–13 handle rotation, binding, and recovery.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-011 extraction, lines 138–147](../archive/conversations/architecture-discovery.md#L138-L147)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
