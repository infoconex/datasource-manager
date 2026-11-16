# AD-023 — Routing algorithms

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

How much endpoint selection belongs to library-managed routing.

## Decision

Extensible provider-neutral policies, provider-native first; initial library-managed priority failover, round-robin, weighted round-robin, and locally scoped least-active only where suitable; defer adaptive/sharding.

## Alternatives considered

Options A/B unavailable.

## Rationale

Provider-native selection is preferable when it understands the topology. A small configurable set of library algorithms covers ordinary failover and balancing without claiming to solve consistency, sharding or adaptive optimization.

## Consequences and limitations

- Initial library-managed options are priority failover, round-robin, weighted round-robin and suitable locally scoped least-active selection.
- A policy or provider may disallow an algorithm if its semantics cannot be respected.
- Adaptive balancing and sharding remain deferred, and AD-024 governs replica consistency regardless of routing algorithm.

## Traceability

**Approval history:** “I approve Architecture Decision 23, Option C: extensible provider-neutral routing policies, provider-native selection first, and initial library-managed priority failover, round-robin, weighted round-robin, and locally scoped least-active selection only where appropriate. Defer advanced adaptive and sharding strategies.”

**Requirements and scenarios:** EXP-003 SCN-001–003.

**Related decisions and refinements:** Decision 24 constrains eligible destinations by consistency and authorization.

**Sources:**
- [Architecture discovery, original AD-023 extraction, lines 258–267](../archive/conversations/architecture-discovery.md#L258-L267)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
