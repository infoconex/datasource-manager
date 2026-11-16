# Security trust-boundary preflight (proposed)

**Status:** Engineering readiness description only; no credential, authorization, connection, grant, lease or audit behavior is implemented here. The original independent human review prerequisite **before I2** was prospectively replaced by [Project Owner risk acceptance under six binding conditions](poc-001-i2-review-gate-amendment.md) on November 16, 2026. No independent human signoff is asserted. Later security controls and evidence gates remain in effect.

## Trust boundaries

1. **Caller and identity:** tenant, organization, workload and/or user assertions must be checked independently of a profile identifier; a caller-supplied identifier is not an authorization decision (AD-005, AD-029).
2. **Configuration and credentials:** multiple separately owned profiles and credential stores must not collapse into one persistence or security boundary. Centrally managed, locally managed, managed-device and customer-owned contexts have distinct protection and override policies (AD-002, AD-003, AD-009–013).
3. **Online control plane and offline client:** cached configuration is not perpetual authorization. A new central revocation cannot reach a truly disconnected client; time-limited signed grants require verifiable state and a fail-closed response when that state is suspect (AD-014, AD-018).
4. **Provider adapter and destination:** explicit trusted adapter registration, capability checks, TLS and host-key trust are independent of endpoint reachability. Missing mandatory security capabilities deny acquisition, not an opportunistic fallback (AD-006, AD-019, AD-029–032).
5. **Managed lease and provider-native resources:** disposal or cancellation cannot promise to stop remote operations; raw connection-string export loses managed lifecycle control; native SQL pools can share a physical scope beyond a logical tenant label (AD-007C, AD-015, AD-028, AD-035).
6. **Security audit versus diagnostics:** required durable audit must succeed before eligible emergency access. Logs, metrics and traces exclude secrets and sensitive identifiers by default and cannot replace security audit (AD-017, AD-026).

## Non-negotiable negative checks for later implementation

- Unknown or unauthorized capability; cross-tenant profile; invalid signature, stale revision or prohibited override.
- Expired/rollback-suspect grant; untrusted local clock; lost device protection context; changed SFTP host key.
- Audit persistence failure for an audit-required action; accidental credential/connection-string disclosure in exceptions, metrics or logs.
- Authentication, TLS or policy failure accidentally treated as transient; unsafe SQL/SMTP/upload/transaction replay after uncertain outcome.

## Explicit non-guarantees and review gate

Absolute trusted time and secret protection **cannot** be guaranteed on a fully compromised offline host. A disconnected host cannot learn an unknown new revocation, and existing provider sessions may outlive credential revocation. These limitations must be reported, not hidden behind tests or abstract interfaces. Before affected functionality is enabled, record device/trusted-time/OS assumptions, approve negative scenarios and minimum evidence, and apply the relevant [prospective I2 gate amendment](poc-001-i2-review-gate-amendment.md) or later security reassessment. Independent human review is recommended before production release; no such review is claimed here. Failure to obtain a required security property is a stop condition, never permission to weaken security quietly.
