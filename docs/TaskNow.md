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
    │       🚧
    ├── Row Locking (FOR UPDATE)
    │       ✅
    ├── Balance Update CTE      
    │       ✅
    ├── Transaction History CTE
    │       ✅
    ├── Audit Log CTE
    │       ⏳
    ├── Repository
    │       ✅
    ├── Application Service
    │       ✅
    ├── Controller
    │       ✅
    ├── Higher-Order Transaction Executor
    │       ✅
    ├── DTO Mapping
    │       ✅
    └── Testing
            🚧

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

Complete the Deposit business operation as a complete banking transaction.

Remaining work:

- Finish Transaction History recording.
- Finish Audit Log recording.
- Return the final business response.
- Verify rollback behavior.
- Test concurrent deposits.
- Apply the same engineering pattern to Withdraw.

The architecture is now stable.

The focus is engineering complete business operations rather than building new infrastructure.

---

# Current Engineering Focus

## Business Operation Engineering

Every feature follows the same engineering pipeline.

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

Implementation follows the business process—not the other way around.

---

# Current Persistence Philosophy

Repositories are persistence orchestrators.

Repository responsibilities:

- Choose SQL
- Prepare parameters
- Execute SQL
- Return business result

Repositories no longer manage:

- Database connections
- Transaction creation
- Commit
- Rollback

These concerns have been extracted into reusable Infrastructure components.

---

# Repository Execution Architecture

Current persistence execution flow:

```text
Repository

↓

ExecuteTransactionAsync()

↓

Higher-Order Function

↓

Connection Factory

↓

Database Connection

↓

Database Transaction

↓

Dapper

↓

PostgreSQL
```

Infrastructure now owns:

- Connection lifecycle
- Transaction lifecycle
- Commit
- Rollback
- Exception propagation

Repositories now contain almost exclusively business-specific persistence logic.

---

# Current SQL Philosophy

Whenever practical, an entire banking business operation should execute as:

```text
One Transaction

↓

One SQL Statement

↓

Multiple CTEs

↓

One Database Round Trip
```

Current Deposit implementation already includes:

- Account lookup
- Row locking
- Balance update
- Returning business result

Upcoming CTEs:

- Transaction History
- Audit Log

The objective is to leverage PostgreSQL as a relational engine rather than treating it as simple storage.

---

# Current Learning Focus

## Persistence Engineering

Current concepts:

- Repository pattern
- Repository executor
- Higher-Order Functions
- Delegates
- Func<>
- Lambda expressions
- Transaction abstraction
- Parameterized SQL
- Dapper mapping
- Record materialization

---

## Business Operations Engineering

Current concepts:

- Business workflow modeling
- Atomic operations
- Ledger architecture
- Audit logging
- Separation of Domain and Persistence
- Business-oriented SQL design

---

## PostgreSQL

Current concepts:

- Common Table Expressions (CTEs)
- FOR UPDATE
- Row-level locking
- UPDATE ... RETURNING
- Transactions
- Atomic SQL workflows
- Race condition prevention

Major realization:

A database transaction is initiated by the application but executed entirely by PostgreSQL.

The application defines the transaction boundary.

PostgreSQL guarantees atomic execution within that boundary.

---

## C# Language Concepts

Recently learned and applied:

- Higher-Order Functions
- Delegates
- `Func<>`
- Lambda Expressions
- Passing behavior as parameters
- Reusable transaction execution
- Separation of reusable infrastructure from business logic

Major realization:

LINQ did not introduce lambda expressions or Higher-Order Functions.

They are C# language features that LINQ heavily utilizes.

---

# Current Engineering Checklist

Continue asking for every feature:

## Business

- What business problem is being solved?
- What is the business workflow?
- Which rules belong in the Domain?

---

## Persistence

- Which invariants belong in PostgreSQL?
- Does this operation require a transaction?
- Can PostgreSQL execute more of the workflow?
- Can the operation execute in one SQL statement?
- Can database round trips be reduced?

---

## Architecture

- Which layer owns this responsibility?
- Is Infrastructure reusable?
- Is the repository only orchestrating persistence?
- Is the solution simple, maintainable and scalable?

---

# Next Milestones

## Deposit

1. Finish Transaction History CTE.
2. Finish Audit Log CTE.
3. Return complete business response.
4. Test successful deposits.
5. Test invalid deposits.
6. Test concurrent deposits.
7. Verify rollback behavior.

---

## Withdraw

Implement using the same engineering pattern:

- Row locking
- Business validation
- Balance update
- Ledger recording
- Audit logging
- Single SQL statement
- Single transaction

---

## Transfer

Implement as the first multi-account atomic transaction:

- Lock sender
- Lock receiver
- Validate funds
- Debit sender
- Credit receiver
- Record two ledger entries
- Record audit log
- Commit atomically

---

# Current Learning Outcome

Recent milestones achieved:

- ✅ Transitioned from CRUD repositories to complete business operation modeling.
- ✅ Designed Deposit as a PostgreSQL workflow instead of multiple CRUD operations.
- ✅ Implemented reusable transaction management using Higher-Order Functions.
- ✅ Connected Delegates, `Func<>`, Lambda Expressions and Higher-Order Functions conceptually.
- ✅ Understood row-level locking using `FOR UPDATE`.
- ✅ Successfully implemented and tested the first end-to-end Deposit operation.
- ✅ Successfully mapped SQL results directly into immutable DTOs using Dapper.
- ✅ Learned to diagnose framework-layer issues (Controller, Dapper, SQL) independently.
- ✅ Shifted from thinking in CRUD operations toward transaction-safe business workflows.
- ✅ Began treating PostgreSQL as an execution engine rather than only a persistence layer.

The current objective remains completing the Deposit feature before implementing Withdraw, Transfer, Transaction History, and full Audit Logging.