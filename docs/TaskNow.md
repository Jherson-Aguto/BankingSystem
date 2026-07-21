# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Infrastructure & Persistence Engineering 🚧 (Feature Implementation)

**Architecture Status:** ✅ Stable

**Current Feature:** Banking Operations

Current implementation:

```text
Customer Profile
        ✅

Create Account
        ✅

Create Checking Account
        ⏳

Create Savings Account
        ⏳

Deposit
        ⏳

Withdraw
        ⏳

Transfer
        ⏳

Transaction History
        ⏳
```

**Next Phase:** Phase 5 — Relational Database Design

---

# Immediate Objective

Continue implementing the remaining banking operations using the existing architecture.

The primary objective is no longer to redesign the Infrastructure layer.

Instead, reinforce the engineering concepts already learned by repeatedly applying them to real business operations.

Every new feature should strengthen understanding of:

- Repository design
- Use case orchestration
- Domain rules
- Transaction boundaries
- SQL design
- API design
- Infrastructure responsibilities

rather than introducing new architectural patterns.

---

# Current Engineering Focus

The architecture is now considered stable.

Continue applying the established request flow:

```text
HTTP Request
        ↓
Controller
        ↓
Application Service
        ↓
Domain
        ↓
Repository Interface
        ↓
Infrastructure Repository
        ↓
Dapper
        ↓
PostgreSQL
```

While implementing each feature, continue evaluating:

- Which layer owns this responsibility?
- Does this belong in the Domain, Application, Infrastructure, or API?
- Does this operation require a transaction?
- Is the SQL efficient and business-oriented?
- Are business invariants preserved?