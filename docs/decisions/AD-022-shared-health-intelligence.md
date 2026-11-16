# AD-022 — Local versus shared health

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Avoiding global blocking based on stale or untrusted observations.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Local health and breaker decisions by default; optional scoped shared advisory observations; no automatic global blocking from stale/untrusted data; authoritative endpoint restrictions only by configuration policy; local operation continues if monitoring unavailable.

## Rationale

A distant observation should not become an unreviewed enforcement decision (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 22, Option C: local health and circuit-breaker decisions by default, optional scoped shared health intelligence for aggregation and advisory use, no automatic global blocking from untrusted or stale observations, authoritative endpoint restrictions through configuration policy, and continued operation without shared monitoring.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-015–016.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 27 defines failure-domain breaker isolation.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-022 extraction, lines 248–257](../archive/conversations/architecture-discovery.md#L248-L257)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
