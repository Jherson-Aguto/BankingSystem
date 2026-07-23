# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, beginning with **Customer Registration** and gradually expanding into a production-quality banking backend while following **Clean Architecture**.

The project is intentionally designed so that every abstraction is learned only after understanding the concepts beneath it.

The objective is not simply to build a banking system, but to understand **why every architectural decision exists** before relying on higher-level frameworks or abstractions.

---

# Current Project Status

## Architecture

**Status:** Phase 1–3 Complete ✅

Completed:

- Clean Architecture solution structure
- Domain layer
- Application layer
- API layer
- Manual object mapping
- Repository abstractions
- Domain services
- Dependency Injection architecture
- Customer Registration
- Account Creation
- Mock repository implementation
- PostgreSQL integration
- Dapper persistence

Current focus has shifted from **building architecture** to **designing business operations**.

The architectural foundation is considered stable.

Current work focuses on implementing transaction-safe banking operations while preserving Clean Architecture.

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

Repositories are responsible for persistence orchestration—not business logic.

Repositories should primarily:

- Choose SQL
- Supply parameters
- Map results
- Return domain/application models

Repositories should **not** own connection management or transaction lifecycle.

---

## Transaction Philosophy

Infrastructure owns:

- Connection creation
- Transaction creation
- Commit
- Rollback
- Exception propagation

This responsibility is centralized through reusable transaction helpers built using Higher-Order Functions.

---

## SQL Philosophy

Whenever appropriate:

One business operation should execute as:

```text
One Transaction

↓

One SQL Statement

↓

Multiple CTEs

↓

One Database Round Trip
```

The objective is to allow PostgreSQL to perform relational work efficiently while minimizing application orchestration.

---

## Ledger Philosophy

Account balance is mutable.

Transaction history is immutable.

The ledger is considered the source of truth.

Current balance is a projection of historical transactions.

---

## Audit Philosophy

Audit logging exists independently from business entities.

Audit records capture:

- Who performed an action
- What changed
- When it changed
- Request metadata
- Before/after values

Audit logs describe system events rather than business ownership.

---

# Architecture Design

```text
CSBank (Solution)

├── csbank.Domain
│   ├── Domain Models
│   ├── Domain Services
│   └── Business Rules
│
├── csbank.Application
│   ├── Use Cases
│   ├── DTOs
│   ├── Manual Mappers
│   ├── Repository Interfaces
│   └── Application Services
│
├── csbank.Infrastructure
│   ├── Database
│   ├── RepositoryExecutor
│   ├── Repository Implementations
│   ├── SQL
│   ├── Configurations
│   ├── Dapper
│   ├── Npgsql
│   └── Database Connectivity
│
└── csbank.Api
    ├── Controllers
    ├── Dependency Injection
    └── HTTP Endpoints
```

Current dependency graph:

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

The API remains the Composition Root and is responsible for registering Infrastructure implementations.

---

# Current Request Flow

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

Repository Executor

↓

Dapper

↓

PostgreSQL
```

---

# Infrastructure Evolution

Infrastructure has evolved through several stages.

## Stage 1

```text
Mock Repository
```

Purpose:

Architecture validation.

---

## Stage 2

```text
Repository

↓

Connection

↓

Dapper
```

Purpose:

Real persistence.

---

## Stage 3 (Current)

```text
Repository

↓

Repository Executor

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

Infrastructure now provides reusable execution helpers that manage:

- Connection lifecycle
- Transactions
- Commit
- Rollback
- Exception propagation

Repositories now focus exclusively on SQL execution.

---

# Phase 1–3 — Architecture Foundation ✅

Completed.

Concepts mastered:

- Clean Architecture
- Domain Models
- Domain Services
- DTOs
- Manual Mapping
- Repository Interfaces
- Dependency Injection
- Application Services
- Customer Registration

Outcome:

A complete architecture independent from persistence.

---

# Phase 4A — PostgreSQL Fundamentals ✅

Purpose:

