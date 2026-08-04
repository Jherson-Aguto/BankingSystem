# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, a production-oriented banking backend built using **Clean Architecture**, **PostgreSQL**, **Dapper**, and **Entity Framework Core**.

The project is intentionally designed around one principle:

> Understand the abstraction before depending on the abstraction.

Every technology introduced should be understood from the layer beneath it, allowing engineering decisions to be made based on requirements rather than familiarity.

---

# Current Project Status

## Architecture

**Status:** Phase 1–6 Complete ✅

Completed:

- Clean Architecture
- Domain Layer
- Application Layer
- API Layer
- Manual Object Mapping
- Repository Pattern
- Dependency Injection
- Domain Services
- Customer Registration
- Account Creation
- Customer Profile
- Deposit
- Transfer
- PostgreSQL Integration
- Dapper Persistence
- Entity Framework Core Integration
- Transaction-safe Business Operations
- Relational Database Design
- Repository Executor
- Higher-Order Transaction Executor
- Audit Logging
- Transaction History
- Offset Pagination
- SQL Performance Inspection using EXPLAIN / EXPLAIN ANALYZE

The architecture is now considered stable and production-oriented.

Current work now shifts toward securing the application before introducing authentication and external clients.

---

# Engineering Principles

## Layer Responsibilities

- Domain owns business rules.
- Application owns orchestration.
- Infrastructure owns persistence.
- PostgreSQL owns relational consistency.
- API owns HTTP concerns and Dependency Injection.

---

## Repository Philosophy

Repositories orchestrate persistence rather than business logic.

Responsibilities include:

- Selecting the persistence strategy.
- Executing SQL or EF Core operations.
- Mapping persistence models.
- Returning application models.

Repositories do **not** own:

- Connections
- Transactions
- Commit
- Rollback

Those responsibilities remain centralized inside Infrastructure.

---

## Hybrid Persistence Philosophy

CSBank intentionally uses two persistence technologies.

### Writes

```text
Entity Framework Core
```

Chosen because:

- Aggregate updates
- Change Tracking
- Unit of Work
- Navigation management

---

### Reads

```text
Dapper
```

Chosen because:

- Handwritten SQL
- Full query control
- Predictable execution plans
- High-performance projections
- Easier SQL optimization

This hybrid approach allows each tool to be used where it provides the greatest engineering value.

---

## SQL Philosophy

Whenever practical:

```text
One Transaction

↓

One SQL Statement

↓

Multiple Writable CTEs

↓

One Database Round Trip
```

PostgreSQL is treated as an execution engine rather than simple storage.

---

## Performance Philosophy

Optimization must always be measurable.

Every optimization should answer:

- What became faster?
- Why did it become faster?
- Can it be verified with EXPLAIN ANALYZE?
- Is the added complexity justified?

Performance decisions should never rely on assumptions.

---

## Ledger Philosophy

Account balances are mutable.

Transaction history is immutable.

Balances represent the current projection.

The ledger represents historical truth.

---

## Audit Philosophy

Audit logs exist independently of business entities.

Each audit record captures:

- Entity
- Action
- Actor
- Timestamp
- Optional old values
- Optional new values

Business operations determine whether before/after snapshots provide meaningful information.

---

# Architecture

```text
CSBank (Solution)

├── csbank.Domain
│   ├── Entities
│   ├── Domain Services
│   └── Business Rules
│
├── csbank.Application
│   ├── DTOs
│   ├── Use Cases
│   ├── Repository Interfaces
│   ├── Manual Mappers
│   └── Application Services
│
├── csbank.Infrastructure
│   ├── SQL Queries
│   ├── Dapper
│   ├── Entity Framework Core
│   ├── Repository Implementations
│   ├── Repository Executor
│   ├── Configurations
│   └── Database Connectivity
│
└── csbank.Api
    ├── Controllers
    ├── Middleware
    └── Dependency Injection
```

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

Validate architecture.

---

## Stage 2

Repository → Dapper

Purpose:

Introduce real persistence.

---

## Stage 3

Repository

↓

Repository Executor

↓

