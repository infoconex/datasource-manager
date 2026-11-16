# Architecture decision evidence and qualifications

**Record updated:** November 15, 2026 (Pacific time)  
**Scope:** Historical evidence supplement for AD-001–AD-035. **Each individual ADR, reached through the [canonical decision index](README.md), is the current decision record.** This document preserves retrospective source recovery and approval qualifications; it is **not** an alternative normative decision catalogue. Documentation only—no change to approved scope or implementation authorization.  
**Evidence basis:** The [original discovery extraction](../archive/conversations/architecture-discovery.md), [recovery discussion](../archive/conversations/recovery-and-compatibility.md), and [final approval review](../archive/conversations/final-architecture-review.md), supplemented by [three conversation-specific historical reviews](../archive/reviews/). The latter recovered additional early transcript statements and times that **were not in the abbreviated original discovery extraction**. They are retrospective reports and must not be confused with the original transcript itself. Quotations below are from the reviews' reported original conversation evidence, not invented from the shorter archive.

## Reading approvals accurately

Individual ADR titles are editorial descriptions, not necessarily historical verbatim headings. Decision-specific rationale and consequence text explains the approved scope; the preserved source records remain authoritative for original wording and approval evidence.

- **Direct numbered approval:** Jim explicitly named the decision ID and selected option.
- **User-selected + assistant-recorded:** Jim stated the requirement/choice and the immediate assistant response labeled the numbered decision approved; not an invented direct "I approve" vote.
- **Direct requirement + assistant-recorded:** user made an explicit product requirement; assistant assigned it to a numbered decision, but no original numbered vote was recovered.
- **Inherited baseline:** a later handoff states decisions are established. This alone does **not** prove any missing individual choice.
- **Blanket acceptance/delegation:** owner authorized general recommendations; assistant independently selected subsequent details. Does not establish individual direct approval.
- **Unresolved:** original option choice or text cannot be verified; do not silently assume the recommended alternative won.

Times in this early section are **UTC on November 15, 2026 as reported in the historical review**, not timestamps newly inspected through GitHub.

## AD-001 — Desktop and server application support

**Primary decision record:** [AD-001](AD-001-desktop-and-server-applications.md).

- **Problem:** Whether the manager serves interactive desktop applications, server applications, or both.
- **Recovered alternatives:** A both desktop and server (**recommended**); B server only; C desktop only.
- **Selected approach:** Both application types, with provider-qualified platform support.
- **Approval evidence:** At 20:55:52Z Jim stated: “The library should support both desktop and server applications. Continue architecture discovery with the next decision.” At 20:56:02Z the assistant recorded “Decision 1 approved.” **Class:** user-selected plus assistant-recorded, **not** a literal numbered Option A approval.
- **Rationale / qualification:** One provider-neutral library can serve both hosting patterns. This does **not** guarantee each provider on every OS or framework; later AD-019/033/034 set a qualified compatibility matrix. Earlier macOS aspirations remain qualification work, not automatic support.
- **Related scope:** AD-019/033/034; POC-SCN-04, POC-SCN-21 (later topical links, **not original numbered trace**). No identified supersession.

## AD-002 — Configuration and credential storage: original vote unverified, current Option A confirmed

**Primary decision record:** [AD-002](AD-002-configuration-and-credential-storage.md).

- **Problem:** Who owns configuration and credential persistence.
- **Recovered *initial proposal* (20:56:02Z):** A pluggable storage (**recommended**); B built-in SQLite storage; C consumer-managed storage.
- **Historical interruption/refinement:** At 21:03:52Z Jim described the existing XML/XSD/DataTable manager, central configuration, protected distributed credentials and offline caches, and requested reconsideration. At 21:04:15Z the assistant reframed the problem to separate central configuration management, credential management and client library concerns.
- **Original historical disposition:** The **original A/B/C final choice is not recovered**. Do **not** claim A was approved at the time because it was recommended. The later "AD-001–033 established" handoff is evidence of inherited program scope, not the missing individual vote. Exact historical supersession relationship/ID remains unresolved.
- **New owner confirmation (November 15, 2026):** Jim directly answered **“Yes”** to the explicitly enumerated recommendation to approve **AD-002 Option A, refined**: pluggable configuration storage, independently pluggable credential storage, multiple separate stores/profiles, optional built-in adapters, consumer-provided implementations, and no mandatory core SQLite dependency. This **prospectively establishes the current design** without rewriting the original record. See [AD-002 decision](AD-002-configuration-and-credential-storage.md).
- **Related scope:** AD-006/009–013; POC-SCN-05–08. The following historically separate choice is carried forward into the new AD-002 confirmation **without reassigning its original unknown AD identifier**.

