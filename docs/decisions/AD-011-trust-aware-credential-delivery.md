# AD-011 — Trust-aware credential delivery

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Secret distribution across managed versus customer-owned devices.

## Decision

Central secret stores, platform-protected caches, optional device-specific encryption, brokered/delegated customer-owned access; shared centrally managed credentials not sent to customer-owned devices by default.

## Alternatives considered

Options A/B unavailable.

## Rationale

The security of a central vault does not transfer automatically to devices outside an organization's control. Protected caches, device-specific delivery and brokered access let the deployment choose an exposure level appropriate to its trust boundary.

## Consequences and limitations

- Shared centrally managed secrets are not distributed to customer-owned endpoints by default.
- Managed-device caches need platform-appropriate protection; device-specific encryption is optional where it has real security value.
- Customer-owned access may require brokered or delegated credentials, and no mechanism guarantees safety on a compromised host.

## Traceability

**Approval history:** “I approve Architecture Decision 11, Option C: trust-aware credential delivery using central secret stores, platform-protected local caches, optional device-specific encryption, and brokered or delegated access for customer-owned systems. Shared centrally managed credentials must not be distributed to customer-owned devices by default.”

**Requirements and scenarios:** EXP-002-A credential protection; individual EXP-002 SCN mapping unavailable.

**Related decisions and refinements:** Decisions 12–13 handle rotation, binding, and recovery.

**Sources:**
- [Architecture discovery, original AD-011 extraction, lines 138–147](../archive/conversations/architecture-discovery.md#L138-L147)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
