# AD-023 — Routing algorithms

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

How much endpoint selection belongs to library-managed routing.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Extensible provider-neutral policies, provider-native first; initial library-managed priority failover, round-robin, weighted round-robin, and locally scoped least-active only where suitable; defer adaptive/sharding.

## Rationale

Addresses common routing needs without advanced balancing systems (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 23, Option C: extensible provider-neutral routing policies, provider-native selection first, and initial library-managed priority failover, round-robin, weighted round-robin, and locally scoped least-active selection only where appropriate. Defer advanced adaptive and sharding strategies.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-001–003.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 24 constrains eligible destinations by consistency and authorization.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-023 extraction, lines 258–267](../archive/conversations/architecture-discovery.md#L258-L267)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