### Accepted requirement with no verified AD identifier: plural stores and profiles

At 21:29:58Z Jim stated: “I choose Option C: support both multiple credential stores and multiple connection profiles, keeping the abstractions separate. Continue architecture discovery.” Recovered options were A multiple credential stores, B multiple connection profiles, C both. The original numbered AD to which this question belonged **is not established**. Preserve **multiple independent credential stores** and **multiple connection profiles**, separately modeled; authentication strategies remain separate again under AD-006. Existing POC-SCN-05–08 cover neighboring boundaries but **do not prove several stores and profiles concurrently**. That exact proof remains deferred/unmapped, without a fabricated SCN ID.

## AD-003 — Managed and customer-owned security contexts

**Primary decision record:** [AD-003](AD-003-managed-and-customer-owned-devices.md).

- **Problem:** One device trust assumption cannot safely apply to both managed and customer-owned environments.
- **Recovered alternatives:** Individual original AD-003 alternative options not recovered; do **not** import AD-004 options here.
- **Selected requirement:** At 21:23:30Z Jim stated: “The library must support both trusted managed systems and customer-owned systems. Continue the architecture discussion, explain the security implications, and ask the next question.” At 21:23:52Z the assistant recorded “Decision 3 recorded.”
- **Class:** Direct requirement assertion plus assistant-recorded decision; **not** a user quote naming AD-003 Option C.
- **Rationale / qualification:** Managed devices may support stronger workload identity and protected caches; customer-controlled devices have different trust ceilings, may need brokered credentials and conservative default authorization. No ordinary user-space library guarantees protection on a fully compromised customer-controlled host.
- **Related scope:** AD-004/011/013/018/019; POC-SCN-07–10. Later policies refine, not repeal, support for both deployment classes.

## AD-004 — Organization-bounded per-profile offline policy

**Primary decision record:** [AD-004](AD-004-offline-policy.md).

- **Problem:** Balance offline continuity with delayed revocation and customer-owned risk.
- **Recovered alternatives:** A configuration cache only, central access for new credential-dependent connections; B protected config/credential cache for offline access with delayed revocation; C policy-controlled per-profile offline authorization constrained by organization rules (**recommended**).
- **Approval evidence:** At 21:31:03Z Jim stated: “I approve offline policy Option C: configurable per-profile offline policies, subject to organization-wide restrictions, with conservative defaults on customer-owned systems. Continue architecture discovery.” At 21:31:23Z the assistant acknowledged “Architecture Decision 4 approved.” **Class:** direct user Option C, immediate numbered attribution.
- **Rationale / qualification:** Online-only is the conservative default for centrally managed secrets on customer-owned endpoints, with explicit, bounded policy exceptions. **Cached configuration is never perpetual authorization**; offline grants require strict verifiable expiry and no implicit grace. AD-014/016/018 further constrain time, emergency and expiration guarantees.
- **Related scope:** POC-SCN-06/09; EXP-002 offline authorization topic. No reversal.

## AD-005 — Requester identity and organization/profile authorization

**Primary decision record:** [AD-005](AD-005-identity-and-authorization.md).

- **Problem:** Distinguish user, application and combined identity requirements for acquisition.
- **Recovered alternatives:** A user identity (OIDC/OAuth2); B application/workload identity; C policy-driven user identity, application identity, or **both**.
- **Approval evidence:** At 22:08:24Z Jim stated: “I approve Architecture Decision 5, Option C: policy-driven authentication supporting user identity, application identity, and both when required. Keep authentication provider-neutral and enforce organization and profile authorization.” **Class:** direct numbered Option C.
- **Rationale / qualification:** Requester authorization at organization and profile levels is separate from credentials used to authenticate to SQL/SFTP/etc. under AD-006. Do not imply a single universal authorization identity.
- **Related scope:** EXP-004 capability authorization; POC-SCN-07. AD-006/009/011/029 specialize, not supersede.

