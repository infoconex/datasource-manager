# AD-007A — Hybrid provider-native-first routing ownership

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user numbered Option C approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Avoid replacing sound provider-native routing with a generic coordinator that lacks provider semantics.

## Alternatives considered

A provider-native only; B library-managed only; C hybrid/provider-native-first.

## Selected approach

Option C: Provider-native routing first; library-managed routing only when safe and appropriate.

## Rationale

Honor provider-native routing when it satisfies policy; library routing is conditional and cannot invent replica consistency guarantees.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 22:14:50Z Jim stated: “I approve Architecture Decision 7A, Option C: hybrid provider-native-first routing, with provider-neutral routing and resilience policies and library-managed implementations only where appropriate.” **Class:** direct numbered Option C.

**Classification:** Direct user numbered Option C approval.

## Related requirements and acceptance scenarios

AD-023/024; EXP-003 SCN-001–003. No reversal.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

AD-023/024; EXP-003 SCN-001–003. No reversal.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
