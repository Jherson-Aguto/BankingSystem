# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, beginning with **Customer Registration** and gradually expanding into a production-quality banking backend while following **Clean Architecture**.

The project is intentionally designed so that every abstraction is learned only after understanding the concepts beneath it.

---

# Current Project Status

## Architecture

**Status:** Phase 1–3 Complete ✅

Completed:

* Clean Architecture solution structure
* Domain layer
* Application layer
* API layer
* Manual object mapping
* Repository abstractions
* Domain services
* Dependency Injection architecture
* Customer Registration use case
* Mock repository implementation

Current status:

The architectural foundation is complete.

The SQL foundation (Phase 4A) has also been completed.

CSBank now transitions into implementing **real persistence** using PostgreSQL and Dapper while preserving the existing architecture.

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
│   ├── Repository Implementations
│   ├── Dapper (Phase 4B)
│   ├── EF Core (Phase 6)
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

# Phase 1–3 — Architecture Foundation ✅

Completed:

* Customer Registration endpoint
* Domain validation
* Domain services
* Manual mapping
* DTOs
* Repository interfaces
* Application orchestration
* Dependency Injection
* Mock persistence

Current request flow:

```text
HTTP Request

↓

API Controller

↓

Application Use Case

↓

Domain Service
        │
        └── Business Rules

↓

Repository Interface

↓

(Mock Repository)
```

Outcome:

A complete Clean Architecture ready for a real persistence implementation.

---

# Phase 4A — PostgreSQL Fundamentals ✅

Purpose:

Understand relational databases before implementing Infrastructure.

Completed:

### Database Fundamentals

* ✅ CREATE DATABASE
* ✅ PostgreSQL CLI
* ✅ Schemas
* ✅ CREATE TABLE
* ✅ Data Types
* ✅ NOT NULL

### CRUD

* ✅ INSERT
* ✅ Multi-row INSERT
* ✅ RETURNING
* ✅ Writable CTEs (`WITH`)
* ✅ SELECT
* ✅ WHERE
* ✅ ORDER BY
* ✅ UPDATE
* ✅ DELETE

### Relationships

* ✅ Primary Keys
* ✅ Foreign Keys
* ✅ One-to-One
* ✅ One-to-Many

### JOINs

* ✅ INNER JOIN
* ✅ LEFT JOIN
* ✅ RIGHT JOIN
* ✅ FULL JOIN (Conceptual)

### Referential Integrity

* ✅ ON DELETE CASCADE
* ✅ ON DELETE NO ACTION
* ✅ ON DELETE SET NULL
* ✅ ON UPDATE CASCADE
* ✅ ON UPDATE NO ACTION
* ✅ ON UPDATE SET NULL

### Transactions

* ✅ BEGIN
* ✅ COMMIT
* ✅ ROLLBACK
* ✅ Autocommit
* ✅ Statement-level atomicity
* ✅ Transaction-level atomicity

### Constraints

* ✅ UNIQUE
* ✅ CHECK

### Indexes

* ✅ CREATE INDEX
* ✅ CREATE UNIQUE INDEX

### Query Design

* ✅ Business-oriented queries
* ✅ Explicit column selection
* ✅ GROUP BY
* ✅ COUNT
* ✅ Aggregation basics

### Multi-Table CRUD Capstone

Completed.

Implemented:

* Customer Registration
* Customer Retrieval
* Customer Updates
* Customer Deletion
* Multi-table JOINs
* Transactions
* Constraints
* Referential Integrity

### ORM Mental Model

Major conceptual milestones:

Understand that:

* PostgreSQL stores relational data—not objects.
* JOINs reconstruct relational data into object graphs.
* Dapper executes SQL directly.
* EF Core builds on top of SQL rather than replacing it.
* `SaveChanges()` ultimately results in SQL statements executed inside transactions.

Outcome:

Transitioned from thinking in isolated SQL statements to complete business operations.

---

# Phase 4B — Infrastructure with Dapper 🚧

Current Phase.

Replace:

```text
Repository Interface

↓

(Mock Repository)
```

with:

