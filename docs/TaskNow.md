# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Infrastructure & Persistence Engineering 🚧 (Feature Implementation)

**Architecture Status:** ✅ Stable

**Current Feature:** Create Account

Current implementation:

```text
Customer Profile
        ✅

Create Account
        ✅
    ├── Account Number Generation
    │       ✅ (Domain Service)
    └── Account Persistence
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

Implement the remaining banking operations using the existing architecture.

The architectural foundation is considered stable.

The current objective is to strengthen software engineering skills by modeling business operations and implementing them without introducing new architectural patterns.

Each feature should reinforce:

- Domain modeling
- Business rules
- Repository design
- Use case orchestration
- Transaction boundaries
- SQL design
- API design

---

# Current Learning Focus

## Domain Modeling

Before implementing a feature, identify the business workflow first.

Development should begin with the domain rather than the implementation.

Typical workflow:

```text
Business Requirement
        ↓
Business Workflow
        ↓
Business Rules
        ↓
Domain Model
        ↓
Application Orchestration
        ↓
Repository Design
        ↓
Infrastructure Implementation
```

Current milestone:

- ✅ Account Number Generation implemented as a Domain Service.
- ✅ Application Service orchestrates the account creation workflow by invoking the Domain Service.
- ⏳ Continue applying this approach to future banking operations.

---

# Current Engineering Focus

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

For every new feature, continue evaluating:

- What business problem is being solved?
- Which layer owns this responsibility?
- Does this belong in the Domain, Application, Infrastructure, or API?
- Does this operation require a transaction?
- Are business invariants preserved?
- Is the persistence implementation efficient and maintainable?