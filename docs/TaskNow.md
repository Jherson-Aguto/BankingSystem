# TaskNow.md

# Current Status

**Project:** CSBank

**Current Phase:** Phase 4B — Persistence Layer Engineering 🚧 (~98%)

**Current Feature:** Customer Profile → Create Account

**Current Focus:** Complete the remaining Infrastructure startup concepts while continuing to implement banking features.

**Next Phase:** Phase 5 — Relational Database Design

---

# Immediate Objective

Continue implementing the account creation workflow while strengthening my understanding of the Infrastructure layer.

Current implementation:

```text
Customer Profile
        ↓
Create Account
        ↓
Create Checking Account
        ↓
Create Savings Account
```

The objective is not only to finish the persistence layer, but also to understand how the application is composed during startup.

---

# Current Learning Priority

## Infrastructure Startup

Current focus:

```text
Program.cs
        ↓
Composition Root
        ↓
Configuration
        ↓
Dependency Injection
        ↓
NpgsqlDataSource
        ↓
Connection Factory
        ↓
Repositories
        ↓
PostgreSQL
```

Current understanding:

- The API acts as the Composition Root.
- Infrastructure owns communication with PostgreSQL.
- Configuration belongs at application startup.
- Repositories should only execute persistence operations.
- Startup code should compose the application, not contain business logic.

### Learn

#### Composition Root

Understand:

- Why the Composition Root exists
- How the application is assembled
- Why Program.cs owns application composition
- What belongs in Program.cs versus Infrastructure

#### Dependency Injection

Understand:

- Dependency registration
- Service lifetimes
    - Singleton
    - Scoped
    - Transient
- Why abstractions are registered instead of concrete implementations
- How dependencies flow through the application

#### Connection Factory

Understand:

- Why repositories request connections instead of creating them
- Why connection creation is centralized
- How connection factories improve separation of concerns

#### Npgsql

Understand:

- NpgsqlDataSource
- NpgsqlDataSourceBuilder
- PostgreSQL ENUM mapping
- CLR enum mapping
- Connection pooling
- One-time Infrastructure configuration
- Why these responsibilities belong outside repositories

Goal:

Understand the responsibility of each Infrastructure component and how they collaborate during application startup rather than memorizing framework APIs.

---

# Remaining Features

```text
Customer Profile
        ↓
Create Account
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

- Repository design
- Business use cases
- Transaction boundaries
- Database modeling
- API design
- Domain responsibilities
- Infrastructure responsibilities

rather than simply introducing new framework APIs.

---

# Current Learning Philosophy

Continue building CSBank as the primary learning vehicle.

Development should follow this cycle:

```text
Business Requirement
        ↓
Identify the Problem
        ↓
Understand the Engineering Concept
        ↓
Determine Responsibility
        ↓
Place It in the Correct Layer
        ↓
Learn the Required Framework API
        ↓
Implement
        ↓
Continue Building
```

The objective is to permanently learn engineering concepts while treating framework APIs as reference material.

---

# Phase 4B Exit Criteria

Phase 4B is complete when the Infrastructure layer provides a complete and well-understood persistence foundation.

Remaining concepts:

- Composition Root
- Dependency Injection registration
- Service lifetimes
- Configuration
- Connection Factory
- NpgsqlDataSource
- PostgreSQL ENUM ↔ CLR enum mapping
- Remaining banking repository implementations

Infrastructure should become a stable platform that supports future business features without requiring architectural changes.

---

# Phase 5 Preview — Relational Database Design

After the persistence layer is complete, shift focus to improving the database model itself.

Topics:

- Banking schema refinement
- Relationship refinement
- Constraint design
- Index strategy
- Normalization (1NF–3NF)
- Schema evolution
- Query optimization
- ERD refinement

The emphasis shifts from persistence implementation to database engineering.

---

# Phase 6 Preview — Business Operations

Once the persistence layer and database model are stable, implement the core banking capabilities.

Features:

- Customer Profile
- Create Accounts
- Deposit
- Withdraw
- Transfer
- Transaction History

The emphasis shifts from persistence mechanics to business capability modeling, transaction consistency, domain rules, and software engineering decisions.