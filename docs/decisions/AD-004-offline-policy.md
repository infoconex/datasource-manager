# AD-004 — Organization-bounded per-profile offline policy

**Status:** Approved in the carried-forward architecture baseline  
**Approval class:** Direct user Option C selection with immediate assistant attribution to Decision 4.  
**Historical source limitation:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  
**Implementation state:** Decision only; experiments remain unexecuted.

## Context and problem

Balance offline continuity with delayed revocation and customer-owned risk.

## Alternatives considered

A configuration cache only, central access for new credential-dependent connections; B protected config/credential cache for offline access with delayed revocation; C policy-controlled per-profile offline authorization constrained by organization rules (**recommended**).

## Selected approach

Option C: Per-profile offline policy within organization-wide restrictions, conservative customer-owned defaults and verifiable authorization expiry.

## Rationale

Online-only is the conservative default for centrally managed secrets on customer-owned endpoints, with explicit, bounded policy exceptions. **Cached configuration is never perpetual authorization**; offline grants require strict verifiable expiry and no implicit grace. AD-014/016/018 further constrain time, emergency and expiration guarantees.

## Consequences and limits

Implementation must honor the risk and capability qualifications stated above and in the subsequently approved security, routing, and compatibility decisions. No unexecuted test is counted as verification.

## Approval evidence

At 21:31:03Z Jim stated: “I approve offline policy Option C: configurable per-profile offline policies, subject to organization-wide restrictions, with conservative defaults on customer-owned systems. Continue architecture discovery.” At 21:31:23Z the assistant acknowledged “Architecture Decision 4 approved.” **Class:** direct user Option C, immediate numbered attribution.

**Classification:** Direct user Option C selection with immediate assistant attribution to Decision 4.

## Related requirements and acceptance scenarios

POC-SCN-06/09; EXP-002 offline authorization topic. No reversal.

This is a topical relationship, not proof of a recovered original numbered test mapping. See [POC-001](../requirements/POC-001.md) and [historical experiment traceability](../requirements/experiment-traceability.md).

## Related decisions and supersession

POC-SCN-06/09; EXP-002 offline authorization topic. No reversal.

No later source documents a formal repeal of this decision. The cited decisions refine or limit its application; original user wording is not silently rewritten.

## Evidence sources

- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [Decision register](README.md)
