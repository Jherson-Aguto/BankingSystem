# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, beginning with **Customer Registration** and gradually expanding into a production-quality banking backend while following **Clean Architecture**.

The project is intentionally designed so that every abstraction is learned only after understanding the concepts beneath it.

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
- Customer Registration use case
- Mock repository implementation

Current status:

The architecture foundation is complete.

The only remaining prerequisite before persistence is the **Multi-Table CRUD Capstone**, which completes Phase 4A.

After the capstone, CSBank resumes active development using PostgreSQL and Dapper.

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
│   ├── Repository Implementations
│   ├── Dapper (Phase 4B)
│   ├── EF Core (Later)
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

- Customer Registration endpoint
- Domain validation
- Domain services
- Manual mapping
- DTOs
- Repository interfaces
- Application orchestration
- Dependency Injection
- Mock persistence

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

IRepository

↓

(Mock Repository)
```

This architecture is considered complete.

---

# Phase 4A — PostgreSQL Fundamentals

**Status:** Nearly Complete (Capstone Remaining)

Purpose:

Understand relational databases before implementing Infrastructure.

Completed:

### Database Fundamentals

- ✅ CREATE DATABASE
- ✅ PostgreSQL CLI
- ✅ Schemas
- ✅ CREATE TABLE
- ✅ Data Types
- ✅ NOT NULL

### CRUD

- ✅ INSERT
- ✅ Multi-row INSERT
- ✅ RETURNING
- ✅ Common Table Expressions (`WITH`)
- ✅ SELECT
- ✅ WHERE
- ✅ ORDER BY
- ✅ UPDATE
- ✅ DELETE

### Relationships

- ✅ Primary Keys
- ✅ Foreign Keys
- ✅ One-to-One
- ✅ One-to-Many

### JOINs

- ✅ INNER JOIN
- ✅ LEFT JOIN
- ✅ RIGHT JOIN
- ✅ FULL JOIN (Conceptual)

### Referential Integrity

- ✅ ON DELETE CASCADE
- ✅ ON DELETE NO ACTION
- ✅ ON DELETE SET NULL
- ✅ ON UPDATE CASCADE
- ✅ ON UPDATE NO ACTION
- ✅ ON UPDATE SET NULL

### Transactions

- ✅ BEGIN
- ✅ COMMIT
- ✅ ROLLBACK
- ✅ Autocommit
- ✅ Statement-level atomicity
- ✅ Transaction-level atomicity

### Constraints

- ✅ UNIQUE
- ✅ CHECK

### Indexes

- ✅ CREATE INDEX
- ✅ CREATE UNIQUE INDEX

### ORM Mental Model

Major conceptual milestone:

Understand that:

- Dapper executes SQL directly.
- EF Core abstracts SQL.
- Objects do not exist inside PostgreSQL.
- JOINs reconstruct relational data.
- `SaveChanges()` represents multiple SQL statements inside a transaction.

Remaining:

## Multi-Table CRUD Capstone

The capstone is not a new SQL topic.

Instead, it integrates everything learned into realistic CSBank workflows.

Target schema:

```text
Customer
│
├── PrivateInformation
├── Account
├── SavingsAccount
└── Loan
```

Objectives:

- Register customers
- Create related records
- Query complete customer information
- Update related data
- Delete related data safely
- Apply transactions
- Observe constraints
- Observe referential integrity

Goal:

Transition from isolated SQL statements to complete business operations.

---

# Phase 4B — Infrastructure (Next)

After completing the capstone, persistence will finally be implemented.

Replace:

```text
IRepository

↓

(Mock Repository)
```

with:

```text
IRepository

↓

Infrastructure Repository

↓

Dapper

↓

PostgreSQL
```

Implement:

- PostgreSQL connection
- Dapper
- Repository implementations
- SQL execution
- Dependency Injection

Customer Registration flow becomes:

```text
HTTP Request

↓

API

↓

Application

↓

Domain Service

↓

IRepository

↓

Infrastructure Repository

↓

Dapper

↓

PostgreSQL
```

Business rules remain inside the Domain layer.

Infrastructure is responsible only for persistence.

---

# Phase 5 — EF Core

Only after understanding SQL and Dapper.

Learn:

- DbContext
- DbSet
- Fluent API
- Migrations
- Relationships
- Change Tracking
- LINQ

Purpose:

Understand EF Core as a productivity layer built on top of SQL rather than treating it as a black box.

---

# Phase 6 — Relational Database Design

Improve relational modeling.

Topics:

- Primary Keys
- Foreign Keys
- One-to-One
- One-to-Many
- Many-to-Many
- Normalization (1NF–3NF)

Purpose:

Refine the existing CSBank database rather than learning SQL syntax.

---

# Phase 7 — Performance

Database:

- Query plans
- Query optimization
- Index strategy

Application:

- Big-O analysis
- Collection performance
- Memory usage

Practice:

Compare indexed and non-indexed queries using seeded CSBank data.

---

# Phase 8 — Algorithms

Implement algorithms inside the Application layer.

Topics:

- Binary Search
- QuickSort
- MergeSort

Purpose:

Understand efficient in-memory processing after retrieving relational data.

---

# Phase 9 — Trees & Hierarchies

Implement hierarchical banking structures.

Topics:

- Recursive traversal
- Parent-child trees
- Aggregation
- Tree algorithms

---

# Phase 10 — Networking

Expand the REST API.

Topics:

- HTTP
- REST
- Status Codes
- CORS
- HTTPS
- Idempotency

---

# Phase 11 — Concurrency

Handle concurrent requests safely.

Topics:

- Optimistic concurrency
- Duplicate registrations
- Transaction isolation
- Concurrent updates
- Unique constraint handling

---

# Phase 12 — Security

Implement:

- Password hashing abstraction
- BCrypt
- Authentication
- Authorization
- Secure DTO projection

---

# Phase 13 — Caching

Learn:

- IMemoryCache
- Distributed Cache
- Redis
- Cache invalidation

---

# Phase 14 — Testing

Testing stack:

- xUnit
- NSubstitute

Test:

- Domain services
- Application use cases
- Repository implementations
- API endpoints

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction beneath it.

The objective is not merely to finish CSBank.

The objective is to understand:

- Clean Architecture
- Relational Database Design
- PostgreSQL
- SQL
- Dapper
- EF Core
- Performance
- Algorithms
- Networking
- Concurrency
- Security
- Caching
- Testing

Each phase intentionally builds on the previous one so every technology is learned through implementation rather than memorization.

By the end of this roadmap, CSBank should serve not only as a portfolio project, but also as a practical demonstration of backend engineering principles from database fundamentals to production-ready architecture.