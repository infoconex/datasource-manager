# AD-006 — Multiple provider connection authentication strategies

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user numbered Option C approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Provider protocols and deployment environments need different authentication mechanisms.

## Alternatives considered

A centrally managed credentials; B individual identity-based connections; C per-profile selection among multiple strategies.

## Selected approach

Option C: Per-profile connection authentication selection, separate from credential-store abstractions.

## Rationale

Selection is constrained by provider, OS/framework capabilities, identity and organizational policy; the listed mechanisms are **not promises of universal support**. Credential *store* and authentication *strategy* are distinct abstractions.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 22:09:57Z Jim stated: “I approve Architecture Decision 6, Option C: multiple authentication strategies per connection profile, including shared credentials, user-specific credentials, integrated authentication, certificates, and passwordless identities where supported. Keep authentication strategies separate from credential stores and enforce security policies. Continue architecture discovery.” **Class:** direct numbered Option C.

**Classification:** Direct user numbered Option C approval.

## Related requirements and acceptance scenarios

AD-011–013; POC-SCN-07/08/12; EXP-003 SCN-008. Later lifecycle decisions refine.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

AD-011–013; POC-SCN-07/08/12; EXP-003 SCN-008. Later lifecycle decisions refine.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
