# AD-014 — Normal offline expiry and emergency exception

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Offline authorization after its normal expiry and exceptional continuity needs.

## Decision

Strict normal authorization expiry; separately provisioned, optional, time-bounded, audited emergency access for eligible managed systems; no implicit grace; conservative customer-owned defaults.

## Alternatives considered

Options A/B unavailable.

## Rationale

An implicit offline grace period would extend normal authority without a fresh security decision. Emergency continuity is therefore a separate, pre-provisioned and time-limited authorization path with audit requirements and stricter device eligibility.

## Consequences and limitations

- Expired normal authorization fails; cached configuration does not create a grace period.
- Eligible managed systems may receive explicitly provisioned, audited emergency access with its own expiry and bounds.
- Customer-owned devices retain conservative defaults and cannot gain emergency rights by simply being offline.

## Traceability

**Approval history:** “I approve Architecture Decision 14, Option C: strict normal offline authorization expiry with a separate, optional, explicitly provisioned, time-bounded and audited emergency-access capability for eligible managed systems. No implicit grace period; conservative customer-owned defaults.”

**Requirements and scenarios:** EXP-002-B and EXP-002-D; exact SCN mappings unavailable.

**Related decisions and refinements:** Decisions 16–18 define activation, audit durability, and trusted expiration validation.

**Sources:**
- [Architecture discovery, original AD-014 extraction, lines 168–177](../archive/conversations/architecture-discovery.md#L168-L177)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
