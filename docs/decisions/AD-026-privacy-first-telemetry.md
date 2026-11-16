# AD-026 — Privacy-first telemetry

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Useful monitoring without secret exposure, unbounded dimensions, exporter coupling, or replacing security audit.

## Decision

Built-in .NET metrics/traces/events, application-controlled collection/export, low-cardinality attributes, sensitive data excluded by default, independent mandatory security auditing, no third-party telemetry dependency in core.

## Alternatives considered

**A** minimal failure/state diagnostics, application builds rest; **B** comprehensive detailed telemetry by default; **C** policy-driven privacy-first built-in .NET instrumentation, safe baseline and opt-in rich data.

## Rationale

Operational visibility is useful only if it does not expose credentials, tenant-sensitive dimensions or an obligatory external exporter. Built-in .NET diagnostics keep the core provider-neutral while leaving collection and transmission to the host application.

## Consequences and limitations

- Default measurements and traces use bounded, low-cardinality attributes and exclude sensitive material.
- Applications own diagnostic collection and export; no third-party telemetry package becomes a core dependency.
- Required security audit events remain a separate governed record and cannot be replaced by optional telemetry.

## Traceability

**Approval history:** “I approve Architecture Decision 26, Option C: policy-driven privacy-first telemetry using built-in .NET instrumentation, safe default metrics/traces/events, application-controlled collection and export, explicitly authorized richer diagnostics, low-cardinality attributes, independent security auditing, and no third-party telemetry dependency in the core.”

**Requirements and scenarios:** EXP-003 SCN-017–020.

**Related decisions and refinements:** Reinforces Decision 17's separate audit journal; no supersession.

**Sources:**
- [Architecture discovery, original AD-026 extraction, lines 288–297](../archive/conversations/architecture-discovery.md#L288-L297)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
