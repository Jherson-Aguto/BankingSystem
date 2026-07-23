# Path.md

# CSBank Learning Path

This roadmap is designed to build **CSBank** while learning backend engineering from first principles.

Each phase introduces new concepts only after the previous foundation has been understood, ensuring every abstraction is learned through implementation rather than memorization.

The objective is not simply to build a banking system, but to understand **why each engineering concept exists** before relying on higher-level frameworks.

---

# Learning Philosophy

CSBank follows one fundamental principle:

> **Understand the abstraction before using the abstraction.**

Every technology introduced in this roadmap should explain a concept that has already been implemented manually.

Learning progresses from concepts to abstractions:

```text
Programming

↓

Object-Oriented Programming

↓

Software Engineering

↓

Database Engineering

↓

Persistence Engineering

↓

Business Operations Engineering

↓

Relational Database Design

↓

Entity Framework Core

↓

Performance Engineering

↓

Production Engineering
```

Frameworks should increase productivity—not replace understanding.

---

# Current Progress

| Phase | Status |
|--------|--------|
| Phase 1–3 — Clean Architecture & Software Engineering | ✅ Complete |
| Phase 4A — PostgreSQL & Database Engineering | ✅ Complete |
| Phase 4B — Persistence & Business Operations Engineering | 🚧 Current |
| Phase 5 — Relational Database Design | ⏳ Planned |
| Phase 6 — Entity Framework Core | ⏳ Planned |

Current milestone:

The SQL foundation has been completed.

The project has transitioned from learning individual SQL statements to designing complete business operations.

Current learning focuses on building reusable persistence infrastructure and transaction-safe banking operations.

---

# Learning Roadmap

```mermaid
graph TD

A[Phase 1–3<br/>Architecture & Software Engineering]

--> B[Phase 4A<br/>Database Engineering]

--> C[Phase 4B<br/>Persistence & Business Operations]

--> D[Phase 5<br/>Relational Database Design]

--> E[Phase 6<br/>Entity Framework Core]

--> F[Phase 7<br/>Performance Engineering]

--> G[Phase 8<br/>Algorithms & Data Structures]

--> H[Phase 9<br/>Trees & Hierarchies]

--> I[Phase 10<br/>Networking & REST]

--> J[Phase 11<br/>Advanced Concurrency]

--> K[Phase 12<br/>Security]

--> L[Phase 13<br/>Caching]

--> M[Phase 14<br/>Testing]

--> N[Phase 15<br/>Deployment & DevOps]
```

---

# Phase 1–3 — Clean Architecture & Software Engineering ✅

Purpose:

Understand how enterprise applications separate responsibilities before introducing persistence.

Concepts learned:

- Clean Architecture
- Solution organization
- Domain Models
- Domain Services
- Business Rules
- DTOs
- Manual Mapping
- Repository Abstractions
- Dependency Injection
- Application Services
- Customer Registration

Architecture:

```text
HTTP Request

↓

API

↓

Application

↓

Domain

↓

Repository Interface

↓

Mock Repository
```

Major outcome:

Developed a complete architecture independent of any database or ORM.

---

# Phase 4A — PostgreSQL & Database Engineering ✅

Purpose:

Understand how relational databases store, protect and retrieve data before introducing persistence libraries.

Concepts learned:

## Database Fundamentals

- CREATE DATABASE
- Schemas
- Tables
- Data Types

## CRUD

- INSERT
- SELECT
- UPDATE
- DELETE
- RETURNING
- Writable CTEs

## Relationships

- Primary Keys
- Foreign Keys
- One-to-One
- One-to-Many

## Transactions

- BEGIN
- COMMIT
- ROLLBACK
- Statement-level atomicity
- Transaction-level atomicity

## Constraints

- UNIQUE
- CHECK
- Referential Integrity
- Cascade behaviors

## Query Design

- JOINs
- Aggregation
- GROUP BY
- COUNT
- Explicit column selection

## ORM Mental Model

Understand:

- PostgreSQL stores relational data.
- SQL reconstructs relationships.
- Dapper executes SQL.
- EF Core abstracts persistence.

Major outcome:

Transitioned from isolated SQL statements to complete relational workflows.

---

# Phase 4B — Persistence & Business Operations Engineering 🚧

Purpose:

Understand how enterprise applications execute business operations safely and efficiently.

Technologies:

- PostgreSQL
- Npgsql
- Dapper

Infrastructure concepts:

