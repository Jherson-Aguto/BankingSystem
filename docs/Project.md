# Project.md

# Project Blueprint: CSBank System Evolution

This blueprint describes the long-term evolution of **CSBank**, beginning with **Customer Registration** and gradually expanding into a production-quality banking backend while following **Clean Architecture**.

---

# Current Project Status

## Architecture

**Status:** Phase 3 Complete ✅

Completed:

- Clean Architecture solution structure
- Domain layer
- Application layer
- API layer
- Manual object mapping
- Repository abstractions
- Domain services
- Dependency Injection architecture
- Customer Registration use case (mock implementation)

The project is intentionally paused before persistence while PostgreSQL fundamentals are being learned.

---

# Architecture Design

```
CSBank (Solution)
├── csbank.Domain
│   ├── Domain models
│   ├── Domain services
│   └── Business rules
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

```
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

The API is the composition root and registers Infrastructure implementations.

---

# Phase 1–3 ✅ Complete

Completed:

- Customer Registration endpoint
- Domain validation
- Manual mapping
- DTOs
- Repository interfaces
- Application orchestration
- Dependency Injection
- Mock implementation

Current registration flow:

```
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

Persistence has intentionally not been implemented yet.

---

# Phase 4A — PostgreSQL Fundamentals (Current)

Current focus is learning relational databases before implementing Infrastructure.

Completed:

- CREATE DATABASE
- CREATE TABLE
- Schemas
- Data types
- INSERT
- Multi-row INSERT
- CTE (`WITH`)
- RETURNING
- SELECT
- WHERE
- ORDER BY
- INNER JOIN
- LEFT JOIN
- Parent → Child relationships
- One-to-One relationships

Remaining topics:

- UPDATE
- DELETE
- Multi-table CRUD
- Constraints
- Transactions
- Indexes

Goal:

Become comfortable manipulating relational data before writing repository implementations.

---

# Phase 4B — Infrastructure (Next)

Replace mock repositories with PostgreSQL-backed repositories using Dapper.

Implement:

- PostgreSQL Connection
- Dapper
- Repository implementations
- SQL Queries
- Dependency Injection

Registration flow becomes:

```
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

PostgreSQL
```

No business rules should exist inside Infrastructure.

---

# Phase 5 — EF Core

Once Dapper is understood, introduce EF Core.

Learn:

- DbContext
- DbSet
- Fluent API
- Migrations
- Relationships
- Change Tracking
- LINQ

Purpose:

Understand EF Core as an abstraction over SQL rather than relying on it as a black box.

---

# Phase 6 — Database Design

Improve relational modeling.

Topics:

- Primary Keys
- Foreign Keys
- Unique Constraints
- Check Constraints
- One-to-One
- One-to-Many
- Many-to-Many
- Normalization (1NF–3NF)

---

# Phase 7 — Performance

Database:

- Indexes
- Query plans
- Query optimization

Application:

- Big-O analysis
- Memory usage
- Collections

Practice:

Compare indexed vs non-indexed lookups using seeded customer data.

---

# Phase 8 — Algorithms

Implement algorithms inside the Application layer.

Sorting:

- QuickSort
- MergeSort

Searching:

- Binary Search

Purpose:

Understand algorithmic complexity after retrieving data from the database.

---

# Phase 9 — Trees & Hierarchies

Implement branch hierarchies.

Topics:

- Recursive traversal
- Parent-child trees
- Aggregation
- Tree algorithms

---

# Phase 10 — Networking

Expand the REST API.

Topics:

- HTTP Verbs
- Status Codes
- REST Principles
- CORS
- Idempotency

---

# Phase 11 — Concurrency

Handle concurrent requests.

Topics:

- Transactions
- Optimistic Concurrency
- Duplicate registrations
- Unique constraint violations

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
- Cache invalidation

---

# Phase 14 — Testing

Testing stack:

- xUnit
- NSubstitute

Test:

- Domain services
- Use cases
- Repository abstractions
- API endpoints

---

# Long-Term Goal

Build a production-quality banking backend while understanding every abstraction underneath it.

The objective is not merely to finish CSBank, but to understand:

- Clean Architecture
- Relational Database Design
- PostgreSQL
- Dapper
- EF Core
- Performance
- Algorithms
- Networking
- Security
- Testing

Each phase builds directly on the previous one, ensuring that every technology is learned through practical implementation rather than isolated tutorials.