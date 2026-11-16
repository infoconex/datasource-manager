# AD-024 — Consistency-aware routing

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Preventing a healthy but stale or wrong-role destination from silently satisfying a stronger caller request.

## Alternatives considered

Prior conversation summary describes A as eventual-consistency routing for all reads, B as profile-level primary-first, C as explicit policy-driven consistency; full original option text unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Explicit acquisition intent; conservative primary-capable default; replica eligibility constrained by org/profile; verifiable freshness; session affinity; no silent downgrade.

## Rationale

Availability must not override required consistency (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 24, Option C: policy-driven consistency-aware routing with explicit connection intent, conservative primary-capable defaults, replica eligibility constrained by organization/profile policy, verifiable freshness requirements, session affinity, and no silent consistency downgrade.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-002, SCN-004–005.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 25 requires retries to preserve these constraints.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-024 extraction, lines 268–277](../archive/conversations/architecture-discovery.md#L268-L277)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
