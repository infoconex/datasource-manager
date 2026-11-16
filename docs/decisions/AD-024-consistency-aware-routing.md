# AD-024 — Consistency-aware routing

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Preventing a healthy but stale or wrong-role destination from silently satisfying a stronger caller request.

## Decision

Explicit acquisition intent; conservative primary-capable default; replica eligibility constrained by org/profile; verifiable freshness; session affinity; no silent downgrade.

## Alternatives considered

Prior conversation summary describes A as eventual-consistency routing for all reads, B as profile-level primary-first, C as explicit policy-driven consistency; full original option text unavailable.

## Rationale

Endpoint health alone does not establish that a replica is fresh enough or has the correct role for a requested operation. Explicit intent and verifiable eligibility prevent availability-driven failover from weakening consistency silently.

## Consequences and limitations

- The default acquisition intent is conservative and primary-capable unless policy and caller requirements justify a replica.
- Replica use depends on permitted roles, verified freshness and any required session affinity.
- If required consistency cannot be established, routing must refuse or report the limitation rather than silently downgrade the request.

## Traceability

**Approval history:** “I approve Architecture Decision 24, Option C: policy-driven consistency-aware routing with explicit connection intent, conservative primary-capable defaults, replica eligibility constrained by organization/profile policy, verifiable freshness requirements, session affinity, and no silent consistency downgrade.”

**Requirements and scenarios:** EXP-003 SCN-002, SCN-004–005.

**Related decisions and refinements:** Decision 25 requires retries to preserve these constraints.

**Sources:**
- [Architecture discovery, original AD-024 extraction, lines 268–277](../archive/conversations/architecture-discovery.md#L268-L277)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
