# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Infrastructure & Persistence Engineering 🚧 (Business Operations)

**Architecture Status:** ✅ Stable

**Current Feature:** Deposit

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
        ✅

Create Savings Account
        ✅

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

Implement the remaining banking operations using the established architecture.

The architectural foundation is now considered stable.

Current development should focus on modeling business behavior rather than introducing new architectural concepts.

Each completed feature should reinforce:

- Domain modeling
- Business rules
- Application orchestration
- Repository design
- Transaction boundaries
- SQL design
- API design
- Exception handling

---

# Current Learning Focus

## Business Operation Modeling

Development begins with understanding the business process before writing code.

Follow this workflow:

```text
Business Requirement
        ↓
Business Workflow
        ↓
Business Rules
        ↓
Domain Model
        ↓
Application Service
        ↓
Repository Design
        ↓
Infrastructure Implementation
        ↓
HTTP API
```

Current milestones:

- ✅ Account Number Generation implemented as a Domain Service.
- ✅ Application Service orchestrates account creation.
- ✅ Checking and Savings account creation implemented.
- ✅ Database constraints enforce one Checking and one Savings account per Account.
- ✅ Global exception handling translates infrastructure failures into appropriate HTTP responses.

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

For every new feature, continue asking:

- What business problem is being solved?
- What is the business workflow?
- Which layer owns this responsibility?
- Should this rule exist in the Domain or be enforced by the database?
- Does this operation require a transaction?
- Which database constraints protect this invariant?
- Is the persistence implementation simple, efficient, and maintainable?

---

# Next Feature — Deposit

Primary objective:

Model the Deposit operation as a complete business use case.

Focus on:

- Deposit workflow
- Account validation
- Transaction recording
- Balance updates
- Transaction boundaries
- Business invariants
- Repository coordination