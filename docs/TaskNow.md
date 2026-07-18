# TaskNow.md

# Current Status

**Project:** CSBank

**Architecture:** ✅ Complete (Phase 1–3)

**Phase 4A — PostgreSQL Fundamentals:** ✅ Complete

**Phase 4B — Persistence with Dapper:** 🚧 In Progress (~95%)

**Next Milestone:** Expand the repository layer by implementing additional banking features using Dapper.

**Next Phase:** Phase 5 — Entity Framework Core

---

# Today's Objective

Continue building production-ready persistence using Dapper while reinforcing software engineering concepts through real banking features.

The focus is no longer on learning Dapper syntax.

The focus is on implementing use cases while understanding the abstractions being used.

---

# Current Implementation Status

## Clean Architecture

Status: ✅

```
API
    ↓
Application
    ↓
Repository Interfaces
    ↓
Infrastructure (Dapper)
    ↓
Npgsql
    ↓
PostgreSQL
```

Business rules remain isolated from Infrastructure.

---

## PostgreSQL

Status: ✅

Completed:

* Database Schemas
* Tables
* UUIDs
* Foreign Keys
* Constraints
* INSERT
* UPDATE
* JOINs
* CTEs
* Transactions
* Parameterized SQL

---

## Infrastructure

Status: ✅

Current structure follows a feature-oriented organization.

Implemented:

* Connection Factory
* Dapper repositories
* SQL organization
* Repository interfaces
* Parameter mapping
* Logging
* Transactions

---

## Connection Factory

Status: ✅

Implemented:

* IDbConnectionFactory
* PostgreSqlConnectionFactory
* Npgsql
* Connection String
* Dependency Injection

Understand:

* One connection per repository operation
* Connection pooling
* Factory responsibility
* Configuration separation

---

## Dapper

Status: ✅

Comfortable using:

* ExecuteAsync()
* QuerySingleAsync<T>()
* QueryFirstAsync<T>()
* Anonymous parameter objects
* Generic mapping
* Parameterized SQL

Understand:

Dapper executes SQL against an existing `IDbConnection`.

It simplifies ADO.NET but does not replace it.

---

## Repository Layer

Status: ✅

Implemented:

* Save User
* Read User

Repositories currently use:

* Connection Factory
* Dapper
* SQL constants
* Parameter mapping
* Transactions
* Logging

---

## Transactions

Status: ✅

Implemented:

* BeginTransaction()
* Commit()
* Rollback()

Understand:

Repositories own transaction boundaries.

Connection factories only create connections.

---

## Dependency Injection

Status: ✅

Implemented:

* Application registrations
* Infrastructure registrations
* Repository registrations
* Connection Factory registration
* Configuration injection

API remains the Composition Root.

---

## Configuration

Status: ✅

Implemented:

* appsettings.Development.json
* ConnectionStrings
* Environment variable overrides

Understand:

Configuration changes should never require recompiling the application.

---

## Logging

Status: ✅

Implemented:

* ILogger<T>

Future improvements:

* Global Exception Middleware
* ProblemDetails
* Structured logging

---

# Remaining Learning Objectives

These concepts are **not blockers**.

Continue learning them naturally while implementing new banking features.

## 1. Resource Management

Current understanding:

* `using`
* `using var`
* `IDisposable`
* Basic connection disposal

Still improving:

* `await using`
* `IAsyncDisposable`

---

## 2. ADO.NET Internals

Current understanding:

* IDbConnection
* NpgsqlConnection
* Connection lifecycle

Recognize that Dapper internally builds upon:

* IDbCommand
* IDataReader

Detailed implementation knowledge can be learned when needed.

---

## 3. Transactions

Continue reinforcing:

* Isolation
* Rollback behavior
* Concurrency
* Transaction lifetime

through future banking features.

---

## 4. Error Handling

Future work:

* Global exception middleware
* Consistent API responses
* Validation responses
* ProblemDetails

---

# Immediate Next Features

Continue implementing the repository layer.

Recommended order:

```
✅ Register Customer

↓

✅ Get Customer By Id

↓

Get Customer Profile

↓

Create Checking Account

↓

Create Savings Account

↓

Deposit

↓

Withdraw

↓

Transfer

↓

Transaction History
```

Each feature should introduce new Dapper techniques naturally.

---

# Completion Checklist

Current progress:

* [x] Repository pattern implemented
* [x] PostgreSQL integrated
* [x] Dapper integrated
* [x] SQL separated from repository logic
* [x] Connection Factory implemented
* [x] Dependency Injection configured
* [x] Transactions implemented
* [x] Logging implemented
* [x] Parameterized SQL understood
* [x] Basic ADO.NET architecture understood
* [x] Basic connection lifecycle understood
* [x] Basic `using` / `IDisposable` understood
* [ ] Global exception handling
* [ ] Comfortable implementing all planned repository features

---

# Current Learning Philosophy

Continue building CSBank.

When a new concept appears:

```
Build Feature

↓

Encounter New Concept

↓

Study That Concept

↓

Continue Building
```

Do **not** pause the project solely to master every underlying abstraction.

---

# After Phase 4B

Begin **Phase 5 — Entity Framework Core**.

The goal is to understand EF Core as a higher-level abstraction built upon concepts already learned:

* PostgreSQL
* SQL
* Npgsql
* ADO.NET
* Dapper
* Transactions
* Connection Pooling
* Repository Pattern
* Dependency Injection
* Clean Architecture

Then begin learning:

* DbContext
* DbSet
* LINQ
* Change Tracking
* Migrations
* Fluent API
* Entity Configuration
