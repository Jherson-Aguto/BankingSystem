# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, beginning with customer registration and evolving into a production-quality banking backend while following **Clean Architecture**.

The project is intentionally designed around one principle:

> Understand every abstraction before depending on it.

Rather than learning frameworks first, CSBank builds every major concept from first principles and only then introduces higher-level abstractions.

The objective is not simply to build banking software, but to understand why every architectural decision exists.

---

# Current Project Status

## Architecture

**Status:** Phase 8 — Security Engineering 🚧

**Architecture Status:** Stable ✅

Completed:

* Clean Architecture
* Domain Layer
* Application Layer
* API Layer
* Manual Mapping
* Repository Abstractions
* Domain Services
* Dependency Injection
* PostgreSQL Integration
* Dapper Persistence
* Repository Executor
* Higher-Order Transaction Executor
* Relational Database Design
* Schema Evolution
* Constraint Design
* Entity Framework Core
* Hybrid Persistence (EF Core Writes / Dapper Reads)
* SQL Execution Plan Analysis
* Offset Pagination
* REST API Refinement
* JWT Authentication
* Refresh Token Rotation
* Refresh Token Expiration
* Refresh Token Revocation
* Logout
* Authentication Middleware
* Authorization Middleware
* Claims
* Role-based Authentication
* Secure Exception Handling
* Audit Logging
* CancellationToken Propagation
* Dapper CommandDefinition Cancellation
* Database Command Timeouts

Current work focuses on completing authorization and API security before moving toward production hardening.

The architectural foundation is considered stable.

---

# Engineering Principles

The following principles guide every feature implemented in CSBank.

## Layer Responsibilities

* Domain owns business rules.
* Application owns orchestration.
* Infrastructure owns persistence.
* PostgreSQL owns relational consistency.
* API owns HTTP concerns and Dependency Injection.

---

## Repository Philosophy

Repositories orchestrate persistence—not business logic.

Repositories are responsible for:

* Selecting the persistence technology
* Executing persistence operations
* Mapping persistence models
* Returning application models

Repositories are **not** responsible for:

* Business rules
* Connection management
* Transaction lifecycle

The persistence implementation may use:

* Dapper
* Entity Framework Core

depending on the engineering requirements.

---

## Persistence Philosophy

The project intentionally uses hybrid persistence.

```text
Writes

↓

Entity Framework Core

↓

PostgreSQL
```

```text
Reads

↓

Dapper

↓

PostgreSQL
```

Entity Framework Core provides productivity for aggregate updates.

Dapper provides explicit SQL control for handcrafted queries requiring precise SQL control and predictable behavior.

The project does not treat EF Core as a replacement for SQL knowledge.

---

## Transaction Philosophy

Infrastructure owns:

* Connections
* Transactions
* Commit
* Rollback
* Exception propagation

Repositories remain focused on persistence workflows while reusable higher-order functions centralize infrastructure concerns.

---

## SQL Philosophy

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

Business rules that can be safely and correctly enforced at the database level may be implemented directly in SQL.

Examples include:

* Positive transaction amounts
* Sufficient account balance
* Preventing self-transfers
* Closed-account transaction restrictions
* Refresh-token expiration checks
* Refresh-token revocation checks

Application code should not duplicate database responsibilities unnecessarily.

---

## Abstraction Philosophy

Every abstraction introduced should be understood before it is adopted.

Current progression:

```text
Raw SQL

↓

Dapper

↓

Entity Framework Core
```

Higher-level abstractions increase productivity without replacing relational knowledge.

The project favors explicit mechanisms when they provide greater understanding and control.

---

## Ledger Philosophy

Account balances are mutable.

Transaction history is immutable.

Balances represent the current projection.

The ledger represents historical truth.

---

## Audit Philosophy

Audit logging remains independent from business entities.

Audit records capture:

* Entity
* Action
* Actor
* Timestamp
* Previous values (optional)
* New values (optional)

Business operations determine whether snapshots provide meaningful information.

Audit logging is implemented directly within transactional SQL workflows where appropriate, ensuring that the business operation and its audit record participate in the same transaction.

---

# Security Philosophy

