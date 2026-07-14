# TaskNow.md

# Current Status

**Project:** CSBank

**Architecture Status:** Phase 1–3 Complete ✅

**Current Learning Phase:** Phase 4A — PostgreSQL Fundamentals

**Current Project Phase:** Transitioning to Phase 4B

---

# Mission

Complete one final SQL integration exercise (Multi-Table CRUD Capstone), then immediately resume CSBank development by replacing mock repositories with real PostgreSQL implementations using Dapper.

The objective is no longer to learn isolated SQL syntax.

The objective is to apply relational database concepts to real backend development.

---

# Architecture Status

Completed:

- ✅ Clean Architecture
- ✅ Domain Layer
- ✅ Application Layer
- ✅ API Layer
- ✅ Dependency Injection
- ✅ Manual Mapping
- ✅ Repository Abstractions
- ✅ Customer Registration Use Case
- ✅ Mock Repository Implementation

Current architecture:

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

(Mock Repository)
```

Current limitation:

Persistence has intentionally been postponed until SQL fundamentals were completed.

---

# PostgreSQL Fundamentals

## Completed

### Database Fundamentals

- ✅ CREATE DATABASE
- ✅ PostgreSQL CLI
- ✅ Schemas
- ✅ CREATE TABLE
- ✅ Data Types
- ✅ NOT NULL

---

### CRUD

Completed:

- ✅ INSERT
- ✅ Multi-row INSERT
- ✅ RETURNING
- ✅ WITH (CTE)
- ✅ SELECT
- ✅ WHERE
- ✅ ORDER BY
- ✅ UPDATE
- ✅ DELETE

---

### Relationships

Completed:

- ✅ Primary Keys
- ✅ Foreign Keys
- ✅ One-to-One
- ✅ One-to-Many
- ✅ Parent → Child relationships

---

### JOINs

Completed:

- ✅ INNER JOIN
- ✅ LEFT JOIN
- ✅ RIGHT JOIN
- ✅ FULL JOIN (Conceptual)

Understand:

JOINs reconstruct relational data.

---

### Referential Integrity

Completed:

- ✅ Foreign Keys
- ✅ ON DELETE
- ✅ ON UPDATE
- ✅ CASCADE
- ✅ NO ACTION
- ✅ SET NULL

---

### Transactions

Completed:

Understand:

- ✅ Autocommit
- ✅ BEGIN
- ✅ COMMIT
- ✅ ROLLBACK
- ✅ Failed transaction state
- ✅ Statement-level atomicity
- ✅ Transaction-level atomicity

Major realization:

A business operation often spans multiple SQL statements.

Transactions make those statements behave as one atomic unit.

---

### Constraints

Completed:

- ✅ UNIQUE
- ✅ CHECK

Understand:

The database is the final guardian of data integrity.

Application validation and database constraints complement one another.

---

### Indexes

Completed:

Understand:

- ✅ CREATE INDEX
- ✅ CREATE UNIQUE INDEX

Major concepts:

- Faster lookups
- Slower writes
- Additional storage
- PRIMARY KEY automatically creates an index
- UNIQUE automatically creates an index

---

### ORM Mental Model

Major milestone completed.

Understand:

EF Core abstracts SQL.

Examples:

```
SaveChanges()

↓

BEGIN TRANSACTION

↓

INSERT / UPDATE / DELETE

↓

COMMIT
```

```
.Include(...)

↓

JOIN

or

Multiple SELECT statements

↓

Materialize object graph
```

Objects do not exist inside PostgreSQL.

Only relational data exists.

ORMs reconstruct object graphs.

---

# Current Task

## Multi-Table CRUD Capstone

Status:

⏳ Ready to Begin

Purpose:

This is **not** another SQL lesson.

This is the bridge between SQL fundamentals and CSBank development.

Use the actual CSBank schema:

```
Customer
│
├── PrivateInformation
├── Account
├── SavingsAccount
└── Loan
```

Complete business workflows using everything learned:

- Register Customer
- Insert related records
- Query customer information
- JOIN related tables
- Update related records
- Delete related records safely
- Apply transactions
- Observe constraints
- Observe referential integrity
- Apply indexes where appropriate

Goal:

Stop thinking in isolated SQL statements.

Start thinking in business operations.

---

# Immediate Next Phase

## Phase 4B — Dapper Infrastructure

After the capstone:

Replace:

```
IRepository

↓

Mock Repository
```

with:

```
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
- Dependency Injection
- SQL execution
- Customer Registration persistence

No business rules belong inside Infrastructure.

Infrastructure is responsible only for persistence.

---

# Upcoming Roadmap

Phase 4B
- Dapper Infrastructure

↓

Phase 5
- EF Core

↓

Phase 6
- Relational Database Design

↓

Phase 7
- Performance

↓

Phase 8
- Algorithms

↓

Phase 9+
- Networking
- Concurrency
- Security
- Caching
- Testing
- Deployment

---

# Current Assessment

Architecture Foundation:

✅ Complete

Relational Database Fundamentals:

✅ Complete

Remaining SQL Work:

⏳ Multi-Table CRUD Capstone

Current Milestone:

You are transitioning from learning SQL concepts to implementing real persistence inside CSBank.

The next repository you write will no longer be a mock—it will execute real SQL against PostgreSQL using Dapper.