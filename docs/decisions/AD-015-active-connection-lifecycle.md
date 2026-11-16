# AD-015 — Active connection lifecycle

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Handling active resources during rotation, revocation, and emergency expiration.

## Decision

Policy-driven lifecycle: graceful planned rotation, aggressive security revocation, strict emergency expiry, provider-aware pool handling, explicit reporting of termination limitations and uncertain operations.

## Alternatives considered

Options A/B unavailable.

## Rationale

Routine rotation favors orderly draining while suspected compromise may require prompt revocation. The library needs policy-specific lifecycle responses without claiming that every native driver or already-running operation can be forcibly stopped.

## Consequences and limitations

- Planned rotation may drain or transition leases; security revocation may deny new acquisitions and take more aggressive available action.
- Emergency expiry remains strict even if a provider cannot interrupt every in-flight operation.
- Pool invalidation and termination are provider-aware, and uncertain remote outcomes must be reported honestly.

## Traceability

**Approval history:** “I approve Architecture Decision 15, Option C: policy-driven connection lifecycle management, with graceful planned rotation, aggressive security revocation, strict emergency-access expiration, provider-aware pool handling, and explicit reporting of termination limitations and uncertain operations.”

**Requirements and scenarios:** EXP-002-C; EXP-004 SCN-012–015.

**Related decisions and refinements:** Decision 28 clarifies leased native resources cannot guarantee retrospective control over arbitrary in-flight operations.

**Sources:**
- [Architecture discovery, original AD-015 extraction, lines 178–187](../archive/conversations/architecture-discovery.md#L178-L187)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
