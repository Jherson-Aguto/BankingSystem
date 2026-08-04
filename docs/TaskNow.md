# Current Status

**Project:** CSBank

**Current Phase:** Phase 8 — Security Engineering 🚧

**Architecture Status:** ✅ Stable

**Current Focus:** Building a Secure Production Backend

**Previous Phase:** Phase 6 — Entity Framework Core ✅

**Performance Status:** Continuous Engineering

---

# Current Task

Phase 6 is considered complete.

The objective of this phase was to understand Entity Framework Core as a persistence abstraction rather than treating it as a replacement for SQL.

The project intentionally follows a hybrid persistence architecture:

- Writes → Entity Framework Core
- Reads → Dapper

Repositories remain responsible for persistence while the Domain remains persistence-agnostic.

Entity Framework Core is used where Unit of Work and Change Tracking provide value.

Dapper continues to be used for handcrafted read queries requiring precise SQL control and predictable performance.

---

# Completed Features

## User Management

- Register User
- Read User
- Update User

## Banking

- Register Account
- Deposit
- Transfer

## Transaction History

- Read Transaction History
- Offset Pagination
- Ordered by Creation Date (Newest First)

---

# Phase 6 Learning Outcomes

Completed concepts:

- DbContext
- DbSet
- Dependency Injection
- Fluent API
- Entity Configurations
- Relationship Mapping
- Navigation Properties
- PostgreSQL Enum Mapping
- Change Tracker
- Entity States
- SaveChanges Pipeline
- Tracking vs AsNoTracking
- Generated SQL
- Repository Integration
- Update Aggregate using EF Core
- EF Core vs Dapper trade-offs

Reviewed conceptually:

- Loading Strategies
- Migrations
- Value Converters
- Owned Types

These concepts are understood and can be adopted when future requirements justify their use.

---

# Persistence Architecture

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

       ├── Entity Framework Core (Writes)

       └── Dapper (Reads)

↓

PostgreSQL
```

The database remains the source of truth.

Repositories determine the appropriate persistence implementation.

---

# Engineering Philosophy

Continue following the project's primary principle:

> Understand the abstraction before depending on the abstraction.

Every engineering decision should answer:

- What problem does this solve?
- What SQL is ultimately executed?
- What database concepts does it depend on?
- What trade-offs are introduced?
- Is there measurable evidence that this approach is better?

Performance and maintainability should always be measurable rather than assumed.

---

# Performance Status

Performance engineering is now considered an ongoing responsibility rather than a standalone phase.

Completed work:

- SQL execution plan analysis
- EXPLAIN
- EXPLAIN ANALYZE
- Generated SQL inspection
- EF Core vs Dapper comparisons
- Offset pagination
- Query plan interpretation

Future performance improvements will be introduced whenever new features require them.

---

# Current Phase

## Phase 8 — Security Engineering

Focus on building a backend suitable for production use.

Topics include:

### Authentication

- JWT Access Tokens
- Refresh Tokens
- Token Rotation
- Secure Password Hashing
- Login
- Logout

### Authorization

- Roles
- Policies
- Claims
- Ownership Validation

### API Security

- HTTPS
- CORS
- Rate Limiting
- Request Validation
- Input Sanitization

### Database Security

- Least Privilege
- SQL Injection Prevention
- Secrets Management
- Secure Connection Strings

### Application Security

- Authentication Middleware
- Authorization Middleware
- Secure Exception Handling
- Security Headers

### Auditing

- Login Audit
- Sensitive Action Audit
- Security Events

---

# Current Goal

Transform CSBank from a functional backend into a secure production-ready banking backend.

Future phases will continue expanding features while treating performance, security, maintainability, and scalability as continuous engineering concerns rather than isolated milestones.