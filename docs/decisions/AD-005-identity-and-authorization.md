# AD-005 — Requester identity and organization/profile authorization

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user numbered Option C approval.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Distinguish user, application and combined identity requirements for acquisition.

## Alternatives considered

A user identity (OIDC/OAuth2); B application/workload identity; C policy-driven user identity, application identity, or **both**.

## Selected approach

Option C: Requesting user identity, application/workload identity, or both when required by organization and profile authorization.

## Rationale

Requester authorization at organization and profile levels is separate from credentials used to authenticate to SQL/SFTP/etc. under AD-006. Do not imply a single universal authorization identity.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 22:08:24Z Jim stated: “I approve Architecture Decision 5, Option C: policy-driven authentication supporting user identity, application identity, and both when required. Keep authentication provider-neutral and enforce organization and profile authorization.” **Class:** direct numbered Option C.

**Classification:** Direct user numbered Option C approval.

## Related requirements and acceptance scenarios

EXP-004 capability authorization; POC-SCN-07. AD-006/009/011/029 specialize, not supersede.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

EXP-004 capability authorization; POC-SCN-07. AD-006/009/011/029 specialize, not supersede.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
