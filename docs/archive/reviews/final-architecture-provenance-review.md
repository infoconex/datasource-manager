# Data Source Manager — PR #2 Architecture and Provenance Review

**Review date:** 2026-11-15 (America/Los_Angeles)  
**Repository:** [infoconex/datasource-manager](https://github.com/infoconex/datasource-manager)  
**Pull request:** [#2](https://github.com/infoconex/datasource-manager/pull/2)  
**Exact candidate examined:** c3c691b42556261a9a73e5dab0bce788682956b9  
**Disposition:** Read-only findings and recommended documentation corrections. No GitHub modifications, implementation, experiment execution, or approval of changes.

## Executive assessment

The candidate provides a useful, broadly faithful planning baseline: an indexed AD-001–AD-035 register, three conversation extractions, two preserved charters, and the 21 subsequently approved POC-SCN-01–21 criteria. It correctly distinguishes most direct approvals, conversational assent, blanket acceptance, and delegated selections; it preserves the later approval of AD-034/AD-035 without claiming experiment execution; and it records core security, SQL recovery, and framework qualifications.

**However, the canonical records are not yet an adequate standalone history of AD-001–AD-008.** Several recoverable Option C details remain only in an archived analytical extraction; one material security qualification (AD-007C's conditional raw-connection-string export) is missing from the current canonical documents. Some early experiment scenario descriptions are mapped to historical IDs more confidently than the primary evidence permits. Two different POC scenario ID schemes also need an explicit provenance crosswalk.

This review uses the **source conversation available here**, the existing archived conversation extracts in this PR, and the PR's eight files at the specified SHA. An archived analytical reconstruction is **not the same thing as an original transcript**. Original individual wording and approval events absent from the available record remain unknown.

### Evidence classes

1. **Direct user approval:** quoted numbered decision or the documented later “I approve” following the full AD-034/AD-035/POC package.
2. **Owner carry-forward:** the user's aggregate statement that AD-001–AD-033 are completed/approved, without an individual original quote.
3. **Reconstructed content:** the earlier conversation's analytical summary of a decision, with original A/B alternatives or approval text unavailable.
4. **Delegated selection:** an assistant choice made under the user's “I accept all your remaining recommendations”; not an individual direct approval.
5. **Proposed then superseded:** an older assistant-authored POC scenario or charter version followed by a separately approved final POC charter.

For convenience, evidence links point to the PR's **immutable candidate SHA**, not a potentially moving branch.

## Findings and exact corrections

### F01 — High — AD-001–AD-003 approval status sounds more complete than its evidence

**In PR:** [Decision register lines 5, 18–24, 78](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L5-L24) labels all AD-001–AD-035 an “approved architectural baseline” and calls AD-001–AD-003 “inherited approval.” It appropriately marks their subjects unavailable, but the overall approved-decision wording can still be read as if these three substantive decisions were independently verified.

**Original conversation evidence:** Jim's opening handoff stated, **“We have completed Architecture Decisions 1–33 and prepared EXP-001 through EXP-004 planning.”** It gave high-level approved constraints, not the individual texts, alternatives, decision titles, or assent for AD-001–003. [Discovery extraction lines 21–45](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L21-L45) states individual content/approval cannot be recovered and marks individual status unknown.

**Recommended correction:** Retain the original identifiers and the owner's aggregate carry-forward, but distinguish **“included in the owner-affirmed historical set”** from **“individual decision text and approval verified.”** In AD-001, AD-002, AD-003 rows state: *Subject, alternatives, rationale, individual approval evidence, requirements and supersession unknown; do not infer their content.* Do **not** create placeholder decision titles or guessed options. Add a recovery task for primary records.

### F02 — High — AD-004's offline-policy limits disappear from the operative index

**In PR:** [Register line 25](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L25) says only “Offline policy by profile and trust tier.” The charter covers strict expiry generally but does not retain the **organization policy ceiling** or **conservative default for customer-owned devices** as AD-004's specific choice.

**Original conversation evidence:** [Discovery extraction lines 48–56](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L48-L56) reports AD-004 Option C: per-profile configurable offline policy **constrained by organization policy**, with **conservative customer-owned defaults**. It explicitly states Options A/B and the original individual approval quote are unavailable. AD-014, AD-016 and AD-018 later **refine** this, without documented supersession.

**Recommended correction:** Add those two restrictions in an AD-004 detail note, label it *recovered analytical summary, owner carry-forward, not original wording*, and link it to AD-014/016/018, REQ-04/08 and POC-SCN-06/09. Do not weaken the separate strict-expiry/fail-closed requirements or invent Options A/B.

### F03 — High — AD-005/AD-006 identity and connection-authentication requirements are compressed away

**In PR:** [Register lines 26–27](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L26-L27) supplies subjects only. The canonical charter and POC criteria do not explicitly retain the approved flexibility of **user identity, application identity, or both**, and the range of **shared, user-specific, integrated, certificate and passwordless** connection-authentication strategies. The engineering kickoff mentions certificate/TLS verification but that is not a replacement for the AD-006 policy.

**Original conversation evidence:** [Discovery extraction AD-005 lines 58–66 and AD-006 lines 68–76](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L58-L76). Both are reported Option C approvals without surviving A/B alternatives or original direct approval text. AD-006 expressly **separates authentication strategies from secret stores**.

**Recommended correction:** Restore the recovered choices in the canonical AD-005 and AD-006 detail notes, including organization/profile authorization and independent secret-store boundaries. Trace to the security/authentication backlog and compatibility matrix, without claiming the POC must implement every strategy. Mark original alternatives and user approval transcript **unavailable**. Preserve AD-011–AD-013 as refinements, not replacements.

### F04 — Medium — AD-007A and AD-007B lose routing ownership and topology scope

**In PR:** [Register lines 28 and 58](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L28-L58) names the three subdecisions but gives no operative content. The charter preserves “provider-native-first” and defers advanced routing, but omits AD-007B's explicit initial and deferred topology boundaries.

**Original conversation evidence:** [Discovery extraction AD-007A lines 78–86](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L78-L86) reports **hybrid routing, provider-native first**, with library-managed selection where appropriate. [AD-007B lines 88–96](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L88-L96) reports initial **standalone, active/passive and primary/read-replica**, provider-coordinated **multi-primary only where supported**, and **independent databases/sharding deferred**. These are carry-forward summaries, not original verbatim options or approvals.

**Recommended correction:** Add separately linked **AD-007A** and **AD-007B** summary rows under AD-007, explicitly distinguishing initial topology, conditional multi-primary and deferred sharding. Link AD-023/024 as later refinements and EXP-003 SCN-001–005 as later scenarios, not original AD-007 acceptance scenarios.

### F05 — High — AD-007C's conditional raw-connection-string export qualification is missing

**In PR:** The [register AD-007 row](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L28), [architecture charter §2](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md#L26-L39), and [POC requirements](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/requirements/POC-001.md) emphasize managed typed leases but do not state that **raw connection-string export is an exceptional, explicitly authorized facility with disclosed limits**. No corresponding POC or deferred requirement explicitly tracks its constraints.

**Original conversation evidence:** [Discovery extraction AD-007C lines 98–106](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L98-L106): “Managed connections primary; raw connection string export only when explicitly authorized, with limitations disclosed.” It identifies the rationale as maintaining lifecycle, security and policy control, and says the earlier full alternatives/individual approval quote are unavailable. AD-028 later refines the normal path to typed managed leases; no express reversal of the exceptional export clause is recorded.

**Recommended correction:** Restore this limitation **verbatim as an analytical recovered summary**, not a new default API requirement. Record a deferred authorization/security review for any future export surface: independent explicit permission; no implication that the manager can govern externally opened connections or enforce revocation, audit or pool scope after export; protected/redacted handling. State that POC-001 does **not** implement this export path. Do not treat AD-028 as silently superseding AD-007C.

### F06 — Medium — AD-008's layered extensions and false-universal-API rationale are not identified

**In PR:** [Register line 29](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L29) records only “Layered capability API.” The charter correctly rejects a universal DbConnection model but does not explicitly attribute the **optional provider-specific operational extensions** to AD-008.

**Original conversation evidence:** [Discovery extraction AD-008 lines 108–116](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L108-L116) reports Option C: layered capability-based API, focused core, optional provider-specific operational extensions; its rationale is avoiding a false common operation model. Approval is only carried forward; A/B options unavailable. AD-028/029 refine it.

**Recommended correction:** State that optional, provider-specific operations live behind explicit capability/adapter extensions and must not leak a fabricated common API into the dependency-free core. Trace EXP-004 SCN-001–005/010, AD-028/029. Mark the historical rationale as reconstructed.

### F07 — Medium — EXP-001's seven themes are described as original “scenarios”

**In PR:** [Charter §5.1 line 86](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md#L84-L88) labels seven items “recoverable scenarios” while admitting original numbering is unavailable.

**Original conversation evidence:** [Discovery extraction lines 393–399](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L393-L399) says **“no full charter or independently verified scenario list supplied”** and calls the recoverable material **conceptual themes**, with original IDs and exact acceptance text missing. The owner's approvals of AD-009/010 do not authenticate a seven-scenario charter.

**Recommended correction:** In the **current register or an addendum** (preserving the historical charter snapshot unchanged), call these **seven retrospective test themes**, not confirmed original acceptance scenarios. Keep all seven planning topics, but mark original count, numbering and wording unavailable. Do not create EXP-001 SCN IDs.

### F08 — High — EXP-002 scenario IDs are linked to reconstructed statements without original evidence

**In PR:** [Charter §5.1 line 88](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md#L84-L90) presents “EXP-002 — approved 12 scenarios” followed by **SCN-01** through **SCN-12**, each paired with a specific summary. [Final-review extraction lines 129–135](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/final-architecture-review.md#L127-L135) repeats those mappings. Although §5.1 is titled “summaries, not verbatim,” readers could reasonably take the **ID-to-specific-assertion pairing** to be authenticated.

**Original conversation evidence:** Jim directly approved the **EXP-002 charter, four workstreams and acceptance scenarios** and kept it unexecuted: [discovery extraction lines 401–411](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L401-L411). Crucially, that source says a carry-forward summary reported **12 identifiers, SCN-01–SCN-12**, but **the complete texts and per-workstream mapping are not present**, warning not to reconstruct them as quotes.

**Recommended correction:** Preserve as verified facts: **four workstreams, 12 approved scenario identifiers, explicit user charter approval, unexecuted status**. Relabel the twelve displayed descriptions as **reconstructed test topics whose individual association with SCN-01..12 has not been verified**; do not attribute a particular assertion to an original SCN number without the actual charter. Retrieve primary EXP-002 charter before asserting one-to-one mapping. Keep the retrospective topics useful without presenting them as archival originals.

### F09 — Medium — EXP-004 final-charter approval provenance is flattened

**In PR:** [Charter lines 13–14 and 92](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md#L11-L15) treats EXP-001–004 together as approved original charters; EXP-004's 20 scenarios appear under the same “approved” rubric.

**Original conversation evidence:** [Discovery extraction lines 448–451 and 493–501](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md#L448-L451) states the four-workstream/20-scenario **EXP-004 planning charter was assembled after blanket acceptance** and **no separate user message explicitly approved the finalized charter at that point**. Jim's *later* opening in this conversation called EXP-004 the “public API/provider adapters/lifecycle consolidated planning charter, unexecuted” and described the planning as approved. That is meaningful later owner **carry-forward**, not evidence of an earlier specific approval event.

**Recommended correction:** Mark EXP-004 as **later owner-affirmed planning baseline, originally assistant-consolidated under delegation; no independent direct approval quote of its final 20-scenario text recovered**. Preserve the 20 actual scenario texts in the discovery archive and leave them unexecuted. Do not reclassify the user's blanket assent as a direct numbered charter approval.

### F10 — High — Two incompatible POC acceptance-ID namespaces lack an explicit crosswalk

**In PR:** [Recovery and compatibility extraction lines 182–210](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/recovery-and-compatibility.md#L182-L210) preserves **POC-001 through POC-021**, which were *assistant proposals, not approved in that conversation*. [Current requirements POC-SCN-01–21](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/requirements/POC-001.md#L1-L33) contains the *later approved* scheme. No prominent crosswalk says that similarly numbered criteria are **not equivalent**.

**Original conversation evidence:** The earlier source explicitly states **“These POC-### identifiers were assistant proposals in this conversation”**, and not EXP scenarios. For example **draft POC-015** described SQL Server restart; in the approved charter **POC-SCN-15** describes failure-domain isolation, while restart became **POC-SCN-18**. Draft **POC-018** covered a .NET Framework 4.8 consumer; final **POC-SCN-04** handles framework/OS compatibility. Draft **POC-017** contemplated an enabled optional coordinator; final **POC-SCN-20** permits only a test-harness scoped native ClearPool comparison and expressly defers coordinator implementation. Later user approval of the consolidated 21-scenario charter is documented in [final-review extraction lines 12–20](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/final-architecture-review.md#L12-L20).

**Recommended correction:** Add a short **identifier provenance and supersession note** to docs/requirements/POC-001.md: “POC-001..021 in the earlier recovery transcript were unapproved draft scenario labels. POC-SCN-01..21 are the later owner-approved requirements; equal numbers do not mean equivalent content.” Include a **topic-based, non-positional** draft-to-final crosswalk for at least the three examples above; mark draft coordinator-enabled operation as **superseded/removed from the initial POC** rather than “omitted,” and preserve the optional AD-035 design for later evidence-gated work.

### F11 — Medium — Recoverable direct decision rationale and approvals are hard to audit from the canonical register

**In PR:** [Register AD-009–033 lines 30–54](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/decisions/README.md#L30-L54) states evidence *types* but has no per-row link to a decision-specific original quote, known alternatives, rationale, or subsequent refinement.

**Original conversation evidence:** The [discovery extraction](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/architecture-discovery.md) preserves the user's explicit Option C approvals of **AD-009–AD-024** and **AD-026–AD-028**. It also distinguishes **AD-025**'s revised no-Polly option after the user's refusal of a Polly dependency and conversational “Agreed”; **AD-029**'s blanket “I accept all your remaining recommendations”; and **AD-030–AD-033** as assistant-selected under delegated autonomy, without individual direct approval. Where original Options A/B are not present, they remain unknown. The indexed statuses are largely **correct**, but the explanatory evidence is hard to locate.

**Recommended correction:** Add a per-decision **source anchor** and a small **alternatives/rationale/approval/supersession** field or companion evidence index rather than fabricating 35 complete ADRs. Where recoverable, preserve actual Option A/B/C descriptions (notably AD-025's coordination alternatives); elsewhere write **“alternatives not recovered.”** Preserve the distinctions among direct numbered approval, conversational assent, blanket acceptance and delegation. Link AD-034/AD-035's later explicit package approval to the final-review extraction rather than implying original standalone quoted assent.

## Confirmed alignment; do not turn these into false findings

1. **AD-034 compatibility is represented accurately.** The candidate restricts official initially qualified targets to **.NET Framework 4.8/Windows** and **.NET 10/Windows+Linux**, with **.NET 11 smoke qualification**, **.NET 8 non-gating best effort** and **no .NET 6 support promise**; it does not equate a netstandard2.0 package with actual provider/native/TLS/authentication support. See [charter lines 41–55](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md#L41-L55), [kickoff matrix](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/poc-001-engineering-kickoff-charter.md#L129-L141).
2. **AD-035 is approved as optional architecture, but not approved for POC implementation.** Native physical pooling stays with provider drivers; scoped SQL ClearPool is a **test-harness** comparison; shared physical pool identity, collateral effects and in-use operations are explicitly limited. The user's early “we should consider offering a connect pool manager if wanted” was exploration, whereas a **later “I approve”** after formal charter presentation approved AD-035. See [final-review extraction lines 38–50](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/conversations/final-architecture-review.md#L38-L50).
3. **Security threat-model qualifications survive.** The candidate does not promise perfect offline time/secret integrity on a fully hostile customer device or immediate offline revocation; it retains strict fail-closed handling when integrity/time is unverifiable, separate emergency audit, no unsafe command replay and no unsupported SFTP host-key trust. See [charter risk register](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/archive/charters/architecture-and-poc-execution-charter.md#L212-L228).
4. **The 21 approved final POC acceptance scenarios are present**, and no pass, provider qualification or experiment execution is falsely claimed in [POC requirements](https://github.com/infoconex/datasource-manager/blob/c3c691b42556261a9a73e5dab0bce788682956b9/docs/requirements/POC-001.md). The final 21 **replace the earlier proposed POC numbering**, not the separate EXP-001–004 charter obligations.
5. **Deferred is not dropped.** Full provider coverage, production credential rotation, emergency grants, extended topologies, active health, macOS qualification, and optional coordinator implementation remain deferred by new charter D-01..20 aliases. It would be a mistake to demand all of these in the smallest POC or declare their original requirements rejected.
6. **No individual original wording is recoverable for AD-001–003.** Their missing details should be recorded as documentation debt and actively sought from primary historical materials, not invented by inference from later architecture.

## Recommended remediation order for PR #2

| Priority | Corrections | Rationale |
| --- | --- | --- |
| **Before merge — provenance/security** | F01, F05, F08, F10 | Avoid unsupported ownership of missing decisions, prevent accidental unrestricted connection-string exposure, prevent fabricated EXP-002 ID mapping, and stop POC number collisions. |
| **Before declaring register authoritative** | F02, F03, F04, F06 | Restore recoverable early approved scope and qualifications with appropriate carry-forward labels. |
| **Before long-term archival sign-off** | F07, F09, F11 | Accurate experiment approval/scenario provenance and direct links to actual decision evidence. |

Prefer a **targeted amendment to the current register and POC requirements** plus a reconciliation note; keep the original dated archive snapshots immutable. If the project later obtains the actual original AD-001–008 proposals or EXP-002 charter, attach them as primary evidence and reconcile through review. Do not silently replace the archived historical record.

## Source inventory, status and limitations

Reviewed all eight changed files in PR #2 at the specified SHA: README.md; docs/decisions/README.md; docs/requirements/POC-001.md; docs/archive/conversations/architecture-discovery.md; docs/archive/conversations/recovery-and-compatibility.md; docs/archive/conversations/final-architecture-review.md; docs/archive/charters/architecture-and-poc-execution-charter.md; docs/archive/charters/poc-001-engineering-kickoff-charter.md. The latter five source documents are preserved historical records rather than necessarily current-status declarations.

The available conversation contains some exact user quotations and several **secondary analytical extractions**, not the entire earlier original proposal-and-approval transcript for AD-001–008. Therefore this report does **not** establish unknown Option A/B texts, assign absent historical FR/CAP identifiers, or invent original EXP-001/EXP-002 acceptance assertions. Several findings describe gaps in the **canonical usable index** even when an accurate, qualified summary exists in its archived source.

**No files were committed or pushed; no GitHub issues, PR comments, branches, implementations or experiments were created by this review.**