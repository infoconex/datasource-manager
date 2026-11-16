# AD-007B — Extensible but safety-first topology

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user numbered Option C approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Scope initial failover and replica behavior without promising uncoordinated multi-writer correctness.

## Alternatives considered

A coordinated standalone/active-passive/primary-replica first; B all topologies including independently writable databases/sharding immediately; C extensible model implementing A first, allowing provider-managed multi-primary only with verified guarantees, deferring independently writable/sharded routing.

## Selected approach

Option C: Extensible topology with safe coordinated cases first, conditional provider-managed multi-primary, and deferred independent-database/sharding.

## Rationale

Explicitly defer independent database routing, partition-aware sharding and unsafe multi-writer assumptions. AD-024 further limits stale/freshness and transaction affinity.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 22:15:38Z Jim stated: “I approve Architecture Decision 7B, Option C: an extensible topology model with safe coordinated topologies implemented first, provider-managed multi-primary support where appropriate, and future extensibility for independent databases and sharding.” **Class:** direct numbered Option C.

**Classification:** Direct user numbered Option C approval.

## Related requirements and acceptance scenarios

EXP-003 SCN-001–005; D-15 (later POC deferral). No reversal.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

EXP-003 SCN-001–005; D-15 (later POC deferral). No reversal.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
