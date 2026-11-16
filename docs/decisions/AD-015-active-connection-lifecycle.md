# AD-015 — Active connection lifecycle

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Handling active resources during rotation, revocation, and emergency expiration.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Policy-driven lifecycle: graceful planned rotation, aggressive security revocation, strict emergency expiry, provider-aware pool handling, explicit reporting of termination limitations and uncertain operations.

## Rationale

Planned maintenance and security events require different interruption behavior (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 15, Option C: policy-driven connection lifecycle management, with graceful planned rotation, aggressive security revocation, strict emergency-access expiration, provider-aware pool handling, and explicit reporting of termination limitations and uncertain operations.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-C; EXP-004 SCN-012–015.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 28 clarifies leased native resources cannot guarantee retrospective control over arbitrary in-flight operations.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-015 extraction, lines 178–187](../archive/conversations/architecture-discovery.md#L178-L187)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