Understand relational databases before introducing Infrastructure.

Completed:

## Database Engineering

- Database creation
- Schemas
- Tables
- Constraints
- Indexes
- Relationships

## SQL

- CRUD
- CTEs
- Transactions
- Aggregation
- JOINs
- Referential Integrity

## ORM Mental Model

Understand:

- PostgreSQL stores relational data.
- JOINs reconstruct object graphs.
- Dapper executes SQL directly.
- EF Core abstracts persistence.

Outcome:

Transitioned from isolated SQL statements to complete relational workflows.

---

# Phase 4B — Persistence & Business Operations Engineering 🚧

Current Phase.

Current technologies:

- PostgreSQL
- Npgsql
- Dapper

Current engineering focus:

- Repository implementations
- Connection Factory
- Repository Executor
- Higher-Order Functions
- Transaction management
- SQL organization
- Parameterized SQL
- Business operation modeling
- Ledger implementation
- Audit logging
- Row-level locking
- Atomic SQL workflows

Current business operations:

- Customer Registration ✅
- Customer Profile ✅
- Create Account ✅
- Create Checking Account ✅
- Create Savings Account ✅
- Deposit 🚧

Major concepts learned:

- Higher-Order Functions
- Delegates
- Func<>
- Lambda Expressions
- Repository abstraction
- Transaction abstraction
- Row-level locking (`FOR UPDATE`)
- Race condition prevention
- Atomic business operations
- CTE-based workflows

Current persistence flow:

```text
Business Requirement

↓

Business Workflow

↓

Repository

↓

Repository Executor

↓

One SQL Statement

↓

PostgreSQL
```

Outcome:

Infrastructure has transitioned from simple CRUD repositories into reusable persistence infrastructure.

---

# Phase 5 — Relational Database Design

Purpose:

Refine the existing CSBank schema using enterprise database engineering principles.

Topics include:

- Normalization
- Denormalization
- Composite Keys
- Candidate Keys
- Alternate Keys
- Many-to-Many relationships
- Index strategy
- Constraint design
- ERD refinement
- Schema evolution

---

# Phase 6 — Entity Framework Core

Learn EF Core only after understanding:

- SQL
- Relational modeling
- Dapper
- Repository design
- Persistence engineering

The objective is to understand EF Core as an abstraction rather than a replacement for SQL.

---

# Remaining Roadmap

## Phase 7 — Performance

- Query optimization
- EXPLAIN ANALYZE
- Big-O analysis
- Memory optimization

---

## Phase 8 — Algorithms

Apply algorithms where they improve backend processing and data handling.

---

## Phase 9 — Trees & Hierarchies

Model recursive business structures.

---

## Phase 10 — Networking

REST, HTTP, HTTPS, API design and idempotency.

---

## Phase 11 — Advanced Concurrency

Topics include:

- Transaction isolation
- Optimistic concurrency
- Deadlocks
- Retry strategies
- Concurrent updates

---

## Phase 12 — Security

Authentication, Authorization, BCrypt, JWT, validation and secure persistence.

---

## Phase 13 — Caching

Memory Cache, Redis, distributed caching and cache invalidation.

---

## Phase 14 — Testing

xUnit

NSubstitute

Integration Testing

Repository Testing

Application Testing

API Testing

---

## Phase 15 — Deployment & DevOps

Docker

CI/CD

Cloud Deployment

Logging

Monitoring

Configuration Management

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

By the completion of CSBank, the project should demonstrate practical knowledge of:

- Clean Architecture
- Software Engineering
- PostgreSQL
- Database Engineering
- Dapper
- Persistence Engineering
- Business Operations Engineering
- Relational Database Design
- Entity Framework Core
- Performance Engineering
- Networking
- Concurrency
- Security
- Caching
- Testing
- Deployment

CSBank is intended to be more than a portfolio project.

It is a long-term engineering project designed to demonstrate not only how backend systems are built, but why each architectural decision exists and how each abstraction is constructed from first principles.