# AD-026 — Privacy-first telemetry

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Useful monitoring without secret exposure, unbounded dimensions, exporter coupling, or replacing security audit.

## Alternatives considered

**A** minimal failure/state diagnostics, application builds rest; **B** comprehensive detailed telemetry by default; **C** policy-driven privacy-first built-in .NET instrumentation, safe baseline and opt-in rich data.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Built-in .NET metrics/traces/events, application-controlled collection/export, low-cardinality attributes, sensitive data excluded by default, independent mandatory security auditing, no third-party telemetry dependency in core.

## Rationale

Vendor-neutral enterprise observability with minimal disclosure and coupling (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 26, Option C: policy-driven privacy-first telemetry using built-in .NET instrumentation, safe default metrics/traces/events, application-controlled collection and export, explicitly authorized richer diagnostics, low-cardinality attributes, independent security auditing, and no third-party telemetry dependency in the core.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-003 SCN-017–020.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Reinforces Decision 17's separate audit journal; no supersession.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-026 extraction, lines 288–297](../archive/conversations/architecture-discovery.md#L288-L297)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
