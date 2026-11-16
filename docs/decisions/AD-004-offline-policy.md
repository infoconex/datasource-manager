# AD-004 — Organization-bounded per-profile offline policy

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user Option C selection with immediate assistant attribution to Decision 4.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Balance offline continuity with delayed revocation and customer-owned risk.

## Decision

Option C: Per-profile offline policy within organization-wide restrictions, conservative customer-owned defaults and verifiable authorization expiry.

## Alternatives considered

A configuration cache only, central access for new credential-dependent connections; B protected config/credential cache for offline access with delayed revocation; C policy-controlled per-profile offline authorization constrained by organization rules (**recommended**).

## Rationale

Offline access improves continuity but delays the effect of central revocation. Per-profile settings allow measured exceptions, while organization policy and verifiable expiry prevent a local cache from becoming indefinite authorization.

## Consequences and limitations

- Local profiles cannot loosen organization-level offline restrictions or security requirements.
- A valid cached configuration alone is insufficient to acquire an expired centrally authorized resource.
- Customer-owned endpoints default to online authorization for centrally managed secrets unless an explicit bounded policy exception applies.

## Traceability

**Approval history:** At 21:31:03Z Jim stated: “I approve offline policy Option C: configurable per-profile offline policies, subject to organization-wide restrictions, with conservative defaults on customer-owned systems. Continue architecture discovery.” At 21:31:23Z the assistant acknowledged “Architecture Decision 4 approved.” **Class:** direct user Option C, immediate numbered attribution.

**Requirements and scenarios:** POC-SCN-06/09; EXP-002 offline authorization topic. No reversal.

**Related decisions and refinements:** AD-014/016/018 further constrain emergency access, trusted expiry and normal authorization timing.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
