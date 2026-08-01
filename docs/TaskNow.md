# Current Status

**Project:** CSBank

**Current Phase:** Phase 6 — Entity Framework Core ✅

**Architecture Status:** ✅ Stable

**Current Focus:** Preparing for Phase 7 — Performance Engineering

**Previous Phase:** Phase 5 — Relational Database Design ✅

**Next Phase:** Phase 7 — Performance Engineering

---

# Current Task

Phase 6 is considered complete.

The objective of this phase was to understand Entity Framework Core as a persistence abstraction rather than treating it as a replacement for SQL.

The project intentionally follows a hybrid persistence architecture:

- Writes → Entity Framework Core
- Reads → Dapper

Repositories remain responsible for persistence while the Domain remains persistence-agnostic.

EF Core is used where its Unit of Work and Change Tracking provide value.

Dapper continues to be used for handcrafted read queries requiring precise SQL control and performance.

---

# Phase 6 Learning Outcomes

The following concepts have been completed:

- DbContext
- DbSet
- Dependency Injection
- Fluent API
- Entity Configurations
- Relationship Mapping
- Navigation Properties
- PostgreSQL Enum Mapping
- Change Tracker
- Entity States
- SaveChanges Pipeline
- Tracking vs AsNoTracking
- Generated SQL
- Repository Integration
- Update Aggregate using EF Core
- EF Core vs Dapper trade-offs

Additional concepts were reviewed conceptually:

- Loading Strategies
- Migrations
- Value Converters
- Owned Types

These concepts were intentionally not adopted because they do not currently provide value to the chosen architecture.

---

# Persistence Architecture

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

       ├── EF Core (Writes)

       └── Dapper (Reads)

↓

PostgreSQL
```

The database remains the source of truth.

Repositories decide which persistence technology is appropriate.

---

# Engineering Philosophy

Continue following the project's primary principle:

> Understand the abstraction before depending on the abstraction.

Every abstraction should answer:

- What manual implementation does it replace?
- What SQL is ultimately executed?
- What database concepts does it depend on?
- What engineering trade-offs does it introduce?
- When is it the correct tool?
- When should handwritten SQL remain the preferred solution?

---

# Next Phase

## Phase 7 — Performance Engineering

Focus on understanding how software engineering decisions affect scalability, latency, memory usage, and database performance.

Topics:

### PostgreSQL

- EXPLAIN
- EXPLAIN ANALYZE
- Execution Plans
- Sequential Scan vs Index Scan
- Composite Indexes
- Covering Indexes
- Query Optimization
- EXISTS vs JOIN
- LIMIT / OFFSET Pagination
- Keyset Pagination
- Window Functions
- Locking Performance

### Dapper

- Buffered vs Unbuffered Queries
- QueryMultiple
- Multi-Mapping
- Streaming Results
- Allocation Reduction
- Efficient DTO Projections

### Entity Framework Core

- Generated SQL Inspection
- Detecting N+1 Queries
- Split Queries
- Compiled Queries
- Change Tracker Cost
- AsNoTracking Performance
- Bulk Operations Trade-offs

### .NET Performance

- Collections
- LINQ Performance
- Span<T>
- Memory Allocation
- async/await Costs
- ValueTask
- BenchmarkDotNet

### Profiling

- Logging SQL
- Measuring Query Time
- Benchmarking
- Memory Profiling
- CPU Profiling

---

# Current Goal

Become capable of evaluating both handwritten SQL and ORM-generated SQL from an engineering perspective.

Every optimization should be measurable.

Performance decisions should be driven by evidence rather than assumptions.

The objective is to build a backend capable of scaling while maintaining clean architecture and a clear separation of responsibilities.