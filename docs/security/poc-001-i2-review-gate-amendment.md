# POC-001 I2 — prospective security review-gate amendment

**Decision date:** November 16, 2026 (Pacific)  
**Approver:** Project Owner  
**Disposition:** Owner-approved, narrowly scoped replacement of the **pre-I2 independent human signoff prerequisite**; documentation proposed for integration.  
**Scope:** I2 capability and admission skeleton only. **Not** permission to begin I2, merge a PR, implement real adapters or enable production acquisition.

## Approval and chronology

The original POC-001 [engineering kickoff charter](../archive/charters/poc-001-engineering-kickoff-charter.md) required independent human threat-model review and signoff in I0. The later [I1-only gate adjustment](https://github.com/infoconex/datasource-manager/issues/11) expressly retained that requirement before I2. Both records remain historically accurate and are **not** retroactively rewritten.

**New owner authorization (November 16, 2026):** "I explicitly approve the proposed revised Data Source Manager security gate, replacing mandatory independent human signoff before I2 with documented Project Owner risk acceptance under all six stated conditions. Use only 'Project Owner' as the approver. Document the amendment in one issue and PR. Do not merge or begin I2."

This supersedes **only** the pre-I2 independent-human-review prerequisite prospectively. It does not claim qualified independent human review occurred. The owner accepts the assurance risk of proceeding with a restricted, test-only I2 without that additional review; the owner does **not** accept bypasses of mandatory security properties or all findings in the adversarial assessment.

## Six binding conditions

1. **Review disposition:** Document Project Owner risk acceptance in place of mandatory independent human signoff **before I2**, without attributing independent reviewer approval.
2. **Adversarial input:** Retain the separately conducted, unpersonalized **AI-generated** adversarial assessment (November 15, 2026; verdict: "Safe only after specified corrections") as supporting risk evidence, **not** independent human signoff or executed test evidence.
3. **Restricted, fail-closed I2:** Implement only controlled test registration, versioned capability states, safe results and lease/admission contracts. **No production-authorized acquisitions, real provider adapters, dynamic/ambient discovery of untrusted providers, or bypass of required authorization.** Positive lease examples must remain isolated test-only compositions; registered adapters alone never confer caller permission.
4. **Security-negative evidence:** Implement and execute deterministic negative tests before I2 exit, including untrusted/unknown/duplicate registration, no ambient loading, unknown security-critical versions, unavailable/unauthorized and not-evaluated states, no accidental success, capability/resource mismatch, redacted failures, and safe cancellation/disposal behavior. The assessment's `SEC-I2-*` identifiers are *proposed test names*, not historical or renumbered `POC-SCN-*` criteria.
5. **Later reassessment:** Reassess the threat model and security evidence **before enabling real provider acquisition**. Recommend qualified independent human review before production release; this is **not** a claim of completed signoff. The kickoff charter's separate **I6 independent-reviewer and owner-decision obligation remains unchanged**.
6. **Unchanged safeguards:** Retain all other approved ADRs, security requirements, provider/dependency qualification gates, POC-001 scenario wording and completion increments. In particular, no weakened authorization, secret protection, endpoint trust, offline expiry, audit, redaction, disposal, retry or tenant-isolation obligation is authorized.

## Evidence and boundaries

- **Current baseline when amended:** `3d3b7139549f3ce373e2b49c85fedbb80033f2f7` (merged architecture clarification, PR #14).
- **Threat model:** [security trust-boundary preflight](threat-model.md), still prospective; its enumerated attacker/trust boundaries and fail-closed negative checks remain applicable.
- **Adversarial review:** Owner-supplied "Independent Adversarial Security Assessment — Data Source Manager, POC-001, I2" dated November 15, 2026; 20 prospective findings. It did not run tests, and explicitly disclaimed human signoff. The review itself is not asserted to be an immutable, externally signed artifact in this repository.
- **Residual assurance risk accepted:** Without independent human review before I2, architectural misunderstandings or gaps may remain undetected. Mitigation is strict no-production-acquisition scope, security-negative tests, mandatory review of I2 changes, CI/static analysis and later pre-provider reassessment.
- **Adversarial finding disposition:** F-01's pre-I2 *human reviewer* governance condition is prospectively replaced **only for I2**. Findings F-02/03/05/06/07/09/10/11/12/16/17/18 require I2 design constraints and applicable tests; F-04/08/13/14/15/19/20 retain their later staged qualification and must not be declared resolved by this amendment. These are review recommendations, not verified exploit findings or additions to approved POC identifiers.
- **Not accepted:** A successful production acquisition path before the required security boundary exists; unverifiable required capabilities or policies; arbitrary provider activation; undocumented credential exposure; false claims of executed scenarios or independent review.

**Release and implementation gates:** This documentation decision is **not** a merge, I2 engineering kickoff, implementation authorization, release, or publication approval. An issue-specific I2 authorization is still required; POC-SCN-03 requires actual evidence, POC-SCN-02 remains incomplete until I4, and later security increments retain their own verification requirements.
