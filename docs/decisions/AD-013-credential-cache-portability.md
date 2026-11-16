# AD-013 — Credential cache portability

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Whether credentials can be moved between devices or identities.

## Decision

Default caches bound to approved local security contexts; centrally managed credentials re-provision after enrollment; optional controlled encrypted recovery for locally managed profiles.

## Alternatives considered

Options A/B unavailable.

## Rationale

A portable encrypted cache could become an unintended credential-export mechanism. Binding normal cache use to an approved security context limits copying between users or devices while allowing separately controlled recovery for locally owned profiles.

## Consequences and limitations

- Centrally managed credentials must be re-provisioned following legitimate enrollment, not moved by copying a cache.
- A cache copied to another device or identity should not become usable merely because its files are available.
- Locally managed encrypted recovery is a distinct, policy-controlled exception, not unrestricted portability.

## Traceability

**Approval history:** “I approve Architecture Decision 13, Option C: credential caches bound to approved local security contexts by default, centrally managed credentials re-provisioned after device enrollment, and optional controlled encrypted recovery for locally managed profiles.”

**Requirements and scenarios:** EXP-002-A cache protection/recovery; exact related SCNs unavailable.

**Related decisions and refinements:** Decision 19 adds OS-specific security capability requirements.

**Sources:**
- [Architecture discovery, original AD-013 extraction, lines 158–167](../archive/conversations/architecture-discovery.md#L158-L167)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
