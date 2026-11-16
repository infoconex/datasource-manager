# AD-001 — Desktop and server application support

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** User-selected alternative A, immediately recorded as Decision 1 approved by the assistant; not a user-specified numbered Option A approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Whether the manager serves interactive desktop applications, server applications, or both.

## Alternatives considered

A both desktop and server (**recommended**); B server only; C desktop only.

## Selected approach

Both desktop and server applications; provider-qualified framework and OS capabilities.

## Rationale

One provider-neutral library can serve both hosting patterns. This does **not** guarantee each provider on every OS or framework; later AD-019/033/034 set a qualified compatibility matrix. Earlier macOS aspirations remain qualification work, not automatic support.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 20:55:52Z Jim stated: “The library should support both desktop and server applications. Continue architecture discovery with the next decision.” At 20:56:02Z the assistant recorded “Decision 1 approved.” **Class:** user-selected plus assistant-recorded, **not** a literal numbered Option A approval.

**Classification:** User-selected alternative A, immediately recorded as Decision 1 approved by the assistant; not a user-specified numbered Option A approval.

## Related requirements and acceptance scenarios

AD-019/033/034; POC-SCN-04, POC-SCN-21 (later topical links, **not original numbered trace**). No identified supersession.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

AD-019/033/034; POC-SCN-04, POC-SCN-21 (later topical links, **not original numbered trace**). No identified supersession.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