Security is treated as a system-wide concern rather than a collection of middleware features.

Authentication establishes identity.

Authorization determines permissions.

Database constraints enforce relational invariants.

SQL transactions protect atomic operations.

Audit logging provides traceability.

Cancellation and command timeouts prevent indefinitely running database operations.

The goal is to make security enforcement occur at the appropriate layer rather than relying entirely on application-level checks.

---

# Architecture

```text
CSBank

├── csbank.Domain
│   ├── Entities
│   ├── Domain Services
│   └── Business Rules
│
├── csbank.Application
│   ├── DTOs
│   ├── Use Cases
│   ├── Repository Interfaces
│   ├── Services
│   └── Manual Mapping
│
├── csbank.Infrastructure
│   ├── Database
│   ├── SQL
│   ├── Dapper
│   ├── Entity Framework Core
│   ├── Configurations
│   ├── Repository Implementations
│   └── Infrastructure Utilities
│
└── csbank.Api
    ├── Controllers
    ├── Middleware
    └── Dependency Injection
```

Dependency graph:

```text
API
├── Application
└── Infrastructure

Application
└── Domain

Infrastructure
└── Application

Domain
└── nothing
```

The API remains the Composition Root.

---

# Request Flow

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

      ├── EF Core (Writes)

      └── Dapper (Reads)

↓

PostgreSQL
```

For security-sensitive requests:

```text
HTTP Request

↓

Authentication

↓

Authorization

↓

Controller

↓

Application Service

↓

Domain / Repository

↓

PostgreSQL
```

---

# Infrastructure Evolution

## Stage 1

Mock Repository

Purpose:

Validate architecture before persistence.

---

## Stage 2

Repository

↓

Dapper

↓

PostgreSQL

Purpose:

Introduce production persistence and understand SQL-driven persistence.

---

## Stage 3

Repository

↓

Repository Executor

↓

Higher-Order Functions

↓

Transactions

↓

Dapper

↓

PostgreSQL

Purpose:

Centralize infrastructure concerns while keeping repositories focused on persistence workflows.

---

## Stage 4

Repository

↓

EF Core

↓

Generated SQL

↓

PostgreSQL

Purpose:

Understand ORM abstractions while preserving SQL knowledge.

---

## Stage 5

Hybrid Persistence

```text
Writes → EF Core
Reads  → Dapper
```

Purpose:

Use each persistence abstraction where its characteristics provide the most value.

---

## Stage 6

Security-aware Persistence

```text
Application

↓

Repository

↓

Dapper / EF Core

↓

Transactional SQL

↓

