# AD-027 — Circuit-breaker failure domains

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Preventing one tenant/profile/credential fault from disabling healthy endpoints or other callers.

## Alternatives considered

**A** profile-scoped breaker (can disable healthy endpoints in profile); **B** endpoint-scoped breaker (can mix tenant/auth failures); **C** failure-domain-aware isolation and bounded recovery.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Local failure-domain-aware isolation by endpoint/profile/tenant/security context as appropriate; distinguish transient availability from auth/config failures; bounded half-open trials, policy-respecting acquisitions, independent healthy alternatives, bounded state retention.

## Rationale

Precise isolation without cross-tenant health poisoning (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 27, Option C: failure-domain-aware local circuit-breaker isolation, distinguishing endpoint availability from tenant/profile/security-context failures, bounded half-open recovery, policy-respecting trial acquisitions, independent healthy alternatives, and bounded state retention.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-007, SCN-009–010, SCN-016.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Refines Decisions 21, 22, and 25; no supersession.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-027 extraction, lines 298–307](../archive/conversations/architecture-discovery.md#L298-L307)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
