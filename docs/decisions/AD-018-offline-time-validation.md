# AD-018 — Offline time validation

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Trustworthiness of offline grant expiry when local time can be altered.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Central/destination enforcement online; signed grants and validated protected time evidence on trusted managed devices offline; fail closed if time cannot be verified; customer-owned clocks untrusted.

## Rationale

Prevents clock tampering from extending offline authority (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 18, Option C: trust-aware offline expiration validation, preferring central or destination enforcement when online, evaluating signed grants and validated protected time evidence on trusted managed devices, failing closed when time cannot be verified, and treating customer-owned local clocks as untrusted.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-B; exact SCN mapping unavailable.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

None explicitly superseding; Decision 19 makes support OS-capability dependent.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-018 extraction, lines 208–217](../archive/conversations/architecture-discovery.md#L208-L217)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
