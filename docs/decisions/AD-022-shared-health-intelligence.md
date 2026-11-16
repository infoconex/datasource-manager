# AD-022 — Local versus shared health

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Avoiding global blocking based on stale or untrusted observations.

## Decision

Local health and breaker decisions by default; optional scoped shared advisory observations; no automatic global blocking from stale/untrusted data; authoritative endpoint restrictions only by configuration policy; local operation continues if monitoring unavailable.

## Alternatives considered

Options A/B unavailable.

## Rationale

A stale or untrusted health observation from another host is insufficient grounds to block an otherwise authorized local acquisition. Shared signals can inform decisions, but enforcement requires the correct local evidence or authoritative configuration policy.

## Consequences and limitations

- Breakers and endpoint health decisions remain local by default; shared observations are scoped advisory inputs.
- Stale remote data cannot create automatic global outages or cross-tenant blocking.
- Monitoring failure does not by itself stop local operations; authoritative configured endpoint restrictions still apply.

## Traceability

**Approval history:** “I approve Architecture Decision 22, Option C: local health and circuit-breaker decisions by default, optional scoped shared health intelligence for aggregation and advisory use, no automatic global blocking from untrusted or stale observations, authoritative endpoint restrictions through configuration policy, and continued operation without shared monitoring.”

**Requirements and scenarios:** EXP-003 SCN-015–016.

**Related decisions and refinements:** Decision 27 defines failure-domain breaker isolation.

**Sources:**
- [Architecture discovery, original AD-022 extraction, lines 248–257](../archive/conversations/architecture-discovery.md#L248-L257)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
