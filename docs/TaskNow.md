# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Persistence & Business Operations Engineering 🚧

**Architecture Status:** ✅ Stable

**Current Feature:** Business Operation Validation & Concurrency Testing

**Next Phase:** Phase 5 — Relational Database Design

---

# Current Feature Progress

```text
Customer Profile
        ✅

Register Customer
    ├── Customer Registration
    │       ✅
    ├── Private Information
    │       ✅
    └── Audit Logging
            ✅

Create Account
        ✅
    ├── Account Number Generation
    │       ✅ Domain Service
    ├── Account Persistence
    │       ✅
    └── Audit Logging
            ✅

Create Checking Account
        ✅
    └── Audit Logging
            ✅

Create Savings Account
        ✅
    └── Audit Logging
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
    │       ✅
    ├── Audit Log CTE
    │       ✅
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
    └── Business Response
            ✅

Transfer
    ├── Multi-Account Transaction
    │       ✅
    ├── Dual Row Locking
    │       ✅
    ├── Atomic Debit/Credit
    │       ✅
    ├── Dual Transaction History
    │       ✅
    ├── Audit Logging
    │       ✅
    ├── Repository
    │       ✅
    ├── Application Service
    │       ✅
    ├── Controller
    │       ✅
    ├── Dapper Multi-Mapping
    │       ✅
    └── Business Response
            ✅

Transaction History
        ✅ Infrastructure Implemented

Audit Logging
        ✅ Infrastructure Implemented

Domain Testing
    ├── Account Number Generator
    │       ✅
    ├── Reference Number Generator
    │       ✅
    └── Concurrent Uniqueness
            ✅
```

---

# Immediate Objective

Validate and harden the completed banking operations.

Current priorities:

- Verify Deposit rollback behavior.
- Verify Transfer rollback behavior.
- Stress-test concurrent Deposits.
- Stress-test concurrent Transfers.
- Improve API responses where appropriate.
- Refactor SQL if simplification opportunities are discovered.

The architectural foundation and core banking operations are now considered complete for Phase 4B.

Development has shifted from implementation toward validation, robustness, and engineering refinement.

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

- Select SQL
- Prepare parameters
- Execute SQL
- Materialize business results

Repositories no longer manage:

- Connection creation
- Transaction creation
- Commit
- Rollback

Those responsibilities belong to reusable Infrastructure components.

---

# Repository Execution Architecture

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

Infrastructure owns:

- Connection lifecycle
- Transaction lifecycle
- Commit
- Rollback
- Exception propagation

Repositories contain almost exclusively business-specific persistence logic.

---

# Current SQL Philosophy

Whenever practical, one banking business operation executes as:

```text
One Transaction

↓

One SQL Statement

↓

Multiple Writable CTEs

↓

One Database Round Trip
```

Current business operations leverage PostgreSQL to perform:

- Row locking
- Business validation
- Balance updates
- Transaction history
- Audit logging
- Business result projection

The database acts as an execution engine rather than passive storage.

---

# Current Learning Focus

## Persistence Engineering

Current concepts:

- Repository Pattern
- Repository Executor
- Higher-Order Functions
- Delegates
- Func<>
- Lambda Expressions
- Transaction abstraction
- Parameterized SQL
- Dapper materialization
- Record mapping
- Dapper multi-mapping
- splitOn
- SQL result projection

---

## Business Operations Engineering

Current concepts:

- Business workflow modeling
- Atomic operations
- Ledger architecture
- Audit logging
- Multi-account transactions
- Separation of Domain and Persistence
- Business-oriented SQL design

---

## PostgreSQL

Current concepts:

- Common Table Expressions (CTEs)
- Writable CTE workflows
- FOR UPDATE
- Row-level locking
- UPDATE ... RETURNING
- INSERT ... RETURNING
- Atomic SQL execution
- Transaction boundaries
- Race condition prevention
- JSONB audit snapshots
- PostgreSQL ENUM integration

Major realization:

A transaction boundary is created by the application, while PostgreSQL guarantees atomic execution within that boundary.

---

## C# Language Concepts

Recently learned and applied:

- Higher-Order Functions
- Delegates
- Func<>
- Lambda Expressions
- Reusable transaction execution
- Dapper multi-mapping
- Generic overload resolution
- Immutable DTO projection
- Basic xUnit fundamentals
- Parallel execution testing

Major realizations:

- LINQ did not introduce lambda expressions or Higher-Order Functions.
- xUnit verifies software behavior rather than serving as the learning objective.
- Dapper maps SQL result sets based entirely on column order and aliases.

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
- Can the operation execute as one SQL statement?
- Can database round trips be reduced?

---

## Architecture

- Which layer owns this responsibility?
- Is Infrastructure reusable?
- Is the repository orchestrating persistence only?
- Is the implementation simple, maintainable, and scalable?

---

# Next Milestones

## Validation

- Verify rollback scenarios.
- Verify concurrent operations.
- Validate transaction consistency.
- Validate audit integrity.
- Validate ledger consistency.

---

## Phase 5 Preparation

After validation is complete:

- Begin Relational Database Design.
- Review normalization.
- Improve indexing strategy.
- Refine ERD.
- Evaluate schema evolution opportunities.

---

# Current Learning Outcome

Recent milestones achieved:

- ✅ Transitioned from CRUD repositories to complete business operation modeling.
- ✅ Implemented Deposit as a complete PostgreSQL workflow.
- ✅ Implemented Transfer as a multi-account atomic transaction.
- ✅ Built reusable transaction execution using Higher-Order Functions.
- ✅ Connected Delegates, Func<>, Lambda Expressions, and Higher-Order Functions conceptually.
- ✅ Understood row-level locking using FOR UPDATE.
- ✅ Implemented Transaction History using writable CTEs.
- ✅ Implemented Audit Logging directly inside SQL workflows.
- ✅ Implemented Dapper multi-mapping for composite business responses.
- ✅ Learned to diagnose SQL, Dapper, Npgsql, and framework-level issues independently.
- ✅ Began treating PostgreSQL as an execution engine rather than only a persistence store.
- ✅ Built and validated Domain Services for account/reference number generation.
- ✅ Created initial xUnit tests covering uniqueness, concurrency, and validation.

The implementation phase of the core banking operations is now complete. The remaining work for Phase 4B focuses on validation, concurrency testing, rollback verification, and engineering refinement before progressing to Relational Database Design.