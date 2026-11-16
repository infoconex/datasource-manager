# AD-012 — Credential rotation

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Coordinating credential changes without taking ownership of every destination's rotation process.

## Decision

External rotation default; optional provider-specific rotation; core version refresh, cache invalidation, pool transitions, offline expiration, and audit.

## Alternatives considered

Options A/B unavailable.

## Rationale

Existing secret managers often already own rotation and destination updates. The library can integrate their version changes and coordinate caches, leases and native pools without assuming it can rotate every provider credential itself.

## Consequences and limitations

- External secret rotation remains the default ownership model; provider-specific rotation is optional.
- Version changes must drive appropriate refresh, cache invalidation, pool transitions and auditing.
- Active operations and offline clients require explicit lifecycle treatment; the library cannot promise universal instant termination.

## Traceability

**Approval history:** “I approve Architecture Decision 12, Option C: external credential rotation by default, with optional provider-specific rotation capabilities. Core responsibilities include version refresh, cache invalidation, pool transitions, offline expiration, and auditing.”

**Requirements and scenarios:** EXP-002-C rotation/revocation; EXP-004 SCN-013 later exercises lifecycle interactions.

**Related decisions and refinements:** Decision 15 distinguishes planned rotation from security revocation.

**Sources:**
- [Architecture discovery, original AD-012 extraction, lines 148–157](../archive/conversations/architecture-discovery.md#L148-L157)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
