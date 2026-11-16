# AD-019 — Operating-system security capabilities

**Status:** Approved in the architectural baseline; direct numbered Option C approval  
**Approval basis:** Direct numbered Option C user approval recovered in conversation extraction.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Preserving security requirements across Windows, Linux, and macOS differences.

## Decision

OS-neutral core, capability-based security adapters, representative Windows/Linux experiments first, macOS architectural target pending verification, fail closed when required capabilities unsupported.

## Alternatives considered

Options A/B unavailable.

## Rationale

A cross-platform API does not imply that Windows, Linux and macOS offer equivalent secure storage, identity or time-attestation features. Capability-specific adapters let the core express required guarantees while failing closed when a platform cannot deliver them.

## Consequences and limitations

- Windows and Linux receive representative security qualification first; macOS remains an architectural target pending evidence.
- Missing mandatory key protection, identity or expiration capabilities cannot be silently downgraded to weaker substitutes.
- A provider/runtime/OS feature is supported only to the extent recorded in the verified compatibility matrix.

## Traceability

**Approval history:** “I approve Architecture Decision 19, Option C: an operating-system-neutral core with capability-based security adapters, representative Windows and Linux experiments first, macOS as a supported architectural target subject to verification, and explicit fail-closed handling for unsupported security requirements.”

**Requirements and scenarios:** EXP-002-A/B cross-platform security; EXP-004 SCN-016–019.

**Related decisions and refinements:** Decision 33 applies the same compatibility principle to protocol adapters.

**Sources:**
- [Architecture discovery, original AD-019 extraction, lines 218–227](../archive/conversations/architecture-discovery.md#L218-L227)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
