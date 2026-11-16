# AD-018 — Offline time validation

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Trustworthiness of offline grant expiry when local time can be altered.

## Decision

Central/destination enforcement online; signed grants and validated protected time evidence on trusted managed devices offline; fail closed if time cannot be verified; customer-owned clocks untrusted.

## Alternatives considered

Options A/B unavailable.

## Rationale

An attacker controlling a local clock could make an expired grant appear valid. Offline authorization therefore depends on signed grants and independently defensible time evidence, not on an arbitrary wall-clock reading.

## Consequences and limitations

- Online paths prefer central or destination expiration enforcement.
- Eligible managed devices may validate protected time evidence offline; if trustworthy expiry cannot be established, acquisition fails closed.
- Customer-owned clock values are not accepted as independent proof of unexpired authorization.

## Traceability

**Approval history:** “I approve Architecture Decision 18, Option C: trust-aware offline expiration validation, preferring central or destination enforcement when online, evaluating signed grants and validated protected time evidence on trusted managed devices, failing closed when time cannot be verified, and treating customer-owned local clocks as untrusted.”

**Requirements and scenarios:** EXP-002-B; exact SCN mapping unavailable.

**Related decisions and refinements:** None explicitly superseding; Decision 19 makes support OS-capability dependent.

**Sources:**
- [Architecture discovery, original AD-018 extraction, lines 208–217](../archive/conversations/architecture-discovery.md#L208-L217)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
