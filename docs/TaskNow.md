# TaskNow.md

## Current Status

**Project:** CSBank

**Current Phase:** Phase 4A — PostgreSQL Fundamentals

**Goal:** Become comfortable manipulating relational data before implementing the Infrastructure layer with Dapper and later EF Core.

---

# Progress

## Database Fundamentals

- ✅ ERD completed
- ✅ Database created
- ✅ PostgreSQL CLI (`psql`)
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
- ✅ INSERT with `RETURNING`
- ✅ Common Table Expressions (`WITH`)
- ✅ Parent → Child insert using CTE + RETURNING

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

- Parent generated first
- Child receives generated PK as FK

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
- ✅ Foreign Key concept
- ✅ One-to-One relationships
- ✅ Parent → Child relationships

Example:

```
customer_details
----------------
id

        │
        ▼

private_information
-------------------
customer_id
```

Understand:

- Parent owns the identity
- Child references the parent

---

## JOINs

Completed:

- ✅ INNER JOIN
- ✅ LEFT JOIN

Understand:

- INNER JOIN returns matching rows only.
- LEFT JOIN returns every row from the left table, matching rows from the right when available.
- RIGHT JOIN and FULL JOIN understood conceptually.

---

# Current Focus (NEXT)

This is the remaining SQL knowledge required before returning to CSBank development.

---

## 1. UPDATE (Highest Priority)

Become comfortable updating:

- One column
- Multiple columns
- Parent table
- Child table

Examples:

```sql
UPDATE users.customer_details
SET
    first_name = 'John',
    last_name = 'Doe'
WHERE id = 1;
```

and

```sql
UPDATE users.private_information
SET
    email = 'john@example.com',
    city = 'Ilagan'
WHERE customer_id = 1;
```

Goal:

Be able to modify existing customer information confidently.

---

## 2. DELETE

Learn:

- Delete child rows
- Delete parent rows
- Observe FOREIGN KEY behavior

Practice:

- Why deleting the parent first may fail
- When CASCADE is appropriate
- Referential integrity

Goal:

Understand safe deletion in relational databases.

---

## 3. Multi-Table CRUD (Highest Priority)

Current weakness:

Managing one parent with multiple related tables.

Practice scenarios like:

```
Customer
    │
    ├── PrivateInformation
    ├── Account
    ├── SavingsAccount
    └── Loan
```

Exercises:

- Insert entire object graph
- Update multiple related tables
- Delete related data correctly

Goal:

Become comfortable manipulating complete relational data, not just single tables.

---

## 4. Constraints

Learn:

- PRIMARY KEY
- FOREIGN KEY
- UNIQUE
- CHECK

Practice:

Intentionally violate constraints and observe PostgreSQL errors.

Examples:

- Duplicate email
- Negative balance
- Invalid foreign key

Goal:

Understand how PostgreSQL protects data integrity.

---

## 5. Transactions

Learn:

- BEGIN
- COMMIT
- ROLLBACK

Exercise:

```
BEGIN;

Insert Customer;

Insert Private Information;

Insert Account;

Force an error;

ROLLBACK;
```

Verify:

Nothing should be committed.

Goal:

Understand atomic operations.

---

## 6. Indexes

Learn:

```sql
CREATE INDEX

CREATE UNIQUE INDEX
```

Goal:

Understand why indexes improve lookup performance.

No deep optimization knowledge is required yet.

---

# Lower Priority

Understand basic schema evolution.

Examples:

```sql
ALTER TABLE
ADD COLUMN

ALTER TABLE
DROP COLUMN

ALTER TABLE
RENAME COLUMN
```

Note:

During real projects, schema changes are usually handled by **EF Core Migrations**, not by manually writing `ALTER TABLE` statements. Understanding the concept is sufficient before moving on.

---

# After SQL

Once comfortable with:

- CRUD across related tables
- Constraints
- Transactions
- Indexes

Resume CSBank development.

---

# Phase 4B — Dapper Infrastructure

Implement:

- PostgreSQL connection
- Repository implementations
- Dependency Injection
- SQL queries inside Infrastructure
- Application → IRepository → Infrastructure flow

Goal:

Replace mock repositories with real PostgreSQL implementations.

---

# Phase 5 — EF Core

After completing Dapper, learn:

- DbContext
- DbSet
- Fluent API
- Migrations
- Tracking
- LINQ
- Repository implementation using EF Core

Objective:

Understand EF Core as an abstraction over SQL rather than a black box.

---

# Success Criteria Before Moving On

You should confidently be able to:

- Create tables
- Insert related data
- Query related data
- Join tables
- Update related data
- Delete related data safely
- Understand constraints
- Use transactions
- Create indexes

Once these are comfortable, continue building CSBank instead of spending additional time studying standalone SQL.

The remaining learning will naturally occur while implementing real banking features.