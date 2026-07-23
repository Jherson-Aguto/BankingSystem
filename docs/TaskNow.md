# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Persistence & Business Operations Engineering 🚧

**Architecture Status:** ✅ Stable

**Current Feature:** Deposit

**Next Phase:** Phase 5 — Relational Database Design

---

# Current Feature Progress

```text
Customer Profile
        ✅

Create Account
        ✅
    ├── Account Number Generation
    │       ✅ Domain Service
    └── Account Persistence
            ✅

Create Checking Account
        ✅

Create Savings Account
        ✅

Deposit
    ├── Business Workflow
    │       ✅
    ├── SQL Workflow
    │       ✅
    ├── Row Locking (FOR UPDATE)
    │       ✅
    ├── Balance Update CTE
    │       ✅
    ├── Transaction History CTE
    │       ⏳
    ├── Audit Log CTE
    │       ⏳
    ├── Repository
    │       ⏳
    ├── Application Service
    │       ⏳
    ├── Controller
    │       ⏳
    └── Testing
            ⏳

Withdraw
        ⏳

Transfer
        ⏳

Transaction History
        🚧 Schema Complete

Audit Logging
        🚧 Schema Complete
```

---

# Immediate Objective

Complete the Deposit business operation end-to-end using the established architecture.

Current priorities:

- Complete the remaining SQL workflow.
- Finish repository implementation.
- Integrate the Application layer.
- Expose the HTTP endpoint.
- Validate transactional correctness.
- Test concurrent deposits.

The architectural foundation is complete.

The current focus is engineering complete, transaction-safe business operations.

---

# Current Engineering Focus

## Business Operation Engineering

Every feature should follow the same development process.

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

The objective is to solve the business problem before writing implementation code.

---

# Current Persistence Philosophy

Repositories should focus only on persistence orchestration.

Responsibilities:

- Select SQL
- Supply parameters
- Execute SQL
- Return results

Repositories should not own:

- Connection creation
- Transaction lifecycle
- Commit
- Rollback

These responsibilities belong to reusable Infrastructure components.

---

# Repository Execution Flow

Current repository architecture:

```text
Repository

↓

ExecuteTransactionAsync()

↓

Higher-Order Function

↓

Connection

↓

Transaction

↓

Dapper

↓

PostgreSQL
```

Infrastructure owns:

- Connection lifecycle
- Transaction lifecycle
- Commit
- Rollback
- Exception propagation

Repositories supply only the business-specific SQL operation.

---

# Current SQL Philosophy

Whenever appropriate, a complete business operation should execute as:

```text
One Transaction

↓

One SQL Statement

↓

Multiple CTEs

↓

One Database Round Trip
```

PostgreSQL should perform relational work whenever possible.

The Application layer remains focused on orchestration rather than persistence logic.

---

# Current Learning Focus

Current concepts being reinforced:

## Persistence Engineering

- Repository design
- Repository Executor
- Higher-Order Functions
- SQL organization
- Parameterized SQL
- Transaction management

---

## Business Operations Engineering

- Business workflow modeling
- Atomic operations
- Transaction consistency
- Ledger-based accounting
- Audit logging
- Separation of business rules and persistence

---

## PostgreSQL

Current focus:

- Common Table Expressions (CTEs)
- `FOR UPDATE`
- Row-level locking
- Transactions
- Race condition prevention
- Atomic SQL workflows

Major realization:

A database transaction begins in C# but is executed by PostgreSQL.

The SQL statement runs inside the transaction boundary established by the application.

---

# Current Engineering Checklist

Continue asking these questions for every feature:

## Business

- What business problem is being solved?
- What is the complete business workflow?
- Which business rules belong in the Domain?

---

## Persistence

- Which invariants should PostgreSQL enforce?
- Does this require a transaction?
- Can PostgreSQL perform more of the work?
- Can this operation execute in one SQL statement?
- Can database round trips be reduced?

---

## Architecture

- Which layer owns this responsibility?
- Is the repository only orchestrating persistence?
- Is Infrastructure reusable?
- Is the implementation simple, maintainable and scalable?

---

# Next Milestones

Complete Deposit:

1. Finish `updated_balance` workflow.
2. Insert transaction history.
3. Insert audit log.
4. Return final result.
5. Finish repository.
6. Finish application service.
7. Finish controller.
8. Test successful deposits.
9. Test concurrent deposits.
10. Validate rollback behavior.

---

# Current Learning Outcome

Recent milestones achieved:

- ✅ Transitioned from CRUD repositories to business operation modeling.
- ✅ Implemented reusable transaction management using Higher-Order Functions.
- ✅ Connected Delegates, `Func<>`, Lambda Expressions and Higher-Order Functions conceptually.
- ✅ Understood row-level locking using `FOR UPDATE`.
- ✅ Designed immutable ledger architecture.
- ✅ Adopted one SQL statement per business operation when appropriate.
- ✅ Shifted from framework-focused development toward software engineering patterns.

Current priority remains completing the Deposit feature before continuing with Withdraw, Transfer and full audit logging integration.