Transaction Executor

↓

Dapper

↓

PostgreSQL

Purpose:

Centralize infrastructure responsibilities.

---

## Stage 4

Repository

├── Entity Framework Core

└── Dapper

↓

PostgreSQL

Purpose:

Hybrid persistence architecture.

---

# Completed Phases

## Phase 1–3 — Architecture Foundation ✅

Completed.

Major concepts:

- Clean Architecture
- Repository Pattern
- Dependency Injection
- DTOs
- Domain Services
- Application Services

---

## Phase 4A — PostgreSQL Fundamentals ✅

Completed.

Topics:

- Schemas
- Tables
- Constraints
- Relationships
- UUIDs
- CRUD
- JOINs
- Transactions
- Referential Integrity
- Indexes

---

## Phase 4B — Persistence Engineering ✅

Completed.

Technologies:

- PostgreSQL
- Npgsql
- Dapper

Major concepts:

- Repository implementations
- Repository Executor
- Transaction Executor
- Atomic SQL workflows
- Ledger
- Audit Logs
- Row-level locking
- Concurrency-safe SQL

Business operations:

- Register User
- Read User
- Update User
- Create Account
- Deposit
- Transfer
- Transaction History

---

## Phase 5 — Relational Database Design ✅

Completed.

Topics:

- Relationships
- Keys
- Normalization
- Constraint Design
- Index Strategy
- Schema Evolution

---

## Phase 6 — Entity Framework Core ✅

Completed.

Topics:

- DbContext
- DbSet
- Fluent API
- Entity Configurations
- Relationship Mapping
- Navigation Properties
- Change Tracking
- SaveChanges Pipeline
- Entity States
- Generated SQL
- Repository Integration
- EF Core vs Dapper

Outcome:

Understand EF Core as a persistence abstraction rather than a replacement for SQL.

---

# Current Phase

## Phase 7 — Security 🚧

Current objective:

Secure the backend before exposing it to real clients.

Topics:

- Authentication
- Authorization
- JWT
- Refresh Tokens
- Password Hashing (BCrypt)
- Claims
- Roles
- Policies
- Validation
- Secure API Design
- Secret Management
- HTTPS
- CORS
- Rate Limiting
- SQL Injection Prevention
- Security Headers

Goal:

Produce a backend that is secure enough for production deployment.

---

# Remaining Roadmap

## Phase 8 — Performance Engineering

Topics:

- Query Optimization
- EXPLAIN
- EXPLAIN ANALYZE
- Execution Plans
- Index Optimization
- Keyset Pagination
- EXISTS vs JOIN
- Window Functions
- EF Core Performance
- Dapper Performance
- BenchmarkDotNet

---

## Phase 9 — Networking

- REST
- HTTP
- HTTPS
- API Design
- Idempotency

---

## Phase 10 — Advanced Concurrency

- Isolation Levels
- Deadlocks
- Optimistic Concurrency
- Retry Strategies

---

## Phase 11 — Caching

- Memory Cache
- Redis
- Distributed Cache
- Cache Invalidation

---

## Phase 12 — LINQ

Topics:

- IEnumerable vs IQueryable
- Deferred Execution
- Projection
- Filtering
- Ordering
- Grouping
- Aggregation

---

## Phase 13 — Testing

Topics:

- Unit Testing
- Integration Testing
- API Testing
- Concurrency Testing
- Load Testing

---

## Phase 14 — Deployment & DevOps

Topics:

- Docker
- CI/CD
- Reverse Proxy
- Cloud Deployment
- Monitoring
- Logging
- Configuration
- Health Checks

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

By completing CSBank, the project should demonstrate practical engineering knowledge of:

- Clean Architecture
- Software Engineering
- PostgreSQL
- Database Engineering
- Dapper
- Entity Framework Core
- Security
- Performance Engineering
- Networking
- Concurrency
- Caching
- LINQ
- Testing
- DevOps

CSBank is intended to be more than a portfolio project.

It is an engineering project designed to demonstrate the ability to reason about architecture, persistence, performance, and security from first principles while producing software suitable for real-world deployment.