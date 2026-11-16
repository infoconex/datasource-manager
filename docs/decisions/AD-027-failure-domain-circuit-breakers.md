# AD-027 — Circuit-breaker failure domains

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Preventing one tenant/profile/credential fault from disabling healthy endpoints or other callers.

## Decision

Local failure-domain-aware isolation by endpoint/profile/tenant/security context as appropriate; distinguish transient availability from auth/config failures; bounded half-open trials, policy-respecting acquisitions, independent healthy alternatives, bounded state retention.

## Alternatives considered

**A** profile-scoped breaker (can disable healthy endpoints in profile); **B** endpoint-scoped breaker (can mix tenant/auth failures); **C** failure-domain-aware isolation and bounded recovery.

## Rationale

A breaker that aggregates unrelated tenants, profiles or credential failures can suppress healthy access. Isolation by the actual failure domain and careful failure classification avoids treating a policy or authentication error like a transient endpoint outage.

## Consequences and limitations

- Breaker state is scoped by endpoint/profile/tenant/security context as appropriate and retained within bounds.
- Transient outages, authentication failures and configuration denial are classified separately.
- Half-open probes are bounded and remain subject to policy; healthy alternative endpoints should not be disabled by an unrelated failure.

## Traceability

**Approval history:** “I approve Architecture Decision 27, Option C: failure-domain-aware local circuit-breaker isolation, distinguishing endpoint availability from tenant/profile/security-context failures, bounded half-open recovery, policy-respecting trial acquisitions, independent healthy alternatives, and bounded state retention.”

**Requirements and scenarios:** EXP-003 SCN-007, SCN-009–010, SCN-016.

**Related decisions and refinements:** Refines Decisions 21, 22, and 25; no supersession.

**Sources:**
- [Architecture discovery, original AD-027 extraction, lines 298–307](../archive/conversations/architecture-discovery.md#L298-L307)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
