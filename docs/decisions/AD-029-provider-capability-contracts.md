# AD-029 — Layered provider capability contracts

**Status:** Accepted under owner's blanket recommendation approval  
**Approval evidence class:** Blanket acceptance; **not** a direct numbered user vote.  
**Decision title:** Editorial reconstruction from the approved architecture discussion; not asserted to be the exact historical heading.  
**Implementation state:** Architectural plan only; no POC work executed as evidence of this decision.

## Context and problem

Determining capability support/availability/permission across unrelated protocols without late surprises or false universal interfaces.

## Alternatives considered

**A** attempt operation and discover support at runtime; **B** universal capability interface where unsupported methods throw; **C** explicit capability contracts distinguishing supported, available, and authorized.

When the source reports missing original alternatives, no additional options are inferred.

## Selected approach

Stable versioned interfaces, static capability validation where possible, authorized runtime verification where necessary, no unsolicited customer-owned probes, explicitly unknown state, fail-closed unverifiable required security/consistency, typed failure categories, optional adapter dependencies.

## Rationale

Early validation and accurate cross-provider capability behavior without fabricating uniform operations (analytical summary).

## Consequences and security/compatibility limits

The selected approach is bounded by the recorded rationale and refinements, applicable organizational/security policy, provider capabilities, and the [approved architecture charter](../archive/charters/architecture-and-poc-execution-charter.md). Documented acceptance scenarios remain unexecuted; no broader guarantee is asserted.

## Approval and historical evidence

Immediately after Option C was recommended, user said, **“I accept all your remaining recommendations.”** The assistant subsequently recorded “Decision 29, Option C is accepted.” There is **no individual “Decision 29, Option C” user approval sentence**.

**Evidence classification:** Blanket acceptance; **not** a direct numbered user vote.

## Related requirements and acceptance scenarios

EXP-004 SCN-003–005, SCN-010, SCN-019.

The references above reflect the historical summary; for [POC-001 exact acceptance criteria](../requirements/POC-001.md) and conservative experimental mapping see [experiment traceability](../requirements/experiment-traceability.md). A scenario reference is planning traceability, not a test pass.

## Related decisions and supersession

Decisions 30–33 were subsequently selected by assistant under the broad delegation; not independently ratified.

Unless the text above explicitly states a revision, no separate formally numbered superseding decision is evidenced by this source. Later decisions may narrow capabilities without repealing the selected architecture.

## Evidence source

- [Architecture discovery, original AD-029 extraction, lines 318–327](../archive/conversations/architecture-discovery.md#L318-L327)
- [Cross-decision approval classification](decision-evidence.md)
- [Decision register](README.md)
