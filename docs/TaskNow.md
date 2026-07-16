# TaskNow.md

# Current Status

**Project:** CSBank

**Architecture:** ✅ Complete (Phase 1–3)

**Current Phase:** Phase 4A — Multi-Table CRUD Capstone

**Next Phase:** Phase 4B — Persistence with Dapper

---

# Today's Objective

Complete the SQL integration capstone using the CSBank schema.

The objective is to prove that the SQL concepts already learned can be applied to complete business operations.

Do **not** learn new SQL topics.

Do **not** begin Dapper.

Do **not** begin EF Core.

---

# Current Business Workflow

Implement the following workflow entirely in SQL.

```text
Register Customer

↓

Create Customer

↓

Create Private Information

↓

Create Bank Account

↓

Create Savings Account

↓

COMMIT
```

Treat this as one business operation.

---

# Tasks

## 1. Registration

Status: [DONE]

Implement a complete customer registration workflow.

Requirements:

* Insert Customer
* Insert PrivateInformation
* Insert Account
* Insert SavingsAccount
* Execute all inserts inside a single transaction

---

## 2. Read

Status: [DONE]

Retrieve a complete customer profile.

Requirements:

* JOIN all related tables
* Return one logical customer
* Verify relational data is reconstructed correctly

---

## 3. Update

Status: ☐

Modify customer information.

Requirements:

* Update customer details
* Update private information
* Verify constraints still protect the data

---

## 4. Delete

Status: ☐

Safely remove customer data.

Requirements:

* Delete related records correctly
* Observe foreign key behavior
* Verify referential integrity

---

# Completion Checklist

Phase 4A is complete when you can confidently answer **yes** to all of the following:

* ☐ I can implement a complete business operation using SQL.
* ☐ I know when a transaction is required.
* ☐ I understand how relationships reconstruct a customer.
* ☐ I understand why constraints protect the database.
* ☐ I no longer think in isolated SQL statements.

---

# Stop Conditions

If you get stuck, stop and ask:

> "What concept am I missing?"

Do **not** immediately search for Dapper or EF Core.

The missing concept should be identified before moving to the next phase.

---

# After Phase 4A

When every checklist item is complete:

Begin **Phase 4B — Persistence with Dapper**.

The goal of Phase 4B is **not** to learn another framework.

The goal is to replace:

```text
Repository Interface

↓

Mock Repository
```

with:

```text
Repository Interface

↓

Dapper Repository

↓

PostgreSQL
```

without changing the API, Application, or Domain layers.

Only the persistence implementation should change.
