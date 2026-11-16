# AD-033 — Compatibility matrices

**Status:** Selected by assistant under owner's blanket delegation; later carried forward  
**Approval basis:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Avoiding false claims that all operating systems, target frameworks, and providers support identical features.

## Decision

Explicit framework/OS/provider capability matrices; unsupported security requirements fail closed.

## Alternatives considered

Not presented to user; no option letter.

## Rationale

The existence of a common .NET API cannot establish that every provider, OS and framework supplies the same native libraries or security mechanisms. Maintaining explicit qualification evidence prevents broad marketing claims from masking unsupported combinations.

## Consequences and limitations

- Supported provider/OS/framework combinations and their feature limits must be recorded and validated independently.
- A required security feature that lacks a verified implementation fails closed.
- Matrix maintenance is an ongoing cost as frameworks, operating systems and provider drivers change; AD-034 narrows the officially supported runtime baseline.

## Traceability

**Approval history:** Assistant-selected under blanket delegation; **not individually ratified**.

**Requirements and scenarios:** EXP-004 SCN-016–020.

**Related decisions and refinements:** Extends, does not supersede, Decision 19.

**Sources:**
- [Architecture discovery, original AD-033 extraction, lines 358–367](../archive/conversations/architecture-discovery.md#L358-L367)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
