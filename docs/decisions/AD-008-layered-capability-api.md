# AD-008 — Layered capability-based public API

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user numbered Option C approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

One universal operational interface cannot honestly describe databases, file transfer, mail and SMB.

## Alternatives considered

A connection manager only; B universal provider-operations API; C focused core with optional provider-specific operational capabilities.

## Selected approach

Option C: Focused connection-management core and optional provider-specific capabilities.

## Rationale

Keep optional provider operations in separate adapters/extensions. Typed database connections where appropriate, typed FTP/SFTP/SMTP/SMB resources where appropriate; no forced universal `DbConnection`.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 22:17:03Z Jim stated: “I approve Architecture Decision 8, Option C: layered capability-based APIs, with a focused connection-management core and optional provider-specific operational capabilities.” **Class:** direct numbered Option C.

**Classification:** Direct user numbered Option C approval.

## Related requirements and acceptance scenarios

AD-028/029/031; POC-SCN-01–03/11; EXP-004 SCN-001–005/010. No reversal.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

AD-028/029/031; POC-SCN-01–03/11; EXP-004 SCN-001–005/010. No reversal.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