## AD-006 — Multiple provider connection authentication strategies

**Primary decision record:** [AD-006](AD-006-provider-authentication.md).

- **Problem:** Provider protocols and deployment environments need different authentication mechanisms.
- **Recovered alternatives:** A centrally managed credentials; B individual identity-based connections; C per-profile selection among multiple strategies.
- **Approval evidence:** At 22:09:57Z Jim stated: “I approve Architecture Decision 6, Option C: multiple authentication strategies per connection profile, including shared credentials, user-specific credentials, integrated authentication, certificates, and passwordless identities where supported. Keep authentication strategies separate from credential stores and enforce security policies. Continue architecture discovery.” **Class:** direct numbered Option C.
- **Rationale / qualification:** Selection is constrained by provider, OS/framework capabilities, identity and organizational policy; the listed mechanisms are **not promises of universal support**. Credential *store* and authentication *strategy* are distinct abstractions.
- **Related scope:** AD-011–013; POC-SCN-07/08/12; EXP-003 SCN-008. Later lifecycle decisions refine.

## AD-007A — Hybrid provider-native-first routing ownership

**Primary decision record:** [AD-007A](AD-007A-routing-ownership.md).

- **Problem:** Avoid replacing sound provider-native routing with a generic coordinator that lacks provider semantics.
- **Recovered alternatives:** A provider-native only; B library-managed only; C hybrid/provider-native-first.
- **Approval evidence:** At 22:14:50Z Jim stated: “I approve Architecture Decision 7A, Option C: hybrid provider-native-first routing, with provider-neutral routing and resilience policies and library-managed implementations only where appropriate.” **Class:** direct numbered Option C.
- **Rationale / qualification:** Honor provider-native routing when it satisfies policy; library routing is conditional and cannot invent replica consistency guarantees.
- **Related scope:** AD-023/024; EXP-003 SCN-001–003. No reversal.

## AD-007B — Extensible but safety-first topology

**Primary decision record:** [AD-007B](AD-007B-topology-model.md).

- **Problem:** Scope initial failover and replica behavior without promising uncoordinated multi-writer correctness.
- **Recovered alternatives:** A coordinated standalone/active-passive/primary-replica first; B all topologies including independently writable databases/sharding immediately; C extensible model implementing A first, allowing provider-managed multi-primary only with verified guarantees, deferring independently writable/sharded routing.
- **Approval evidence:** At 22:15:38Z Jim stated: “I approve Architecture Decision 7B, Option C: an extensible topology model with safe coordinated topologies implemented first, provider-managed multi-primary support where appropriate, and future extensibility for independent databases and sharding.” **Class:** direct numbered Option C.
- **Rationale / qualification:** Explicitly defer independent database routing, partition-aware sharding and unsafe multi-writer assumptions. AD-024 further limits stale/freshness and transaction affinity.
- **Related scope:** EXP-003 SCN-001–005; D-15 (later POC deferral). No reversal.

## AD-007C — Managed acquisition with authorized raw-export exception

**Primary decision record:** [AD-007C](AD-007C-managed-connections.md).

- **Problem:** Preserve policy/lifecycle control while allowing exceptional legacy/native use.
- **Recovered alternatives:** A connection strings as primary; B only managed connections; C managed connections primary, raw connection-string export only when explicitly authorized.
- **Approval evidence:** At 22:16:32Z Jim stated: “I approve Architecture Decision 7C, Option C: managed connections as the primary API, with explicitly authorized connection-string export and clear disclosure of routing limitations.” **Class:** direct numbered Option C.
- **Rationale / qualification:** Default is policy-controlled managed leases. Raw connection-string export is an **exceptional authorized escape hatch**, not a default or equivalent managed API. After export the library cannot reliably enforce destination routing, leased-resource disposal, in-flight operations, telemetry or immediate revocation of arbitrary caller-owned native connections.
- **Related scope:** AD-028; EXP-004 lease scenarios (adjacent only). POC-SCN-11/13 **do not test raw export**. A dedicated future security review and acceptance proof are deferred/unmapped; POC-001 does not authorize building this feature. AD-028 refines lease expectations, does not silently erase the exception.

