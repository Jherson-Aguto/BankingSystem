# TaskNow.md

# Current Status

**Project:** CSBank

**Architecture (Phase 1–3):** ✅ Complete

**Phase 4A — PostgreSQL Fundamentals:** ✅ Complete

**Phase 4B — Persistence Engineering (Dapper):** 🚧 ~98% Complete

**Current Focus:** Implement banking features to reinforce backend engineering and repository design.

**Next Milestone:** Complete the core banking persistence layer while refining the database model.

**Next Phase:** **Phase 5 — Database Engineering**

---

# Today's Objective

Continue building CSBank by implementing real banking use cases.

The objective is **not** to learn additional Dapper syntax.

The objective is to strengthen:

* Repository design
* Database modeling
* API use-case design
* Transaction boundaries
* Domain-oriented thinking

Infrastructure is now considered a stable foundation.

---

# Current Implementation Status

## Clean Architecture

Status: ✅

```text
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

Business logic remains independent of Infrastructure.

Infrastructure remains an implementation detail.

---

## PostgreSQL

Status: ✅

Completed:

* Database schemas
* UUID primary keys
* Foreign keys
* Constraints
* INSERT
* UPDATE
* JOIN
* CTEs
* Transactions
* Parameterized SQL

Comfortable designing and querying a normalized relational database.

---

## Persistence Engineering (Dapper)

Status: ✅ (Fundamentals Complete)

Comfortable using:

* ExecuteAsync()
* QueryFirstAsync<T>()
* QuerySingleAsync<T>()
* QuerySingleOrDefaultAsync<T>()
* Anonymous parameter objects
* SQL aliases
* Composite DTOs
* Multi Mapping
* splitOn
* Transactions
* RETURNING
* Writable CTEs

Understand the distinction between:

Writing:

```text
DTO
    ↓
Map.ToParameters()
    ↓
Execute / Query
```

Reading:

```text
SQL
    ↓
Dapper Mapping
    ↓
DTO
```

Reading joined data:

```text
SQL JOIN
    ↓
Multi Mapping
    ↓
Composite DTO
```

---

## Repository Layer

Status: ✅

Implemented:

* Register Customer
* Get Customer By Id

Repositories currently use:

* Connection Factory
* Dapper
* SQL constants
* Parameter mapping
* Transactions
* Logging
* Composite DTO projection

Repositories expose application use cases rather than database tables.

---

## Connection Factory

Status: ✅

Implemented:

* IDbConnectionFactory
* PostgreSqlConnectionFactory
* Dependency Injection
* Connection pooling
* Configuration separation

Understand:

* One connection per repository operation
* Resource lifetime
* Responsibility boundaries

---

## Transactions

Status: ✅

Understand:

* BeginTransaction()
* Commit()
* Rollback()
* Dispose()
* Transaction ownership
* Repository transaction boundaries

Future features will reinforce:

* Atomicity
* Consistency
* Isolation
* Rollback behavior

---

## Dependency Injection

Status: ✅

Implemented:

* Repository registrations
* Connection Factory registration
* Configuration injection

API remains the Composition Root.

---

## DTO Design

Status: ✅

Understand:

* DTOs model API responses
* Composite DTOs
* Reuse over duplication
* SQL aliases
* Constructor/property mapping
* Dapper materialization

---

## API Design

Status: ✅

Current philosophy:

Endpoints represent business use cases.

Examples:

```text
GET /users/{id}
```

↓

User summary

```text
GET /users/{id}/profile
```

↓

Customer profile with related information

Responses are designed around client needs—not table structures.

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

# Current Learning Objectives

These topics should be learned naturally while implementing banking features.

## 1. Database Engineering

Current focus:

* Banking schema refinement
* Relationship design
* Constraints
* Indexes
* Normalization
* Query optimization

---

## 2. Resource Management

Current understanding:

* using
* using var
* IDisposable

Continue learning:

* await using
* IAsyncDisposable

when appropriate.

---

## 3. ADO.NET

Understand:

* IDbConnection
* Connection lifecycle
* NpgsqlConnection

Recognize that Dapper builds upon:

* IDbCommand
* IDataReader

Deep ADO.NET internals are not currently a priority.

---

## 4. Error Handling

Future work:

* Global Exception Middleware
* ProblemDetails
* Validation responses
* Consistent API errors

---

# Immediate Next Features

Recommended order:

```text
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

Each feature should reinforce:

* Repository design
* Transactions
* Business rules
* Database modeling

rather than introducing new Dapper concepts.

---

# Completion Checklist

Current progress:

* [x] Clean Architecture established
* [x] PostgreSQL integrated
* [x] Dapper fundamentals mastered
* [x] Repository pattern implemented
* [x] Connection Factory implemented
* [x] Dependency Injection configured
* [x] Transactions implemented
* [x] Logging implemented
* [x] Parameterized SQL understood
* [x] DTO projection understood
* [x] Composite DTOs implemented
* [x] Multi Mapping understood
* [x] SQL alias strategy established
* [x] Basic ADO.NET architecture understood
* [x] Resource lifetime (`using`, `IDisposable`) understood
* [ ] Global exception handling
* [ ] Complete core banking repository features

---

# Current Learning Philosophy

Continue building CSBank.

Development should follow this cycle:

```text
Implement Feature
        ↓
Encounter New Concept
        ↓
Learn That Concept
        ↓
Apply It
        ↓
Continue Building
```

Do not pause progress solely to master every underlying abstraction.

The project itself remains the primary learning vehicle.

---

# Phase 5 Preview — Database Engineering

The next phase focuses on strengthening the persistence model before expanding business workflows.

Topics include:

* Banking schema refinement
* Account modeling
* Transaction modeling
* Constraints
* Index strategy
* Relationship refinement
* Query optimization
* Migration planning

This phase prepares the system for more sophisticated business operations.

---

# Phase 6 Preview — Business Operations

Once the database model is stable, implement the core banking capabilities:

* Customer Profile
* Create Checking Account
* Create Savings Account
* Deposit
* Withdraw
* Transfer
* Transaction History

The emphasis shifts from persistence mechanics to business rules, consistency, and domain modeling.
