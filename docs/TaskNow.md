# TaskNow.md

# Current Status

**Project:** CSBank

**Architecture:** ✅ Complete (Phase 1–3)

**Phase 4A — PostgreSQL Fundamentals:** ✅ Complete

**Phase 4B — Persistence with Dapper:** 🚧 In Progress (~90%)

**Next Phase:** Phase 5 — Entity Framework Core (After completing remaining Dapper concepts)

---

# Today's Objective

Complete the production-ready Dapper persistence layer and fully understand every component before moving to Entity Framework Core.

The goal is no longer simply "making it work."

The goal is understanding:

- how Dapper communicates with ADO.NET
- how ADO.NET communicates with PostgreSQL
- why Clean Architecture isolates persistence
- why Dependency Injection allows swapping implementations

---

# Current Implementation Status

## Clean Architecture

Status: ✅

```
API
    ↓
Application
    ↓
Repository Interface
    ↓
Infrastructure (Dapper)
    ↓
Npgsql
    ↓
PostgreSQL
```

No business logic exists inside Infrastructure.

---

## PostgreSQL

Status: ✅

Completed:

- Database schemas
- Constraints
- Foreign Keys
- UUIDs
- INSERT
- JOINs
- CTEs
- Transactions
- Parameterized SQL

---

## Infrastructure

Status: ✅

Current structure

```text
Infrastructure
│
├── Database
│   ├── Connections
│   │   ├── IDbConnectionFactory.cs
│   │   └── PostgreSqlConnectionFactory.cs
│   │
│   └── PostgreSQL
│       └── SaveUserDetails.cs
│
├── Mapper
│
├── Repositories
│
└── DI
```

---

## Connection Factory

Status: ✅

Implemented:

- IDbConnectionFactory
- PostgreSqlConnectionFactory
- Npgsql
- Connection String
- appsettings.Development.json
- Dependency Injection registration

Current understanding:

- One connection per request
- Connection Pooling
- Connection Factory responsibility
- Configuration separation

Still reviewing:

- IServiceProvider factory delegate
- Configuration binding

---

## Dapper

Status: ✅

Learned:

- ExecuteAsync
- QueryFirstAsync<T>()
- Anonymous parameter objects
- SQL parameter binding
- Generic result mapping

Understand:

Dapper executes SQL.

It does **not** generate SQL.

---

## Repository

Status: ✅

Implemented:

- SaveUserDetailsRepository

Uses:

- Connection Factory
- Dapper
- SQL Constants
- Parameter Mapping
- Transactions
- Logging

---

## SQL Organization

Status: ✅

SQL separated from C#

Current example:

```text
Database
└── PostgreSQL
    └── SaveUserDetails.cs
```

Future organization:

```text
Database
└── PostgreSQL
    ├── Customer
    ├── Accounts
    ├── Transactions
    └── Audit
```

---

## Transactions

Status: ✅

Implemented:

- BeginTransaction()
- Commit()
- Rollback()

Still studying:

- IDisposable
- using
- await using
- Transaction lifetime

---

## Dependency Injection

Status: ✅

Implemented:

- Repository registration
- Connection Factory registration
- Configuration injection

Still reviewing:

- Delegate registrations

Example:

```csharp
builder.Services.AddScoped<IDbConnectionFactory>(
    provider =>
    {
        var connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection");

        return new PostgreSqlConnectionFactory(connectionString!);
    });
```

---

## Configuration

Status: ✅

Implemented:

- appsettings.Development.json
- ConnectionStrings
- Environment variable override

Understand:

```
ConnectionStrings__DefaultConnection
```

can replace

```json
ConnectionStrings:
    DefaultConnection
```

without recompiling.

---

## Logging

Status: ✅

Implemented:

- ILogger<T>

Still to improve:

- Exception handling
- Global exception middleware
- ProblemDetails responses

---

# Remaining Learning Objectives

These are the remaining concepts to understand before leaving Dapper.

## 1. ADO.NET

Status: 🚧

Need to fully understand:

- IDbConnection
- IDbCommand
- IDataReader
- IDisposable

Most important realization:

Dapper is built on top of ADO.NET.

---

## 2. Connection Lifecycle

Status: 🚧

Understand exactly:

- Open()
- Close()
- Dispose()
- Connection Pooling

---

## 3. Transactions

Status: 🚧

Need deeper understanding of:

- Isolation
- Lifetime
- Rollback behavior
- Nested transactions

---

## 4. Resource Management

Status: 🚧

Need confidence with:

```csharp
using

using var

await using
```

and when each should be used.

---

## 5. Error Handling

Status: 🚧

Improve:

- Global exception middleware
- API responses
- Validation responses
- Logging strategy

---

# Completion Checklist

Phase 4B is complete when all are true:

- [x] Repository implemented
- [x] Dapper integrated
- [x] SQL separated
- [x] PostgreSQL connected
- [x] Connection Factory implemented
- [x] Dependency Injection configured
- [x] Transactions implemented
- [x] Logging implemented
- [x] Parameterized SQL understood
- [ ] Fully understand ADO.NET
- [ ] Fully understand IDisposable / using
- [ ] Fully understand Transaction lifetime
- [ ] Comfortable explaining every line of repository code without assistance

---

# Stop Conditions

Do **not** begin EF Core until the remaining concepts above are understood.

If stuck, ask:

> "What infrastructure concept am I missing?"

rather than

> "How do I make this compile?"

---

# After Phase 4B

Begin **Phase 5 — Entity Framework Core**.

By then, EF Core should feel like a convenience layer built on concepts you already understand:

- ADO.NET
- Npgsql
- Dapper
- SQL
- PostgreSQL
- Transactions
- Connection Pooling
- Repository Pattern
- Dependency Injection
- Infrastructure
- Configuration
- Logging
- Parameter Mapping

Only then begin:

- DbContext
- DbSet
- LINQ
- Change Tracking
- Migrations
- Fluent API
- Entity Configuration

The goal is to recognize Entity Framework Core as an abstraction over lower-level persistence concepts rather than relying on it as a black box.