## AD-008 — Layered capability-based public API

**Primary decision record:** [AD-008](AD-008-layered-capability-api.md).

- **Problem:** One universal operational interface cannot honestly describe databases, file transfer, mail and SMB.
- **Recovered alternatives:** A connection manager only; B universal provider-operations API; C focused core with optional provider-specific operational capabilities.
- **Approval evidence:** At 22:17:03Z Jim stated: “I approve Architecture Decision 8, Option C: layered capability-based APIs, with a focused connection-management core and optional provider-specific operational capabilities.” **Class:** direct numbered Option C.
- **Rationale / qualification:** Keep optional provider operations in separate adapters/extensions. Typed database connections where appropriate, typed FTP/SFTP/SMTP/SMB resources where appropriate; no forced universal `DbConnection`.
- **Related scope:** AD-028/029/031; POC-SCN-01–03/11; EXP-004 SCN-001–005/010. No reversal.

## AD-009–AD-035 — Decision-specific archived evidence index

Every one of these decisions now has a dedicated file linked from the [canonical register](README.md). The table below remains a **historical source locator** and evidence-classification aid, not a substitute for individual ADRs.

For these IDs the indicated original extraction sections contain **problem, selected approach, rationale, approval category, downstream scenarios and refinement notes**. Where the extraction explicitly says "analytical summary" or "alternatives not preserved," that remains the qualification; the links do not manufacture missing transcripts.