PostgreSQL
```

Security-sensitive persistence now incorporates:

* Token expiration
* Token revocation
* Token rotation
* Row locking where required
* Atomic audit logging
* Command cancellation
* Command timeouts

---

# Completed Phases

## Phase 1 — Architecture Foundation ✅

* Clean Architecture
* Dependency Injection
* Repository Pattern
* DTOs
* Manual Mapping
* Domain Services

---

## Phase 2 — PostgreSQL Fundamentals ✅

* Schemas
* Tables
* Constraints
* Relationships
* UUIDs
* CRUD
* Transactions
* JOINs
* CTEs
* Referential Integrity

---

## Phase 3 — Persistence Engineering ✅

* Dapper
* Npgsql
* Repository Executor
* Higher-Order Transactions
* Atomic SQL Workflows
* Audit Logging
* Ledger Design
* Transaction-safe Business Operations

Completed business features:

* Customer Registration
* Read User
* Update User
* Create Account
* Deposit
* Transfer
* Transaction History

---

## Phase 4 — Relational Database Design ✅

* Relationship Design
* Constraint Design
* Index Strategy
* Normalization
* Schema Evolution
* ERD Refinement

---

## Phase 5 — Entity Framework Core ✅

* DbContext
* DbSet
* Fluent API
* Entity Configurations
* Relationship Mapping
* Change Tracker
* Entity States
* SaveChanges Pipeline
* Generated SQL
* EF Core vs Dapper
* Hybrid Persistence

---

## Phase 6 — SQL Performance Foundations ✅

Topics completed:

* EXPLAIN
* EXPLAIN ANALYZE
* Execution Plans
* Generated SQL Comparison
* Index Scan vs Sequential Scan
* Offset Pagination
* Query Inspection

Performance engineering is now treated as a continuous engineering responsibility rather than a permanently isolated phase.

---

# Current Phase

## Phase 8 — Security Engineering 🚧

**Goal:**

Transform CSBank from a functional backend into a secure production-oriented banking backend.

### Authentication

Completed:

* JWT Access Tokens
* Secure Password Hashing
* Login
* Refresh Tokens
* Refresh Token Hashing
* Refresh Token Rotation
* Refresh Token Expiration
* Refresh Token Revocation
* Logout
* Authentication Middleware

### Authorization

Current focus:

* `[Authorize]`
* Roles
* Claims
* Authorization Policies
* Resource Ownership
* Account Ownership Validation
* Preventing unauthorized access to another customer's resources

### API Security

Remaining:

* HTTPS verification
* CORS
* Rate Limiting
* Request Validation
* Input Sanitization
* Security Headers

### Database Security

Remaining:

* Least Privilege
* SQL Injection Prevention
* Secrets Management
* Secure Connection Strings
* Production database configuration

### Application Security

Completed:

* Authentication Middleware
* Authorization Middleware
* Secure Exception Handling
* CancellationToken propagation
* Database command timeouts

Remaining:

* Security headers
* Additional authorization policies
* Security-focused integration testing

### Auditing

Completed:

* Login Audit
* Sensitive Business Operation Audits
* Actor Tracking
* Previous/New Value Tracking where appropriate
* Transactional Audit Logging

---

# Security Verification

Security features should be verified through actual behavior rather than simply checking whether the implementation exists.

Required verification includes:

* Expired JWT is rejected
* Invalid JWT is rejected
* Missing JWT is rejected
* Revoked refresh token is rejected
* Expired refresh token is rejected
* Refresh token rotation works
* Reused refresh tokens are rejected where applicable
* Logout invalidates the refresh token
* Unauthorized users cannot access protected endpoints
* Incorrect roles are rejected
* Customers cannot access another customer's resources
* Customers cannot operate on another customer's accounts
* Database operations respect cancellation
* Long-running database commands respect configured timeouts

---

# Remaining Roadmap

## Phase 9 — Performance Engineering

Performance remains a continuous engineering responsibility.

Future topics:

* Query Optimization
* Index Strategy
* Keyset Pagination
* Window Functions
* Dapper Optimization
* EF Core Optimization
* Memory Optimization
* BenchmarkDotNet
* Profiling

---

## Phase 10 — LINQ

* Deferred Execution
* IEnumerable vs IQueryable
* Projection
* Aggregation
* Grouping
* Set Operations
* Performance Characteristics

---

## Phase 11 — Algorithms

Apply algorithms where they improve backend systems.

---

## Phase 12 — Trees & Hierarchies

Recursive business models.

---

## Phase 13 — Networking

* REST
* HTTP
* HTTPS
* API Design
* Idempotency
* Versioning

---

## Phase 14 — Advanced Concurrency

* Isolation Levels
* Deadlocks
* Retry Strategies
* Optimistic Concurrency
* Distributed Transactions

---

## Phase 15 — Caching

* Memory Cache
* Redis
* Cache Invalidation
* Distributed Caching

---

## Phase 16 — Testing

* Unit Testing
* Integration Testing
* API Testing
* Concurrency Testing
* Load Testing
* Security Testing

---

## Phase 17 — Deployment & DevOps

* Docker
* CI/CD
* Logging
* Monitoring
* Configuration
* Cloud Deployment

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

By completing CSBank, the project demonstrates practical engineering knowledge in:

* Clean Architecture
* Software Engineering
* PostgreSQL
* Database Engineering
* Dapper
* Entity Framework Core
* Hybrid Persistence
* Security Engineering
* Performance Engineering
* Algorithms
* Networking
* Concurrency
* LINQ
* Caching
* Testing
* Deployment

CSBank is more than a portfolio project.

It is a long-term engineering project designed to demonstrate not only how backend systems are built, but why every architectural decision exists and how each abstraction is constructed from first principles.
