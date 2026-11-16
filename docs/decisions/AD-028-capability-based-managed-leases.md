# AD-028 — Capability-based managed leases

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Whether the manager or consuming application owns native provider resources, and what lifecycle control is realistic.

## Alternatives considered

**A** return provider-native resources after validation; application owns disposal; **B** manager hides native resources and provides all operations, expanding into an ORM/file/messaging framework; **C** managed leases with typed provider resources and appropriate operation scopes.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Policy-controlled acquisition; managed leases; typed resources, operation scopes, explicit disposal, provider-native pooling, lifecycle tracking, honest limitations on controlling native operations.

## Rationale

Balances strong acquisition policy and visibility with provider-native usability (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 28, Option C: capability-based managed leases with policy-controlled acquisition, provider-appropriate typed resources and operation scopes, explicit lease disposal, provider-native pooling, lifecycle tracking, and honest limitations on controlling exposed native operations.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-004 SCN-001–002, SCN-011–015.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 29 specifies how available lease capabilities are described.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-028 extraction, lines 308–317](../archive/conversations/architecture-discovery.md#L308-L317)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