```text
Repository Interface

↓

Infrastructure Repository

↓

Dapper

↓

PostgreSQL
```

Implement:

* PostgreSQL connection
* Npgsql
* Dapper
* Connection Factory
* Repository implementations
* SQL execution
* Parameterized SQL
* Dependency Injection

Recommended Infrastructure organization:

```text
Infrastructure

├── Database
│   ├── Connection
│   └── Sql
│
├── Repositories
│
├── Configurations
│
└── DI
```

Business rules remain inside the Domain layer.

Infrastructure remains responsible only for persistence.

Current request flow becomes:

```text
HTTP Request

↓

API

↓

Application

↓

Domain Service

↓

Repository Interface

↓

Infrastructure Repository

↓

Dapper

↓

PostgreSQL
```

---

# Phase 5 — Relational Database Design

After understanding SQL execution through Dapper, refine the database itself.

Topics:

* One-to-One
* One-to-Many
* Many-to-Many
* Composite Keys
* Candidate Keys
* Alternate Keys
* Normalization (1NF–3NF)
* Denormalization trade-offs
* Constraint design
* Index strategy
* Schema evolution
* ERD refinement

Purpose:

Improve the existing CSBank schema using sound database engineering principles before introducing higher-level ORM abstractions.

---

# Phase 6 — Entity Framework Core

Only after understanding:

* SQL
* Dapper
* Repository implementations
* Relational database design

Learn:

* DbContext
* DbSet
* Entity Configuration
* Fluent API
* LINQ
* Change Tracking
* Relationship Mapping
* Value Conversions
* Migrations

Purpose:

Understand EF Core as a productivity layer built on top of concepts already understood rather than treating it as a black box.

---

# Phase 7 — Performance

Database:

* Query plans
* EXPLAIN ANALYZE
* Query optimization
* Index strategy

Application:

* Big-O analysis
* Collection performance
* Memory usage

Practice:

Compare indexed and non-indexed queries using realistic seeded CSBank data.

---

# Phase 8 — Algorithms

Implement algorithms inside the Application layer.

Topics:

* Binary Search
* Merge Sort
* Quick Sort
* Efficient collection processing

Purpose:

Understand efficient in-memory processing after retrieving relational data.

---

# Phase 9 — Trees & Hierarchies

Implement hierarchical banking structures.

Topics:

* Recursive traversal
* Parent-child trees
* Aggregation
* Tree algorithms

---

# Phase 10 — Networking

Expand the REST API.

Topics:

* HTTP
* REST
* Status Codes
* HTTPS
* CORS
* Idempotency
* API design principles

---

# Phase 11 — Concurrency

Handle concurrent requests safely.

Topics:

* Optimistic concurrency
* Transaction isolation
* Concurrent updates
* Duplicate registrations
* Unique constraint handling
* Race conditions

---

# Phase 12 — Security

Implement:

* Password hashing abstraction
* BCrypt
* Authentication
* Authorization
* Secure DTO projection
* Input validation
* SQL Injection prevention

---

# Phase 13 — Caching

Learn:

* IMemoryCache
* Distributed Cache
* Redis
* Cache invalidation
* Cache-aside pattern

---

# Phase 14 — Testing

Testing stack:

* xUnit
* NSubstitute

Test:

* Domain services
* Application use cases
* Repository implementations
* API endpoints
* Integration tests

---

# Phase 15 — Deployment & DevOps

Learn:

* Docker
* Docker Compose
* CI/CD
* Environment configuration
* Cloud deployment
* Logging
* Monitoring

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

The objective is not merely to finish CSBank.

The objective is to understand:

* Clean Architecture
* PostgreSQL
* SQL
* Database Engineering
* Dapper
* Relational Database Design
* Entity Framework Core
* Performance
* Algorithms
* Networking
* Concurrency
* Security
* Caching
* Testing
* Deployment

Every phase intentionally builds on the previous one so that each abstraction explains the next.

By the end of this roadmap, CSBank should serve not only as a portfolio project, but also as a practical demonstration of backend engineering principles—from relational database fundamentals through production-ready backend architecture.
