# AD-031 — Dependency isolation

**Status:** Selected by assistant under owner's blanket delegation; later carried forward  
**Approval basis:** Assistant-selected under delegated autonomy; **not** an item-specific owner approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Avoiding optional provider packages becoming core/transitive requirements for all consumers.

## Decision

Dependency-free core; provider-specific drivers/dependencies only in optional adapter packages.

## Alternatives considered

Not presented to user; no option letter.

## Rationale

Most consumers do not use every supported protocol. Keeping drivers out of the common core reduces unwanted runtime dependencies and preserves compatibility when optional providers have different native or framework constraints.

## Consequences and limitations

- Each provider adapter carries its own dependencies; selecting one does not require unrelated driver packages.
- Package boundaries and adapter versions need explicit compatibility verification.
- The common core remains independent of optional provider drivers rather than hiding them as transitive requirements.

## Traceability

**Approval history:** Assistant-selected under blanket delegation; **not individually ratified**. Related principle was expressly discussed and user said “Agreed” earlier, but this numbered decision was formulated later.

**Requirements and scenarios:** EXP-004 SCN-006–007, SCN-009, SCN-020.

**Related decisions and refinements:** No subsequent revision shown.

**Sources:**
- [Architecture discovery, original AD-031 extraction, lines 338–347](../archive/conversations/architecture-discovery.md#L338-L347)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
