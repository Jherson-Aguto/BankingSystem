# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Persistence & Business Operations Engineering 🚧

**Architecture Status:** ✅ Stable

**Current Feature:** Deposit (Finalization)

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

Withdraw
        ⏳

Transfer
        ⏳

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

Complete the remaining banking business operations.

Current priorities:

- Verify Deposit rollback scenarios.
- Verify concurrent Deposit behavior.
- Implement Withdraw using the same engineering pattern.
- Implement Transfer as the first multi-account atomic transaction.

The architectural foundation is now considered stable.

Current development focuses on completing business workflows rather than introducing new infrastructure.

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

Multiple CTEs

↓

One Database Round Trip
```

Deposit now performs:

- Account lookup
- Row locking
- Balance update
- Transaction history recording
- Audit logging
- Business result projection

The objective is to leverage PostgreSQL as an execution engine instead of treating it as simple storage.

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
- Writable CTE workflows
- Transactions
- Atomic SQL execution
- Race condition prevention
- JSONB audit snapshots
- PostgreSQL ENUM integration

Major realization:

A transaction boundary is created by the application, while PostgreSQL guarantees atomic execution inside that boundary.

---

## C# Language Concepts

Recently learned and applied:

- Higher-Order Functions
- Delegates
- Func<>
- Lambda Expressions
- Reusable transaction execution
- Separation of reusable Infrastructure behavior
- Basic xUnit fundamentals
- Parallel execution testing

Major realizations:

- LINQ did not introduce lambda expressions or Higher-Order Functions.
- xUnit is a tool for verifying software behavior—not the goal itself.

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

## Deposit

1. Verify rollback behavior.
2. Stress-test concurrent deposits.
3. Refine API responses if necessary.

---

## Withdraw

Implement using the established engineering pattern:

- Row locking
- Business validation
- Balance update
- Transaction history
- Audit logging
- Single SQL statement
- Single transaction

---

## Transfer

Implement the first true multi-account atomic workflow:

- Lock sender
- Lock receiver
- Validate available funds
- Debit sender
- Credit receiver
- Record two transaction history entries
- Record audit log
- Commit atomically

---

# Current Learning Outcome

Recent milestones achieved:

- ✅ Transitioned from CRUD repositories to complete business operation modeling.
- ✅ Designed Deposit as a PostgreSQL workflow instead of multiple CRUD operations.
- ✅ Implemented reusable transaction execution using Higher-Order Functions.
- ✅ Connected Delegates, Func<>, Lambda Expressions, and Higher-Order Functions conceptually.
- ✅ Understood row-level locking using FOR UPDATE.
- ✅ Implemented Transaction History recording using writable CTEs.
- ✅ Implemented Audit Logging directly inside SQL workflows.
- ✅ Implemented audit logging for:
  - Customer Registration
  - Customer Private Information
  - Account Creation
  - Checking Account Creation
  - Savings Account Creation
  - Deposit
- ✅ Successfully mapped SQL results into immutable DTOs using Dapper.
- ✅ Learned to diagnose framework-layer issues independently (Controller, Dapper, SQL, Npgsql).
- ✅ Began treating PostgreSQL as an execution engine instead of only a persistence store.
- ✅ Built and validated a Domain Service for account/reference number generation.
- ✅ Created initial xUnit tests covering:
  - Unique account numbers
  - Unique reference numbers
  - Concurrent generation
  - Input validation

The current objective is to complete Withdraw and Transfer using the same transaction-safe engineering approach before moving into Relational Database Design.