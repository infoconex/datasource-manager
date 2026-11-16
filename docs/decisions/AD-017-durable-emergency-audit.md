# AD-017 — Durable emergency audit

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Preventing emergency access without a reliable accountability record while offline.

## Decision

Protected, durable local recording of critical emergency events **before** access; fail closed if required persistence unavailable; idempotent online reconciliation; operational telemetry separately governed.

## Alternatives considered

Options A/B unavailable.

## Rationale

If emergency access is allowed while offline, a best-effort remote audit exporter cannot be its sole record. Recording the critical event durably before use makes audit a prerequisite to exceptional authority.

## Consequences and limitations

- Required protected local audit persistence must succeed before emergency access is granted; failure is fail-closed.
- Offline records reconcile idempotently after reconnection, preserving security-event accountability.
- Optional operational telemetry cannot substitute for the mandatory security audit record.

## Traceability

**Approval history:** “I approve Architecture Decision 17, Option C: require durable protected local recording of security-critical emergency-access events before granting access, fail closed when required persistence is unavailable, reconcile idempotently when online, and keep ordinary operational telemetry separately governed.”

**Requirements and scenarios:** EXP-002-D; EXP-003 SCN-020 later tests audit/telemetry separation.

**Related decisions and refinements:** Decision 26 retains independent telemetry and no collector dependence.

**Sources:**
- [Architecture discovery, original AD-017 extraction, lines 198–207](../archive/conversations/architecture-discovery.md#L198-L207)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
