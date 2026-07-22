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

Audit Logging
        ⏳
```

**Next Phase:** Phase 5 — Relational Database Design

---

# Immediate Objective

Implement the Deposit business operation using the established architecture.

The focus is no longer on building architecture.

The focus is now on modeling business operations that are:

- Atomic
- Transaction-safe
- Business-oriented
- Efficient
- Maintainable

Continue following the existing architecture while leveraging PostgreSQL to execute complete business operations.

---

# Current Learning Focus

## Business Operation Modeling

Every feature begins with the business requirement.

Development workflow:

```text
Business Requirement
        ↓
Business Workflow
        ↓
Business Rules
        ↓
Domain Decision
        ↓
Application Orchestration
        ↓
Repository Contract
        ↓
SQL Design
        ↓
Infrastructure Implementation
        ↓
HTTP API
```

Current milestones:

- ✅ Account Number Generation implemented as a Domain Service.
- ✅ Application Service orchestrates account creation.
- ✅ Create Checking Account implemented.
- ✅ Create Savings Account implemented.
- ✅ Database constraints enforce one Checking Account per Account.
- ✅ Database constraints enforce one Savings Account per Account.
- ✅ Global exception handling maps PostgreSQL exceptions to HTTP responses.
- ✅ Transaction History (Ledger) schema designed.
- ✅ Audit Log schema designed using PostgreSQL ENUM, JSONB and INET types.

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

For every feature, continue asking:

- What business problem is being solved?
- What is the business workflow?
- Which layer owns this responsibility?
- Should this rule exist in the Domain or be enforced by PostgreSQL?
- Does this operation require a transaction?
- Can this business operation be executed efficiently in a single SQL statement?
- Which constraints protect the business invariant?
- Is the persistence implementation simple, efficient and maintainable?

---

# Next Feature — Deposit

Primary objective:

Implement Deposit as a complete banking business operation.

Business workflow:

```text
Receive Deposit Request
        ↓
Locate Account
        ↓
Acquire Row Lock (FOR UPDATE)
        ↓
Validate Business Rules
        ↓
Calculate New Balance
        ↓
Record Transaction History
        ↓
Update Account Balance
        ↓
Commit Transaction
        ↓
Return Result
```

Primary learning goals:

- Row-level locking (`FOR UPDATE`)
- Transaction consistency
- Race condition prevention
- Atomic business operations
- Ledger recording
- Balance updates
- Exception handling
- Single SQL statement business operations

The objective is to understand how relational databases guarantee consistency during concurrent financial operations while keeping business rules properly separated from persistence concerns.