- Connection Factory
- Repository Pattern
- Repository Executor
- Dependency Injection
- SQL organization
- Parameterized SQL

Language concepts:

- Delegates
- Func<>
- Lambda Expressions
- Higher-Order Functions

Persistence concepts:

- Transaction management
- Atomic business operations
- Repository orchestration
- Single SQL statement workflows
- Common Table Expressions (CTEs)
- Row-level locking (`FOR UPDATE`)
- Race condition prevention
- Exception propagation

Business concepts:

- Account creation
- Ledger design
- Audit logging
- Balance consistency
- Business workflow modeling

Application flow:

```text
HTTP Request

↓

API

↓

Application

↓

Domain

↓

Repository

↓

Repository Executor

↓

Dapper

↓

PostgreSQL
```

Major outcome:

Transition from implementing CRUD repositories to designing reusable persistence infrastructure and transaction-safe business operations.

---

# Phase 5 — Relational Database Design

Purpose:

Learn how enterprise databases evolve beyond CRUD.

Topics:

- One-to-One
- One-to-Many
- Many-to-Many
- Composite Keys
- Candidate Keys
- Alternate Keys
- Normalization (1NF–3NF)
- Denormalization
- Constraint Design
- Index Strategy
- Schema Evolution
- ERD Refinement

Major outcome:

Understand how database design supports long-term maintainability before introducing ORM mapping.

---

# Phase 6 — Entity Framework Core

Purpose:

Learn EF Core as an abstraction built upon concepts already understood.

Learn:

- DbContext
- DbSet
- LINQ
- Fluent API
- Entity Configuration
- Migrations
- Change Tracking
- Relationship Mapping
- Value Conversions
- Loading Strategies

Major outcome:

Recognize the SQL and persistence behavior generated by EF Core rather than treating it as a black box.

---

# Phase 7 — Performance Engineering

Topics:

Database:

- Query Optimization
- Query Plans
- EXPLAIN ANALYZE
- Index Strategy

Application:

- Big-O Analysis
- Collection Performance
- Memory Usage

Goal:

Understand how engineering decisions affect scalability.

---

# Phase 8 — Algorithms & Data Structures

Topics:

- Binary Search
- Merge Sort
- Quick Sort
- Hash-based Lookups
- Efficient Collection Processing

Purpose:

Apply algorithms where they improve backend processing rather than studying them in isolation.

---

# Phase 9 — Trees & Hierarchies

Topics:

- Recursive Traversal
- Tree Structures
- Parent-child Relationships
- Aggregation
- Recursive SQL

Purpose:

Model hierarchical business data.

---

# Phase 10 — Networking & REST

Topics:

- HTTP
- REST
- HTTPS
- Status Codes
- CORS
- Idempotency
- API Design

Purpose:

Understand communication between distributed systems.

---

# Phase 11 — Advanced Concurrency

Topics:

- Transaction Isolation
- Optimistic Concurrency
- Pessimistic Locking
- Deadlocks
- Retry Strategies
- Concurrent Updates
- Race Conditions

Purpose:

Design systems that remain correct under simultaneous requests.

---

# Phase 12 — Security

Topics:

- Password Hashing
- BCrypt
- JWT Authentication
- Authorization
- Input Validation
- SQL Injection Prevention
- Secure DTO Projection

Purpose:

Protect business operations and sensitive data.

---

# Phase 13 — Caching

Topics:

- IMemoryCache
- Distributed Cache
- Redis
- Cache-aside Pattern
- Cache Invalidation

Purpose:

Improve application performance while maintaining consistency.

---

# Phase 14 — Testing

Technologies:

- xUnit
- NSubstitute

Testing focus:

- Domain Services
- Application Services
- Repository Implementations
- API Endpoints
- Integration Testing

Purpose:

Verify correctness and prevent regressions.

---

# Phase 15 — Deployment & DevOps

Topics:

- Docker
- Docker Compose
- CI/CD
- Environment Configuration
- Cloud Deployment
- Logging
- Monitoring
- Configuration Management

Purpose:

Operate backend systems reliably in production.

---

# End Goal

Build a production-quality banking backend while understanding every abstraction throughout the backend stack.

By completing CSBank, you should understand:

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
- Algorithms & Data Structures
- Networking
- Concurrency
- Security
- Caching
- Testing
- Deployment

Every phase intentionally builds upon the previous one so that each new abstraction reinforces concepts already understood instead of replacing them.

The objective is not simply to complete CSBank, but to develop the engineering mindset required to design, build and maintain production-quality backend systems.