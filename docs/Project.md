# Project Blueprint: CSBank System Evolution

This blueprint details how to build and evolve **CSBank**, starting with the **Customer Registration** use-case and scaling into a fully-featured enterprise banking backend.

---

## 🏗️ Architecture Design (Clean Architecture)

```
CSBank (Solution)
├── csbank.Domain         # Core entities, domain models, and domain business rules
├── csbank.Application    # Use cases, mappers, service orchestrators, and system interfaces (e.g., IPasswordHasher)
├── csbank.Infrastructure # Database (EF Core), persistence, BCryptPasswordHasher implementation, caching
└── csbank.Api            # REST endpoints, controllers, dependency injection setup
```

---

## 🚀 Evolution Blueprints

---

### 📦 Phase 1 - 3: Scaffold & Models
*   **Logic:** A request hits `RegisterCustomerController`, maps input to domain records (`CustomerRequest`, `PrivateInfoRequest`), validates age in the domain service, and returns a simulated response.
*   **Active Directory:** Check [csbank.Api/Controllers](file:///home/jherson/Documents/Learn/c%23/csbank/src/csbank.Api/Controllers/RegisterCustomer.cs) and [csbank.Application/Services](file:///home/jherson/Documents/Learn/c%23/csbank/src/csbank.Application/Services/RegisterCustomer.cs).

---

### 💾 Phase 4: Persistence (SQL, PostgreSQL & EF Core)
Instead of maintaining static arrays or fake memory classes, you write records directly to a PostgreSQL database.

*   **EF Core AppDbContext Configuration (`csbank.Infrastructure`):** Configure table schemas for `Customers` and `PrivateInfos` in your repository layer.
*   **Repository Pattern (`csbank.Infrastructure`):** Implement the `ICustomerRepository` interface to handle database insertions using EF Core's `DbContext`.

---

### 🗄️ Phase 4.5: Relational Database Design
Before tuning EF Core, design a standardized relational database schema.
*   **Database Schema Constraints:** Apply Primary Keys (PK), Foreign Keys (FK), and Unique Constraints directly in your relational design.
*   **Normalization (1NF, 2NF, 3NF):** Ensure customer details and private information are normalized. You will implement a One-to-One (1:1) mapping between the `Customers` table and the `PrivateInfos` table.

---

### 🚀 Phase 5 - 7: DB Performance, Big O & Memory Processing
Use your database to learn performance bottlenecks and in-memory data manipulations.

#### 1. Indexing & Big O Analysis (SQL vs. EF Core)
*   **Without Index ($O(n)$):** Searching for a customer by a non-indexed column requires a sequential table scan.
*   **With Index ($O(\log n)$):** Create a B-Tree index on `Email` in SQL:
    ```sql
    CREATE UNIQUE INDEX IX_PrivateInfos_Email ON "PrivateInfos" ("Email");
    ```
*   **Practical Task:** Seed 100,000 registrations. Compare query response times of an indexed email lookup against a non-indexed search.

#### 2. In-Memory Search & Custom Sorting
Once data is retrieved, process it in the application layer:
*   **Sorting:** Fetch registered users from the database into memory, and write a custom **QuickSort** in `csbank.Application` to sort them alphabetically by `LastName` before returning them.
*   **Searching:** Fetch a sorted list of registrations and write a **Binary Search** to find a customer record matching a specific target age/birthdate.

---

### 🌿 Phase 8 - 11: Tree Hierarchies & Algorithmic Patterns

#### 1. Branch Hierarchy (Trees)
*   Create a `Branch` table where each branch record points to a parent branch (`ParentId`).
*   Retrieve branches and write a recursive tree-traversal algorithm in C# to find all nested branches and their total registered customer counts.

#### 2. Rate Limiting (Sliding Window)
*   Write a middleware/filter in `csbank.Api` to track client request intervals.
*   Prevent automated registration bots by tracking request timestamps using a sliding window algorithm in memory.

---

### ⚡ Phase 12 - 15: Optimization, Networking & Concurrency

#### 1. Query Optimization & Projections (Avoiding N+1)
To prevent N+1 query execution and avoid fetching redundant database columns (such as password hashes) over the network, use direct projections:

```csharp
public async Task<List<CustomerDto>> GetCustomerProfilesAsync()
{
    return await context.Customers
        .Include(c => c.PrivateInfo)
        .Select(c => new CustomerDto
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.PrivateInfo.Email // Safely excludes passwords and sensitive fields!
        })
        .ToListAsync();
}
```

#### 2. Computer Networking (REST Principles)
Expose the registration action as a RESTful web API. Integrate:
*   **HTTP Verbs & Status Codes:** Correctly return `201 Created` for registrations, `400 BadRequest` for validations, and `429 TooManyRequests` for rate limits.
*   **Idempotency & CORS:** Design your endpoints to be safe against duplicate form submissions, and configure secure Cross-Origin Resource Sharing (CORS) rules for frontend client requests.

#### 3. Concurrency Exception Handling
Handle simultaneous duplicate registrations using unique indexes:

```csharp
try
{
    await repository.AddAsync(customer, privateInfo);
}
catch (DbUpdateException ex) when (ex.InnerException is NpgsqlException { SqlState: "23505" })
{
    throw new InvalidOperationException("This email is already registered.");
}
```

---

## 🛡️ Phase 16 - 20: Testing, Caching & Security

#### 1. Password Hashing Abstraction
Keep your Application layer decoupled from third-party hashing libraries by abstracting the tool:

*   **Application Layer Interface (`csbank.Application`):**
    ```csharp
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
    ```
*   **Infrastructure Layer Implementation (`csbank.Infrastructure`):**
    ```csharp
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool VerifyPassword(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
    ```

#### 2. Unit Testing
*   Use **xUnit** to assert your validation rules.
*   Mock `ICustomerRepository` and `IPasswordHasher` using **NSubstitute** to verify that validations run, passwords hash, and insertions complete properly.
