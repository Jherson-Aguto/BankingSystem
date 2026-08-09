# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 8 — Performance Engineering 🚧

**Architecture Status:** ✅ Stable

**Security Engineering:** ✅ Complete

**Previous Phase:** Phase 7 — Security Engineering ✅

**Current Focus:** Performance Engineering and measurable backend optimization

**Performance Status:** 🚧 Current Phase

---

# Current Architecture

CSBank follows a hybrid persistence architecture.

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

       ├── Dapper
       │
       └── Entity Framework Core

↓

PostgreSQL
```

The database remains the source of truth.

The project intentionally does not treat Entity Framework Core as a replacement for SQL.

Persistence technology is selected according to the problem being solved.

---

# Persistence Strategy

## Dapper

Dapper is currently preferred for:

* Handcrafted SQL
* Complex read queries
* Writable CTEs
* Atomic banking workflows
* Explicit transaction control
* Precise PostgreSQL behavior
* Minimizing unnecessary database round trips

The project uses Dapper heavily because understanding SQL and database behavior remains a core engineering objective.

## Entity Framework Core

EF Core is used where its abstractions provide practical value:

* Change Tracking
* Entity State Management
* Aggregate Updates
* Unit of Work
* Relationship Mapping

EF Core remains part of the project's engineering knowledge even when Dapper is the better implementation for a specific operation.

---

# Completed Features

## User Management

* Register User
* Read User
* Update User

## Authentication

* Login
* JWT Access Tokens
* Refresh Tokens
* Refresh Token Hashing
* Refresh Token Rotation
* Refresh Token Expiration
* Refresh Token Revocation
* Logout

## Authorization

* Authentication Middleware
* Authorization Middleware
* Claims
* Roles
* Ownership Validation

## Banking

* Register Account
* Deposit
* Transfer

## Transaction History

* Read Transaction History
* OFFSET Pagination
* Ordered by Creation Date (Newest First)

## Auditing

* Login Audit
* Sensitive Action Audit
* Entity Identification
* Actor Identification
* Timestamp
* Previous Values
* New Values

## API Security

* Secure Exception Handling
* Input Validation
* Parameterized SQL
* SQL Injection Prevention
* HTTPS
* Authentication
* Authorization

## Request / Database Cancellation

* `CancellationToken`
* HTTP request cancellation propagation
* Repository cancellation
* Dapper `CommandDefinition`
* Database command cancellation
* Command timeouts

Explicit command timeouts have been introduced for database operations.

Longer-running banking operations such as Deposit and Transfer use longer command timeouts than ordinary queries.

---

# Security Engineering — Complete

Phase 7 is considered complete.

The objective was to understand and implement the security mechanisms required to transform the functional banking backend into a secure backend.

Completed concepts include:

### Authentication

* JWT
* Access Tokens
* Refresh Tokens
* Token Rotation
* Token Expiration
* Token Revocation
* Login
* Logout
* Authentication Middleware

### Authorization

* Claims
* Roles
* Authorization Middleware
* Ownership Validation

### Password Security

* Password Hashing
* Password Verification
* Secure Password Storage

### API Security

* Input Validation
* Parameterized SQL
* SQL Injection Prevention
* Secure Exception Handling
* HTTPS

### Auditing

* Login Auditing
* Sensitive Action Auditing
* Previous State
* New State
* Actor
* Timestamp

### Request Lifecycle

* CancellationToken propagation
* Dapper CommandDefinition
* Command cancellation
* Database command timeouts

Security is no longer the current task.

---

# Performance Engineering — Current Phase

## Objective

Understand how backend implementation choices affect:

* Latency
* Throughput
* Database load
* Memory usage
* CPU usage
* Network round trips
* Connection usage
* Query execution
* Scalability

The central rule is:

> **Measure first. Optimize second.**

Do not optimize based solely on assumptions.

Every meaningful optimization should be supported by measurable evidence whenever practical.

---

# Performance Work Already Completed

## PostgreSQL

Completed:

* `EXPLAIN`
* `EXPLAIN ANALYZE`
* Execution Plan Analysis
* Sequential Scan vs Index Scan
* Query Plan Interpretation
* Generated SQL Inspection
* Query Performance Analysis

## Pagination

Completed:

* OFFSET Pagination
* Ordering by Creation Date
* Understanding pagination query behavior

## Persistence Comparison

Completed:

* EF Core vs Dapper comparison
* Generated SQL inspection
* Understanding ORM overhead
* Understanding direct SQL execution

## Database Round Trips

Completed conceptually:

* One transaction
* One SQL statement
* Multiple writable CTEs
* One database round trip

This approach is already used in important banking workflows.

---

# Current Performance Learning Targets

The next work should deepen performance knowledge rather than simply adding random optimizations.

## PostgreSQL

Study and apply:

* Composite indexes
* Covering indexes
* Index selectivity
* Partial indexes
* Keyset / cursor pagination
* Window functions
* Query planning
* Lock contention
* Transaction isolation performance
* Query latency
* Connection behavior

## Dapper

Study:

* `CommandDefinition`
* Buffered vs unbuffered queries
* Streaming
* `QueryMultiple`
* Multi-mapping
* Allocation behavior
* Connection lifetime
* Command timeout behavior
* Cancellation behavior
* Database round-trip reduction

## Entity Framework Core

Study:

* Generated SQL
* Tracking overhead
* `AsNoTracking`
* Query projection
* N+1 queries
* Split queries
* Change Tracker cost
* `SaveChanges` behavior
* Query performance

## .NET

Study:

* Allocation
* Garbage Collection
* Async performance
* `Task` vs `ValueTask`
* Collections
* LINQ performance
* `Span<T>`
* `Memory<T>`
* BenchmarkDotNet
* Profiling

---

# Performance Engineering Rule

Before changing an implementation:

```text
Identify Problem

