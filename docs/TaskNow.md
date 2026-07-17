# TaskNow.md

# Current Status

**Project:** CSBank

**Architecture:** ✅ Complete (Phase 1–3)

**Phase 4A — PostgreSQL Fundamentals:** ✅ Complete

**Current Phase:** Phase 4B — Persistence with Dapper

**Next Phase:** Phase 5 — Entity Framework Core

---

# Today's Objective

Replace the mock persistence layer with a real PostgreSQL implementation using **Dapper**.

The objective is **not** to learn another ORM.

The objective is to integrate the SQL knowledge gained during Phase 4A into the existing Clean Architecture without changing the Domain, Application, or API layers.

---

# Phase Goal

Replace:

```text
Repository Interface

↓

Mock Repository
```

with

```text
Repository Interface

↓

Dapper Repository

↓

PostgreSQL
```

Only the persistence implementation should change.

The existing architecture should remain intact.

---

# Learning Objectives

By the end of Phase 4B, you should understand:

- How Dapper executes SQL
- Parameterized SQL
- Mapping database rows to C# objects
- Repository implementations
- Connection management
- Dependency Injection for persistence
- Separating SQL from C# code
- Infrastructure responsibilities within Clean Architecture

---

# Tasks

## 1. Infrastructure Organization

Status: ☐

Prepare the Infrastructure project.

Recommended structure:

```text
csbank.Infrastructure
│
├── Database
│   ├── Connection
│   │   ├── IDbConnectionFactory.cs
│   │   └── PostgreSqlConnectionFactory.cs
│   │
│   └── Sql
│       ├── Customer
│       ├── Account
│       └── Audit
│
├── Repositories
│
├── DI
│
└── Configurations
```

Do not introduce EF Core.

Do not create DbContext.

---

## 2. PostgreSQL Connection

Status: ☐

Learn:

- Npgsql
- Connection strings
- Opening database connections
- Lifetime management

Goal:

Successfully open a PostgreSQL connection from the Infrastructure layer.

---

## 3. Dapper Fundamentals

Status: ☐

Learn:

- QueryAsync
- QuerySingleAsync
- QueryFirstOrDefaultAsync
- ExecuteAsync

Understand that Dapper executes SQL—it does not generate SQL.

---

## 4. Parameterized SQL

Status: ☐

Convert learning SQL into reusable application SQL.

Instead of:

```sql
WHERE id = '7003...'
```

learn:

```sql
WHERE id = @CustomerId
```

All user input should become parameters.

Never concatenate SQL strings.

---

## 5. SQL File Organization

Status: ☐

Move reusable SQL into Infrastructure.

Example:

```text
Infrastructure

Database

Sql

Customer

GetCustomerById.sql

GetCustomerProfile.sql

RegisterCustomer.sql

UpdateCustomer.sql

DeleteCustomer.sql
```

The SQL written during Phase 4A becomes production-ready by replacing hardcoded values with parameters.

---

## 6. Customer Repository

Status: ☐

Implement the first real repository.

Suggested order:

- GetCustomerById
- GetCustomerProfile
- RegisterCustomer

The repository should:

- Load SQL
- Execute SQL using Dapper
- Map results
- Return Domain/Application objects

Business rules remain outside Infrastructure.

---

## 7. Dependency Injection

Status: ☐

Replace the mock repository registration.

Old:

```text
Mock Repository
```

New:

```text
CustomerRepository
```

No API changes should be required.

---

# Completion Checklist

Phase 4B is complete when you can confidently answer **yes** to all of the following:

- ☐ I understand how Dapper executes SQL.
- ☐ I understand parameterized SQL.
- ☐ I can execute SQL from C#.
- ☐ I can map query results to objects.
- ☐ I understand why repositories belong in Infrastructure.
- ☐ I replaced mock persistence without changing Domain or Application.
- ☐ I understand that Dapper is a lightweight data access library rather than an ORM.

---

# Stop Conditions

If you get stuck, stop and ask:

> "What persistence concept am I missing?"

Do not begin EF Core.

Do not introduce DbContext.

Do not introduce LINQ.

Understand Dapper first.

---

# After Phase 4B

Begin **Phase 5 — Entity Framework Core**.

At that point you will already understand:

- SQL
- PostgreSQL
- Transactions
- Constraints
- JOINs
- Repository Pattern
- Dapper
- Parameterized queries
- Infrastructure responsibilities

Only then begin learning:

- DbContext
- DbSet
- Fluent API
- Entity Configuration
- LINQ
- Migrations
- Change Tracking

The objective is to recognize EF Core as a higher-level abstraction over concepts you already understand rather than treating it as a black box.