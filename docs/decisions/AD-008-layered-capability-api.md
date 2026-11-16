# AD-008 — Layered capability-based public API

**Status:** Approved in the carried-forward architecture baseline  
**Approval basis:** Direct user numbered Option C approval.  
**Verification:** Architecture only; no POC or experiment executed.

## Context

One universal operational interface cannot honestly describe databases, file transfer, mail and SMB.

## Decision

Option C: Focused connection-management core and optional provider-specific capabilities.

## Alternatives considered

A connection manager only; B universal provider-operations API; C focused core with optional provider-specific operational capabilities.

## Rationale

A database connection, file-transfer session, SMTP client and SMB resource expose materially different operations. Focused capability contracts let each adapter expose meaningful typed resources without burdening unrelated consumers with a fake universal connection interface.

## Consequences and limitations

- The core concentrates on configuration, admission and acquisition; protocol operations stay in optional provider-specific capabilities.
- No universal `DbConnection` abstraction is imposed on FTP, SFTP, SMTP or SMB.
- Callers select the capabilities they need; unsupported operations must be identified rather than offered as nominal methods that fail later.

## Traceability

**Approval history:** At 22:17:03Z Jim stated: “I approve Architecture Decision 8, Option C: layered capability-based APIs, with a focused connection-management core and optional provider-specific operational capabilities.” **Class:** direct numbered Option C.

**Requirements and scenarios:** AD-028/029/031; POC-SCN-01–03/11; EXP-004 SCN-001–005/010. No reversal.

**Historical evidence limit:** The recovered early evidence is reported in retrospective conversation reviews; the earlier abbreviated discovery extraction did not contain the complete AD-001–AD-008 original messages.  

**Sources:**
- [Recovered early approval evidence](decision-evidence.md)
- [Original abbreviated architecture discovery](../archive/conversations/architecture-discovery.md) (does **not** include the complete early transcripts)
- [Early architecture history review](../archive/reviews/early-architecture-history-review.md) (retrospective source-specific recovery)
- [POC-001 acceptance scenarios](../requirements/POC-001.md)
- [Experiment and POC traceability](../requirements/experiment-traceability.md)
- [Approved architecture and POC charter](../archive/charters/architecture-and-poc-execution-charter.md)
