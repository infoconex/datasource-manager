# AD-005 — Requester identity and organization/profile authorization

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user numbered Option C approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Distinguish user, application and combined identity requirements for acquisition.

## Decision

Option C: Requesting user identity, application/workload identity, or both when required by organization and profile authorization.

## Alternatives considered

A user identity (OIDC/OAuth2); B application/workload identity; C policy-driven user identity, application identity, or **both**.

## Rationale

The requesting principal varies by application: some operations are authorized for a person, others for a workload, and some require both. That authorization must be evaluated against organization and profile policy independently of the credentials used at the destination.

## Consequences and limitations

- The acquisition contract needs to represent user identity, workload identity, or both without silently substituting one for another.
- Authorization failure remains distinct from SQL, SFTP or other provider authentication failure.
- Provider credentials cannot serve as proof that the requester is entitled to use a profile.

## Clarification — conditional authorization and distinct ownership (November 15, 2026)

**Prospective owner direction:** Support both local and centrally managed profiles; restrict centrally managed credentials to approved applications; enforce tenant-to-profile restrictions only when configured or required by policy. This clarifies approved Option C without rewriting its original approval evidence.

- For application-owned profiles using application-controlled provider authentication, no separate Data Source Manager requester authorization is required **unless an applicable policy requires it**. The destination provider still authenticates the connection and enforces its permissions.
- Centrally managed credentials may be accessed or delivered **only to applications/workloads approved by the credential authority**, with user identity also required when policy specifies. A locally managed profile cannot bypass this control.
- Centrally managed profiles retain authoritative security and override rules even when provider credentials are application-controlled. Tenant-to-profile restrictions are enforced when configured or mandated, not universally.
- Missing or unverifiable **required** identity, entitlement or policy fails closed. Registration, profile IDs and provider credentials never override an applicable manager authorization rule.

Profile and credential ownership are independent (AD-002, AD-009), as is provider authentication (AD-006). An in-process library cannot prevent an application from directly using credentials it already possesses; central credential access therefore needs protection at the delivery boundary.

This clarification neither mandates a central identity service for standalone applications nor changes POC scenario acceptance criteria, I2 authorization, or the independent security-review gate.

## Traceability

**Approval history:** At 22:08:24Z Jim stated: “I approve Architecture Decision 5, Option C: policy-driven authentication supporting user identity, application identity, and both when required. Keep authentication provider-neutral and enforce organization and profile authorization.” **Class:** direct numbered Option C.

**Requirements and scenarios:** EXP-004 capability authorization; POC-SCN-07. AD-006/009/011/029 specialize, not supersede.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
