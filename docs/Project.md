# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, beginning with **Customer Registration** and gradually expanding into a production-quality banking backend while following **Clean Architecture**.

The project is intentionally designed so that every abstraction is learned only after understanding the concepts beneath it.

The objective is not simply to build a banking system, but to understand **why every architectural decision exists** before relying on higher-level frameworks or abstractions.

---

# Current Project Status

## Architecture

**Status:** Phase 1–4B Active 🚧

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
- PostgreSQL integration
- Dapper persistence
- Repository Executor
- Higher-Order Transaction Executor

The architectural foundation is now considered stable.

Current work focuses on engineering complete banking business operations while preserving Clean Architecture and maximizing PostgreSQL's transactional capabilities.

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

Repositories primarily:

- Choose SQL
- Supply parameters
- Execute SQL
- Map results
- Return application models

Repositories no longer own:

- Database connections
- Transaction creation
- Commit
- Rollback

---

## Transaction Philosophy

Infrastructure owns:

- Connection lifecycle
- Transaction lifecycle
- Commit
- Rollback
- Exception propagation

Reusable Higher-Order Functions centralize transaction execution so repositories remain focused on business persistence.

---

## SQL Philosophy

Whenever practical, one business operation should execute as:

```text
One Transaction

↓

One SQL Statement

↓

Multiple CTEs

↓

One Database Round Trip
```

The objective is to leverage PostgreSQL as a relational execution engine rather than treating it as simple storage.

---

## Ledger Philosophy

Account balance is mutable.

Transaction history is immutable.

The ledger represents the historical source of truth, while account balances are the current projection.

---

## Audit Philosophy

Audit logging exists independently from business entities.

Audit logs capture:

- Entity affected
- Action performed
- Who performed the action
- When it occurred
- Optional before values
- Optional after values
- Request metadata

Business operations decide when before/after snapshots are valuable.

For example:

- Customer registration records the event.
- Deposit records balance changes.
- Some operations intentionally leave JSON values null when no meaningful state comparison exists.

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
│   ├── DTOs
│   ├── Use Cases
│   ├── Repository Interfaces
│   ├── Manual Mappers
│   └── Application Services
│
├── csbank.Infrastructure
│   ├── Database
│   ├── SQL Queries
│   ├── Repository Implementations
│   ├── Repository Executor
│   ├── Configurations
│   ├── Dapper
│   ├── Npgsql
│   └── Database Connectivity
│
└── csbank.Api
    ├── Controllers
    ├── Middleware
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

The API remains the Composition Root.

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

Database Transaction

↓

Dapper

↓

PostgreSQL
```

---

# Infrastructure Evolution

## Stage 1

```text
Mock Repository
```

Purpose:

Validate architecture before persistence.

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

Introduce real persistence.

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

Infrastructure now centrally manages:

- Connection lifecycle
- Transactions
- Commit
- Rollback
- Exception propagation

Repositories contain almost exclusively business persistence logic.

---

# Phase 1–3 — Architecture Foundation ✅

Completed.

Major concepts:

- Clean Architecture
- Domain Services
- Repository Pattern
- DTOs
- Manual Mapping
- Dependency Injection
- Application Services

Outcome:

A persistence-independent backend architecture.

---

# Phase 4A — PostgreSQL Fundamentals ✅

Completed.

Topics learned:

## Database Engineering

- Schemas
- Tables
- Constraints
- Relationships
- UUIDs
- Indexes

## SQL

- CRUD
- JOINs
- CTEs
- Transactions
- Referential Integrity

## ORM Mental Model

Understanding:

- PostgreSQL stores relational data.
- JOINs reconstruct object graphs.
- Dapper executes SQL directly.
- EF Core builds abstractions over SQL.

Outcome:

Strong relational database fundamentals before persistence engineering.

---

# Phase 4B — Persistence & Business Operations Engineering 🚧

Current Phase.

Current stack:

- PostgreSQL
- Npgsql
- Dapper

Current engineering focus:

- Repository implementations
- Repository Executor
- Higher-Order Functions
- Transaction management
- Business operation modeling
- Ledger implementation
- Audit logging
- Row-level locking
- Atomic SQL workflows
- Parameterized SQL
- CTE-based business operations

## Current Business Operations

Customer Registration

- Customer persistence ✅
- Private information persistence ✅
- Audit logging ✅

Account Creation

- Account creation ✅
- Audit logging ✅

Checking Account

- Creation ✅
- Audit logging ✅

Savings Account

- Creation ✅
- Audit logging ✅

Deposit

- Atomic SQL workflow ✅
- Row locking (`FOR UPDATE`) ✅
- Transaction history ✅
- Audit logging ✅

Withdraw

- Planned ⏳

Transfer

- Planned ⏳

## Unit Testing

Current coverage:

- Domain account number generator ✅
- Domain reference number generator ✅
- Parallel uniqueness validation ✅

Testing is intentionally limited during this phase.

The objective is to continue engineering business operations rather than pursuing exhaustive test coverage.

---

# Phase 5 — Relational Database Design

Topics:

- Normalization
- Denormalization
- Composite Keys
- Candidate Keys
- Alternate Keys
- Index strategy
- Constraint design
- ERD refinement
- Schema evolution

---

# Phase 6 — Entity Framework Core

Learn EF Core only after understanding:

- SQL
- PostgreSQL
- Dapper
- Repository design
- Persistence engineering

The goal is to understand the abstraction instead of depending on it blindly.

---

# Remaining Roadmap

## Phase 7 — Performance

- Query optimization
- EXPLAIN ANALYZE
- Memory optimization

---

## Phase 8 — Algorithms

Apply algorithms where they improve backend systems.

---

## Phase 9 — Trees & Hierarchies

Recursive business models.

---

## Phase 10 — Networking

- REST
- HTTP
- HTTPS
- API Design
- Idempotency

---

## Phase 11 — Advanced Concurrency

- Isolation Levels
- Deadlocks
- Retry strategies
- Optimistic concurrency
- Concurrent updates

---

## Phase 12 — Security

- Authentication
- Authorization
- JWT
- BCrypt
- Validation
- Secure persistence

---

## Phase 13 — Caching

- Memory Cache
- Redis
- Distributed caching
- Cache invalidation

---

## Phase 14 — LINQ

Purpose:

Learn LINQ as a C# language feature before writing substantial automated tests.

Topics:

- Deferred execution
- IEnumerable vs IQueryable
- Projection
- Filtering
- Ordering
- Grouping
- Aggregation

---

## Phase 15 — Testing

Purpose:

Verify business behavior rather than simply learning xUnit syntax.

Topics:

- Testing fundamentals
- xUnit
- Domain tests
- Infrastructure tests
- Integration tests
- API tests
- Concurrency tests

---

## Phase 16 — Deployment & DevOps

- Docker
- CI/CD
- Cloud Deployment
- Logging
- Monitoring
- Configuration Management

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

By completing CSBank, the project should demonstrate practical knowledge of:

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
- Algorithms
- Networking
- Concurrency
- Security
- Caching
- LINQ
- Testing
- Deployment

CSBank is intended to be more than a portfolio project.

It is a long-term engineering project designed to demonstrate not only how backend systems are built, but why each architectural decision exists and how each abstraction is constructed from first principles.