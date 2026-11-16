# AD-009 — Configuration ownership

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Ownership and local editability of centrally managed versus standalone profiles.

## Decision

Explicit configuration ownership: centrally managed profiles with protected read-only caches, standalone locally managed profiles, restricted non-security overrides.

## Alternatives considered

Options A/B not preserved.

## Rationale

Central administrators need control over centrally managed profile security settings, while standalone installations need their own local profiles. Explicit ownership prevents cache edits or convenience overrides from silently changing organizational authorization.

## Consequences and limitations

- Centrally managed profiles activate from protected read-only local copies and cannot be locally rewritten as authoritative policy.
- Standalone profiles remain locally managed under their own documented trust model.
- Only permitted non-security settings may be overridden; ownership and authority must remain visible.
- Profile ownership and credential ownership are separate: central profile security settings cannot be weakened by application-provided credentials, and a local profile cannot bypass access controls on centrally managed credentials. Requester and tenant-to-profile restrictions apply when configured or mandated by policy, as clarified in [AD-005](AD-005-identity-and-authorization.md), while provider authentication remains governed by [AD-006](AD-006-provider-authentication.md).

## Traceability

**Approval history:** “I approve Architecture Decision 9, Option C: explicit configuration ownership supporting centrally managed profiles with protected read-only caches, standalone locally managed profiles, and restricted non-security overrides.”

**Requirements and scenarios:** Configuration authority and limited overrides; EXP-001 planning baseline. Exact EXP-001 SCN identifiers/text unavailable.

**Related decisions and refinements:** Decision 10 provides synchronization and atomic activation; no supersession.

**Sources:**
- [Architecture discovery, original AD-009 extraction, lines 118–127](../archive/conversations/architecture-discovery.md#L118-L127)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
