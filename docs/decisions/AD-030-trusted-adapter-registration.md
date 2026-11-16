# AD-030 — Explicit adapter registration

**Status:** Selected by assistant under owner's blanket delegation; later carried forward  
**Approval basis:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Activation of untrusted or unexpected provider assemblies.

## Decision

Explicit registration of trusted adapters; no automatic loading of arbitrary assemblies.

## Alternatives considered

Not presented to user; no option letter in source.

## Rationale

Automatically loading every discovered provider assembly expands the executable trust boundary. Requiring explicit registration makes the application choose which adapters and corresponding dependencies it authorizes.

## Consequences and limitations

- Composition/setup requires explicit registration of permitted provider adapters; discovering an assembly does not authorize its execution.
- The core must not dynamically load arbitrary provider packages merely because they are present.
- Provider availability and authorization remain separate from the act of registering an adapter.

## Traceability

**Approval history:** Assistant-selected **after** user's broad “all remaining recommendations” delegation. **Not individually reviewed or expressly approved** in source.

**Requirements and scenarios:** EXP-004 SCN-006, SCN-008.

**Related decisions and refinements:** No subsequent modification recorded.

**Sources:**
- [Architecture discovery, original AD-030 extraction, lines 328–337](../archive/conversations/architecture-discovery.md#L328-L337)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
