# AD-033 — Compatibility matrices

**Status:** Selected by assistant under owner's blanket delegation; later carried forward  
**Approval evidence class:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Avoiding false claims that all operating systems, target frameworks, and providers support identical features.

## Alternatives considered

Not presented to user; no option letter.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Explicit framework/OS/provider capability matrices; unsupported security requirements fail closed.

## Rationale

Compatibility must be verified against provider and platform reality (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

Assistant-selected under blanket delegation; **not individually ratified**.

**Evidence classification:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.

## Related requirements and acceptance scenarios

EXP-004 SCN-016–020.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Extends, does not supersede, Decision 19.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-033 extraction, lines 358–367](../archive/conversations/architecture-discovery.md#L358-L367)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