↓

Measure Current Behavior

↓

Form Hypothesis

↓

Change Implementation

↓

Measure Again

↓

Compare Results

↓

Keep or Revert
```

Do not introduce complexity merely because an optimization is theoretically faster.

---

# Engineering Philosophy

Continue following the project's primary principle:

> **Understand the abstraction before depending on the abstraction.**

Every engineering decision should answer:

* What problem does this solve?
* What happens underneath?
* What SQL is ultimately executed?
* What database concepts does it depend on?
* What resources does it consume?
* What trade-offs are introduced?
* Can the improvement be measured?

---

# Domain Philosophy

The Domain remains persistence-agnostic.

Business rules may be implemented at different levels when appropriate.

Rules that are fundamentally relational or concurrency-sensitive may be enforced by PostgreSQL.

Examples already implemented through database operations include:

* Positive transaction amounts
* Sufficient available balance
* Account state restrictions
* Self-transfer prevention
* Transaction consistency
* Concurrency control

The goal is not to force every rule into C#.

The goal is to enforce each invariant at the layer best positioned to guarantee it.

---

# SQL Philosophy

Whenever appropriate:

```text
One Transaction

↓

One SQL Statement

↓

Multiple Writable CTEs

↓

One Database Round Trip
```

The database should be treated as an execution engine—not merely a storage engine.

---

# Transaction Philosophy

Infrastructure owns:

* Connection lifecycle
* Transaction lifecycle
* Commit
* Rollback
* Exception propagation
* Command execution infrastructure

Repositories remain focused on persistence workflows.

Reusable infrastructure handles common transaction concerns.

---

# Audit Philosophy

Audit logging remains independent from business entities.

Audit records capture:

* Entity
* Action
* Actor
* Timestamp
* Previous values
* New values

Security-sensitive operations such as login and refresh-token rotation are audited.

---

# Ledger Philosophy

Account balances are mutable.

Transaction history is immutable.

Balances represent the current projection.

The transaction ledger represents historical truth.

Financial operations must preserve consistency between:

```text
Account Balance

+

Transaction History

+

Audit Record
```

---

# Immediate Next Work

The next task is **not another security feature**.

Security Engineering is complete.

The next objective is to continue Phase 8 by taking an existing CSBank operation and performing a complete performance investigation.

The investigation should follow:

```text
Existing Query

↓

EXPLAIN

↓

EXPLAIN ANALYZE

↓

Identify Bottleneck

↓

Inspect Indexes

↓

Inspect Database Round Trips

↓

Inspect C# / Dapper Behavior

↓

Make One Controlled Change

↓

Measure Again

↓

Document Result
```

Prefer an existing real operation over creating an artificial benchmark.

Good candidates include:

* Transaction History
* Read User
* Deposit
* Transfer
* Authentication
* Refresh Token

---

# Current Development Rule

Do not add technologies simply to make the project appear more advanced.

Do not introduce Redis, distributed systems, microservices, or other infrastructure until the problem they solve actually exists.

CSBank should continue evolving from concrete engineering requirements.

---

# Current Goal

Transform CSBank from a secure backend into a backend whose **performance characteristics are understood and measurable**.

The immediate objective is not maximum performance.

It is to understand:

* Where time is spent
* Where resources are consumed
* Where database work occurs
* Where network round trips occur
* Where abstractions introduce cost
* Which optimizations actually matter

Only after those characteristics are understood should further optimization be introduced.

---

# Phase Completion Criteria

Phase 8 should be considered complete when the project demonstrates practical understanding of:

* PostgreSQL query optimization
* Index design
* Query execution plans
* Pagination strategies
* Dapper performance
* EF Core performance
* .NET allocation and async behavior
* Benchmarking
* Profiling
* Database round-trip optimization
* Performance measurement methodology

Performance engineering will then continue as a **continuous engineering responsibility** rather than becoming a permanently isolated phase.

---

# Long-Term Objective

Continue evolving CSBank toward a production-quality banking backend while maintaining the original philosophy:

> **Understand the abstraction before depending on it.**

The project should demonstrate not only that the system works, but that its:

* Architecture
* Database
* Persistence
* Security
* Performance
* Concurrency
* Testing
* Deployment

can be explained, measured, justified, and maintained.
