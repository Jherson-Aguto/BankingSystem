# Current Status

**Project:** CSBank

**Current Phase:** Phase 6 — Entity Framework Core 🚧

**Architecture Status:** ✅ Stable

**Current Focus:** Understanding EF Core as a Persistence Abstraction

**Previous Phase:** Phase 5 — Relational Database Design ✅

**Next Phase:** Phase 7 — Performance Engineering

---

# Current Task

Phase 5 is considered complete.

The database has evolved through real engineering decisions driven by business requirements rather than theoretical exercises.

The objective now is to understand Entity Framework Core as an abstraction built upon concepts that have already been implemented manually.

Current objectives:

- Learn what EF Core abstracts.
- Compare EF Core with Dapper.
- Understand DbContext.
- Understand DbSet.
- Configure entity mappings using Fluent API.
- Learn relationship mapping.
- Understand Change Tracking.
- Learn EF Core migrations.
- Compare generated SQL with handwritten SQL.
- Identify when EF Core is appropriate and when handwritten SQL remains preferable.

The goal is not to replace SQL knowledge, but to understand how EF Core builds upon it.

---

# Current Engineering Focus

## Entity Framework Core

Current work should focus on understanding the abstraction rather than memorizing APIs.

When learning a new EF Core feature, continue asking:

### Database

- What SQL is EF Core generating?
- What database objects are being affected?
- Would I be able to write this SQL manually?

### Architecture

- Does this abstraction simplify the code?
- Does it hide important behavior?
- Does it belong in Infrastructure?

### Performance

- Is EF Core generating efficient SQL?
- Would Dapper or handwritten SQL be more appropriate?
- Is change tracking necessary for this scenario?

---

# Current Architecture

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

↓

Entity Framework Core

↓

PostgreSQL
```

Repositories continue to orchestrate persistence.

EF Core becomes the persistence implementation instead of Dapper for scenarios where it provides value.

---

# Current Persistence Philosophy

Understand the abstraction before depending on it.

EF Core should be viewed as:

```text
Domain Objects

↓

Change Tracker

↓

Entity Configuration

↓

Generated SQL

↓

PostgreSQL
```

The database remains the source of truth.

EF Core is responsible for generating SQL—not replacing relational concepts.

---

# Current Learning Focus

Current concepts:

- DbContext
- DbSet
- Fluent API
- Entity Configuration
- Relationship Mapping
- Change Tracking
- Loading Strategies
- Migrations
- Value Conversions
- Generated SQL
- EF Core vs Dapper
- Persistence trade-offs

Every feature should be understood in terms of the SQL and database behavior it abstracts.

---

# Current Philosophy

Continue applying the project's core principle:

> Understand the abstraction before using the abstraction.

Whenever EF Core introduces a feature, identify:

- What manual code it replaces.
- What SQL it generates.
- What database concepts it depends on.
- What trade-offs it introduces.
- When it should or should not be used.

The objective is to become capable of choosing between EF Core, Dapper, and handwritten SQL based on engineering requirements rather than familiarity.

---

# Next Phase

After understanding Entity Framework Core:

**Phase 7 — Performance Engineering**

Topics include:

- Query optimization
- Query plans
- EXPLAIN ANALYZE
- Index strategy
- Collection performance
- Memory optimization
- Performance profiling

The objective is to understand how engineering decisions affect scalability and how to diagnose performance bottlenecks across the application and database.