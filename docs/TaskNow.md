# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4A — PostgreSQL Fundamentals

## Goal

Become comfortable manipulating relational data and understanding relational database behavior before implementing the Infrastructure layer with Dapper and later EF Core.

The objective is **not** to become a PostgreSQL expert, but to understand the concepts that ORMs abstract away.

---

# Progress

## Database Fundamentals

Completed:

- ✅ ERD completed
- ✅ Database created
- ✅ PostgreSQL CLI (psql)
- ✅ Connecting databases (`\c`)
- ✅ Schemas
- ✅ CREATE TABLE
- ✅ PostgreSQL data types
- ✅ NOT NULL

---

## Data Insertion

Completed:

- ✅ Single-row INSERT
- ✅ Multi-row INSERT (single table)
- ✅ INSERT with RETURNING
- ✅ Common Table Expressions (WITH)
- ✅ Parent → Child INSERT using CTE + RETURNING

Example:

```sql
WITH id AS (
    INSERT INTO users.customer_details(...)
    VALUES(...)
    RETURNING id
)
INSERT INTO users.private_information(...)
SELECT ...
FROM id;
```

Understand:

- Parent row is created first.
- Child row receives the generated primary key as its foreign key.
- One-to-one insertion workflow.

**Note**

Bulk parent → multiple child insertion using a single SQL statement is intentionally postponed.

This is considered an advanced PostgreSQL technique rather than a required backend foundation.

---

## Querying Data

Completed:

- ✅ SELECT
- ✅ WHERE
- ✅ ORDER BY

---

## Relationships

Completed:

- ✅ Primary Key
- ✅ Foreign Key
- ✅ One-to-One relationships
- ✅ One-to-Many relationships (conceptually)
- ✅ Parent → Child relationships

Understand:

```
Parent owns the identity.

Child references the parent.
```

---

## JOINs

Completed:

- ✅ INNER JOIN
- ✅ LEFT JOIN
- ✅ RIGHT JOIN
- ✅ FULL JOIN (conceptually)

Understand:

- INNER JOIN returns matching rows only.
- LEFT JOIN preserves every row from the left table.
- RIGHT JOIN preserves every row from the right table.
- FULL JOIN preserves rows from both tables.

Most importantly:

JOINs reconstruct relational data.

This understanding directly connects to how EF Core materializes object graphs.

---

## UPDATE

Completed:

Understand:

- ✅ Update one column
- ✅ Update multiple columns
- ✅ Update parent table
- ✅ Update child table

Concepts learned:

- WHERE determines which rows are updated.
- Omitting WHERE updates every row.
- UPDATE is a set-based operation.
- One UPDATE statement modifies only one table.
- Primary keys should be preferred when updating a single record.

---

## DELETE

Completed:

Understand:

- ✅ Delete child rows
- ✅ Delete parent rows
- ✅ Referential integrity
- ✅ Foreign key behavior

Understand:

Deleting the child is allowed.

Deleting the parent depends on the configured foreign key action.

---

## Referential Actions

Completed:

Understand:

- ✅ ON DELETE CASCADE
- ✅ ON DELETE NO ACTION
- ✅ ON DELETE SET NULL

- ✅ ON UPDATE CASCADE
- ✅ ON UPDATE NO ACTION
- ✅ ON UPDATE SET NULL

Most important takeaway:

These are business rules enforced by PostgreSQL.

The database is responsible for maintaining referential integrity.

---

## ORM Understanding

Major conceptual milestone completed:

Understand that frameworks such as EF Core abstract SQL rather than replace it.

Examples:

```
SaveChanges()

↓

BEGIN TRANSACTION

↓

UPDATE customer_details

↓

UPDATE private_information

↓

COMMIT
```

Likewise:

```
.Include(...)

↓

JOINs or multiple SQL queries

↓

Materialize object graph
```

Understanding this is one of the primary goals of learning SQL before EF Core.

---

# Current Focus (NEXT)

Only a few SQL topics remain before beginning Dapper.

---

# 1. Transactions (Highest Priority)

Learn:

- BEGIN
- COMMIT
- ROLLBACK

Exercise:

```sql
BEGIN;

INSERT Customer;

INSERT Private Information;

INSERT Account;

Force an error;

ROLLBACK;
```

Verify:

Nothing should be committed.

Goal:

Understand atomic operations.

Understand why banking systems require transactions.

---

# 2. Constraints

Learn:

- UNIQUE
- CHECK

(Foreign Keys and Primary Keys already understood.)

Practice intentionally violating constraints.

Examples:

- Duplicate email
- Negative balance
- Invalid foreign key

Goal:

Understand how PostgreSQL protects data integrity.

---

# 3. Indexes

Learn:

```sql
CREATE INDEX;

CREATE UNIQUE INDEX;
```

Goal:

Understand why indexes improve lookup performance.

Deep optimization is intentionally postponed.

---

# 4. Multi-Table CRUD (Capstone)

This is no longer considered a separate SQL topic.

Instead, it serves as the final integration exercise before Phase 4B.

Example schema:

```
Customer
    │
    ├── PrivateInformation
    ├── Account
    ├── SavingsAccount
    └── Loan
```

Exercise:

- Register customer
- Insert related records
- Query with JOINs
- Update related tables
- Delete related tables
- Use transactions
- Observe constraints

Goal:

Become comfortable manipulating complete relational data.

---

# Lower Priority

## ALTER TABLE

Understand only the basics.

Examples:

```sql
ALTER TABLE
ADD COLUMN;

ALTER TABLE
DROP COLUMN;

ALTER TABLE
RENAME COLUMN;
```

Note:

Real projects typically use EF Core Migrations.

Understanding the concept is sufficient before moving on.

---

# After SQL

After becoming comfortable with:

- Transactions
- Constraints
- Indexes
- Multi-table CRUD

Resume CSBank development.

---

# Phase 4B — Dapper Infrastructure

Implement:

- PostgreSQL connection
- Repository implementations
- Dependency Injection
- SQL inside Infrastructure
- Application → IRepository → Infrastructure flow

Goal:

Replace mock repositories with real PostgreSQL implementations.

Understand that Dapper executes SQL you already understand rather than hiding it.

---

# Phase 5 — EF Core

After Dapper:

Learn:

- DbContext
- DbSet
- Fluent API
- Migrations
- Change Tracking
- LINQ
- Repository implementations

Objective:

Understand EF Core as a productivity layer built on top of SQL, rather than treating it as a black box.

---

# Success Criteria Before Moving On

You should confidently be able to:

- ✅ Create relational tables
- ✅ Insert related data
- ✅ Query related data
- ✅ Join tables
- ✅ Update related data
- ✅ Delete related data safely
- ✅ Understand referential integrity
- ✅ Understand foreign key actions
- ⏳ Use transactions
- ⏳ Understand constraints
- ⏳ Create indexes

Once these are comfortable, stop studying standalone SQL and continue learning naturally while building CSBank with Dapper.