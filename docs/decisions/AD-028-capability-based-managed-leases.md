# AD-028 — Capability-based managed leases

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Whether the manager or consuming application owns native provider resources, and what lifecycle control is realistic.

## Decision

Policy-controlled acquisition; managed leases; typed resources, operation scopes, explicit disposal, provider-native pooling, lifecycle tracking, honest limitations on controlling native operations.

## Alternatives considered

**A** return provider-native resources after validation; application owns disposal; **B** manager hides native resources and provides all operations, expanding into an ORM/file/messaging framework; **C** managed leases with typed provider resources and appropriate operation scopes.

## Rationale

A lease lets the library perform policy-controlled acquisition and track resource ownership while returning a provider-appropriate typed native object. Native providers remain responsible for physical pooling and may expose operations the manager cannot intercept.

## Consequences and limitations

- Leases have explicit disposal and lifecycle tracking; operation scopes are expressed where supported.
- The library can constrain acquisition and managed operations but cannot promise complete control of arbitrary native operations after handing out a resource.
- Provider-native pooling remains authoritative, and an optional pool coordinator must not be mistaken for a second physical pool.

## Traceability

**Approval history:** “I approve Architecture Decision 28, Option C: capability-based managed leases with policy-controlled acquisition, provider-appropriate typed resources and operation scopes, explicit lease disposal, provider-native pooling, lifecycle tracking, and honest limitations on controlling exposed native operations.”

**Requirements and scenarios:** EXP-004 SCN-001–002, SCN-011–015.

**Related decisions and refinements:** Decision 29 specifies how available lease capabilities are described.

**Sources:**
- [Architecture discovery, original AD-028 extraction, lines 308–317](../archive/conversations/architecture-discovery.md#L308-L317)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
