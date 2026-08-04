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

**Status:** Phase 1–7 Active 🚧

Completed:

- Clean Architecture
- Domain Layer
- Application Layer
- API Layer
- Manual Mapping
- Repository Abstractions
- Domain Services
- Dependency Injection
- PostgreSQL Integration
- Dapper Persistence
- Repository Executor
- Higher-Order Transaction Executor
- Relational Database Design
- Schema Evolution
- Constraint Design
- Entity Framework Core
- Hybrid Persistence (EF Core Writes / Dapper Reads)
- SQL Execution Plan Analysis
- Offset Pagination
- REST API Refinement

Current work focuses on preparing the backend for production through security engineering.

The architectural foundation is considered stable.

---

# Engineering Principles

The following principles guide every feature implemented in CSBank.

## Layer Responsibilities

- Domain owns business rules.
- Application owns orchestration.
- Infrastructure owns persistence.
- PostgreSQL owns relational consistency.
- API owns HTTP concerns and Dependency Injection.

---

## Repository Philosophy

Repositories orchestrate persistence—not business logic.

Repositories are responsible for:

- Selecting the persistence technology
- Executing persistence operations
- Mapping persistence models
- Returning application models

Repositories are **not** responsible for:

- Business rules
- Connection management
- Transaction lifecycle

The persistence implementation may use:

- Dapper
- Entity Framework Core

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

Dapper provides explicit SQL control for optimized read operations.

---

## Transaction Philosophy

Infrastructure owns:

- Connections
- Transactions
- Commit
- Rollback
- Exception propagation

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

- Entity
- Action
- Actor
- Timestamp
- Previous values (optional)
- New values (optional)

Business operations determine whether snapshots provide meaningful information.

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

Introduce production persistence.

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

Centralize infrastructure concerns.

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

# Completed Phases

## Phase 1 — Architecture Foundation ✅

- Clean Architecture
- Dependency Injection
- Repository Pattern
- DTOs
- Manual Mapping
- Domain Services

---

## Phase 2 — PostgreSQL Fundamentals ✅

- Schemas
- Tables
- Constraints
- Relationships
- UUIDs
- CRUD
- Transactions
- JOINs
- CTEs
- Referential Integrity

---

## Phase 3 — Persistence Engineering ✅

- Dapper
- Npgsql
- Repository Executor
- Higher-Order Transactions
- Atomic SQL Workflows
- Audit Logging
- Ledger Design
- Transaction-safe Business Operations

Completed business features:

- Customer Registration
- Read User
- Update User
- Create Account
- Deposit
- Transfer
- Transaction History

---

## Phase 4 — Relational Database Design ✅

- Relationship Design
- Constraint Design
- Index Strategy
- Normalization
- Schema Evolution
- ERD Refinement

---

## Phase 5 — Entity Framework Core ✅

- DbContext
- DbSet
- Fluent API
- Entity Configurations
- Relationship Mapping
- Change Tracker
- SaveChanges Pipeline
- Generated SQL
- EF Core vs Dapper
- Hybrid Persistence

---

## Phase 6 — SQL Performance Foundations ✅

Topics completed:

- EXPLAIN
- EXPLAIN ANALYZE
- Execution Plans
- Generated SQL Comparison
- Index Scan vs Sequential Scan
- Offset Pagination
- Query Inspection

---

# Current Phase

## Phase 7 — Security Engineering 🚧

Topics:

- Authentication
- Authorization
- JWT
- Refresh Tokens
- BCrypt / Argon2
- Validation
- Secure Error Handling
- HTTPS
- CORS
- Rate Limiting
- Authorization Policies
- Account Ownership
- Idempotency
- Secrets Management

Goal:

Prepare CSBank for production deployment by ensuring every business operation is secure before further optimization.

---

# Remaining Roadmap

## Phase 8 — Performance Engineering

- Query Optimization
- Index Strategy
- Keyset Pagination
- Window Functions
- Dapper Optimization
- EF Core Optimization
- Memory Optimization
- BenchmarkDotNet
- Profiling

---

## Phase 9 — LINQ

- Deferred Execution
- IEnumerable vs IQueryable
- Projection
- Aggregation
- Grouping
- Set Operations
- Performance Characteristics

---

## Phase 10 — Algorithms

Apply algorithms where they improve backend systems.

---

## Phase 11 — Trees & Hierarchies

Recursive business models.

---

## Phase 12 — Networking

- REST
- HTTP
- HTTPS
- API Design
- Idempotency
- Versioning

---

## Phase 13 — Advanced Concurrency

- Isolation Levels
- Deadlocks
- Retry Strategies
- Optimistic Concurrency
- Distributed Transactions

---

## Phase 14 — Caching

- Memory Cache
- Redis
- Cache Invalidation
- Distributed Caching

---

## Phase 15 — Testing

- Unit Testing
- Integration Testing
- API Testing
- Concurrency Testing
- Load Testing

---

## Phase 16 — Deployment & DevOps

- Docker
- CI/CD
- Logging
- Monitoring
- Configuration
- Cloud Deployment

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

By completing CSBank, the project demonstrates practical engineering knowledge in:

- Clean Architecture
- Software Engineering
- PostgreSQL
- Database Engineering
- Dapper
- Entity Framework Core
- Hybrid Persistence
- Security Engineering
- Performance Engineering
- Algorithms
- Networking
- Concurrency
- LINQ
- Caching
- Testing
- Deployment

CSBank is more than a portfolio project.

It is a long-term engineering project designed to demonstrate not only how backend systems are built, but why every architectural decision exists and how each abstraction is constructed from first principles.