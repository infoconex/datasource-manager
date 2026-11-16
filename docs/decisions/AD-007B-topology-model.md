# AD-007B — Extensible but safety-first topology

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user numbered Option C approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Scope initial failover and replica behavior without promising uncoordinated multi-writer correctness.

## Decision

Option C: Extensible topology with safe coordinated cases first, conditional provider-managed multi-primary, and deferred independent-database/sharding.

## Alternatives considered

A coordinated standalone/active-passive/primary-replica first; B all topologies including independently writable databases/sharding immediately; C extensible model implementing A first, allowing provider-managed multi-primary only with verified guarantees, deferring independently writable/sharded routing.

## Rationale

Coordinated primary/replica topologies can be supported incrementally, but independent databases, sharding and uncontrolled multi-writer arrangements require stronger semantics. Deferring them avoids a false promise of correctness under failover.

## Consequences and limitations

- Initial topology support is limited to cases whose roles and failover behavior the provider or policy can verify.
- Independent-database routing and sharding are deferred, not implied by the extensible contract.
- AD-024 adds freshness and affinity constraints before a replica can satisfy a caller's request.

## Traceability

**Approval history:** At 22:15:38Z Jim stated: “I approve Architecture Decision 7B, Option C: an extensible topology model with safe coordinated topologies implemented first, provider-managed multi-primary support where appropriate, and future extensibility for independent databases and sharding.” **Class:** direct numbered Option C.

**Requirements and scenarios:** EXP-003 SCN-001–005; D-15 (later POC deferral). No reversal.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
