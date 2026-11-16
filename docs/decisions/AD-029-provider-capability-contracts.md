# AD-029 — Layered provider capability contracts

**Status:** Accepted under owner's blanket recommendation approval  
**Approval basis:** Blanket acceptance; **not** a direct numbered user vote.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

Determining capability support/availability/permission across unrelated protocols without late surprises or false universal interfaces.

## Decision

Stable versioned interfaces, static capability validation where possible, authorized runtime verification where necessary, no unsolicited customer-owned probes, explicitly unknown state, fail-closed unverifiable required security/consistency, typed failure categories, optional adapter dependencies.

## Alternatives considered

**A** attempt operation and discover support at runtime; **B** universal capability interface where unsupported methods throw; **C** explicit capability contracts distinguishing supported, available, and authorized.

## Rationale

Treating every protocol as a universal capability interface either hides unsupported operations until runtime or forces misleading no-op methods. Explicit capability contracts distinguish whether a feature is structurally supported, currently available and authorized for the caller.

## Consequences and limitations

- Static validation is preferred when sufficient; runtime probing requires authorization and must not be unsolicited on customer-owned devices.
- Unknown is a first-class result, not a fabricated positive or negative capability declaration.
- Unverifiable required security or consistency properties fail closed; structured failures distinguish unsupported, unavailable and unauthorized behavior.
- The original approval was blanket acceptance of recommendations, not an individual numbered vote.

## Traceability

**Approval history:** Immediately after Option C was recommended, user said, **“I accept all your remaining recommendations.”** The assistant subsequently recorded “Decision 29, Option C is accepted.” There is **no individual “Decision 29, Option C” user approval sentence**.

**Requirements and scenarios:** EXP-004 SCN-003–005, SCN-010, SCN-019.

**Related decisions and refinements:** Decisions 30–33 were subsequently selected by assistant under the broad delegation; not independently ratified.

**Sources:**
- [Architecture discovery, original AD-029 extraction, lines 318–327](../archive/conversations/architecture-discovery.md#L318-L327)
- [Cross-decision approval classification](decision-evidence.md)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