| ID | Direct archive section | Historical approval strength and key qualification |
| --- | --- | --- |
| AD-009 | [Discovery extraction, lines 118–127](../archive/conversations/architecture-discovery.md#L118-L127) | Direct Option C; protected central read-only caches, standalone local ownership, bounded overrides. |
| AD-010 | [Discovery extraction, lines 128–137](../archive/conversations/architecture-discovery.md#L128-L137) | Direct Option C; authenticated monotonic revision and atomic activation. |
| AD-011 | [Discovery extraction, lines 138–147](../archive/conversations/architecture-discovery.md#L138-L147) | Direct Option C; trust-tier secret delivery, no unsafe export. |
| AD-012 | [Discovery extraction, lines 148–157](../archive/conversations/architecture-discovery.md#L148-L157) | Direct Option C; rotation coordination, not universal source rotation. |
| AD-013 | [Discovery extraction, lines 158–167](../archive/conversations/architecture-discovery.md#L158-L167) | Direct Option C; context-bound caches, fail-closed mismatch. |
| AD-014 | [Discovery extraction, lines 168–177](../archive/conversations/architecture-discovery.md#L168-L177) | Direct Option C; strict expiry and separate emergency grants. |
| AD-015 | [Discovery extraction, lines 178–187](../archive/conversations/architecture-discovery.md#L178-L187) | Direct Option C; honest active-lease limits during revocation. |
| AD-016 | [Discovery extraction, lines 188–197](../archive/conversations/architecture-discovery.md#L188-L197) | Direct Option C; emergency grant and controlled activation. |
| AD-017 | [Discovery extraction, lines 198–207](../archive/conversations/architecture-discovery.md#L198-L207) | Direct Option C; durable pre-access security audit independent of telemetry. |
| AD-018 | [Discovery extraction, lines 208–217](../archive/conversations/architecture-discovery.md#L208-L217) | Direct Option C; trusted time only within verifiable trust anchor. |
| AD-019 | [Discovery extraction, lines 218–227](../archive/conversations/architecture-discovery.md#L218-L227) | Direct Option C; OS security capability fail-closed. |
| AD-020 | [Discovery extraction, lines 228–237](../archive/conversations/architecture-discovery.md#L228-L237) | Direct Option C; acquisition retry bounded, never blind operation replay. |
| AD-021 | [Discovery extraction, lines 238–247](../archive/conversations/architecture-discovery.md#L238-L247) | Direct Option C; passive/provider-native health, active probing authorized. |
| AD-022 | [Discovery extraction, lines 248–257](../archive/conversations/architecture-discovery.md#L248-L257) | Direct Option C; local authority, shared observations advisory. |
| AD-023 | [Discovery extraction, lines 258–267](../archive/conversations/architecture-discovery.md#L258-L267) | Direct Option C; provider-native preference, conditional library algorithms. |
| AD-024 | [Discovery extraction, lines 268–277](../archive/conversations/architecture-discovery.md#L268-L277) | Direct Option C; consistency, freshness and transaction affinity constraints. |
| AD-025 | [Discovery extraction, lines 278–287](../archive/conversations/architecture-discovery.md#L278-L287) | Revised Option C accepted conversationally after no-Polly objection; NOT direct numbered approval. |
| AD-026 | [Discovery extraction, lines 288–297](../archive/conversations/architecture-discovery.md#L288-L297) | Direct Option C; privacy-first .NET-native telemetry; audit separate. |
| AD-027 | [Discovery extraction, lines 298–307](../archive/conversations/architecture-discovery.md#L298-L307) | Direct Option C; failure-domain breaker isolation and bounded recovery. |
| AD-028 | [Discovery extraction, lines 308–317](../archive/conversations/architecture-discovery.md#L308-L317) | Direct Option C; managed typed leases, explicit disposal, native pool owner. |
| AD-029 | [Discovery extraction, lines 318–327](../archive/conversations/architecture-discovery.md#L318-L327) | Blanket acceptance, not individual numbered approval. |
| AD-030 | [Discovery extraction, lines 328–337](../archive/conversations/architecture-discovery.md#L328-L337) | Assistant-selected under delegated autonomy; no individual owner vote. |
| AD-031 | [Discovery extraction, lines 338–347](../archive/conversations/architecture-discovery.md#L338-L347) | Assistant-selected under delegated autonomy; no individual owner vote. |
| AD-032 | [Discovery extraction, lines 348–357](../archive/conversations/architecture-discovery.md#L348-L357) | Assistant-selected under delegated autonomy; no individual owner vote. |
| AD-033 | [Discovery extraction, lines 358–366](../archive/conversations/architecture-discovery.md#L358-L366) | Assistant-selected under delegated autonomy; no individual owner vote. |
| AD-034 | [Final-review approval and matrix](../archive/conversations/final-architecture-review.md#L13-L20) | Later explicit approval of framework policy; .NET Framework 4.8/Windows, .NET 10/Windows/Linux, .NET 11 qualification, .NET 8 best effort, no .NET 6. |
| AD-035 | [Final-review approval](../archive/conversations/final-architecture-review.md#L13-L20) | Later explicit approval of **optional native-pool coordination** only; implementation deferred and no replacement pool. |

## Historical reconciliation and unresolved evidence

1. The five original conversation/charter snapshots are **unchanged**. The [three reviews](../archive/reviews/) are later, source-specific assessments of the earlier PR candidate. They sometimes disagree about what was recoverable: the final-review-only assessment could not see AD-001–003 primary evidence; the two early-conversation reviews later recovered AD-001/003 and the AD-002 *proposal*. Prefer the more direct early evidence for those IDs, but **do not invent the missing original AD-002 vote**. The dated [current AD-002 confirmation](AD-002-configuration-and-credential-storage.md) is a separate approval event.
2. AD-004/005/006/007A/007B/007C/008 original alternative sets are **abbreviated descriptions recovered by reviewers**. They do not warrant claiming their full original proposal text is preserved.
3. No subsequent source shows formal repeal of early AD-001/003–008. Later security, consistency and compatibility decisions **qualify** them; the initial AD-002 storage proposal was re-framed, but a precise formal historical supersession ID cannot be verified. The owner's **new dated refined Option A confirmation** establishes the prospective design.
4. [Historical EXP and approved POC traceability](../requirements/experiment-traceability.md) distinguishes original scenario ID namespaces, thematic reconstructions, coverage and deferrals. Neither a documented proposal nor a later general charter approval counts as an executed test or a retroactive exact earlier user quote.
5. **Open historical evidence debt:** locate original AD-002 vote if available (the current choice is approved separately), original EXP-001 charter and original EXP-002 full scenario-ID-to-text mapping; prove simultaneous multiple-store/multiple-profile behavior, authorized raw-export constraints, and deferred EXP-003/004 cases in later gated increments.

