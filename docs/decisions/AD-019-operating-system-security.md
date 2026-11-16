# AD-019 — Operating-system security capabilities

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval evidence class:** Direct numbered Option C user approval recovered in conversation extraction.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Preserving security requirements across Windows, Linux, and macOS differences.

## Alternatives considered

Options A/B unavailable.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

OS-neutral core, capability-based security adapters, representative Windows/Linux experiments first, macOS architectural target pending verification, fail closed when required capabilities unsupported.

## Rationale

Cross-platform API support must not imply equivalent platform security guarantees (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

“I approve Architecture Decision 19, Option C: an operating-system-neutral core with capability-based security adapters, representative Windows and Linux experiments first, macOS as a supported architectural target subject to verification, and explicit fail-closed handling for unsupported security requirements.”

**Evidence classification:** Direct numbered Option C user approval recovered in conversation extraction.

## Related requirements and acceptance scenarios

EXP-002-A/B cross-platform security; EXP-004 SCN-016–019.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decision 33 applies the same compatibility principle to protocol adapters.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-019 extraction, lines 218–227](../archive/conversations/architecture-discovery.md#L218-L227)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
