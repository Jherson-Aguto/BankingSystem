# TaskNow.md

# CSBank — Current Task

**Project:** CSBank
**Current Phase:** Phase 8 — Security Engineering 🚧
**Current Focus:** Complete the remaining security engineering work before moving to client implementation or later phases.

---

# Objective

Finish the **remaining security work that is actually required at the current stage**.

The core authentication system and basic endpoint protection are already understood and implemented. Do not add unnecessary complexity such as role-based authorization (`Customer`, `Admin`) until the system has a concrete requirement for multiple roles.

The immediate goal is to harden the API and verify that security controls work correctly.

---

# Already Completed

The following are **not current tasks**.

## Authentication

* JWT access tokens
* Password hashing
* Login
* Refresh tokens
* Refresh-token hashing
* Refresh-token rotation
* Refresh-token expiration
* Refresh-token revocation
* Logout
* Authentication middleware

## Basic Authorization

* `[Authorize]`
* Claims
* Authentication identity
* Protected endpoints
* Basic authorization middleware

## Persistence / Security Infrastructure

* Parameterized SQL
* SQL injection prevention through parameterized queries
* Secure exception handling
* `CancellationToken` propagation
* Dapper `CommandDefinition` cancellation
* Database command timeouts
* Audit logging
* Transactional audit logging

---

# Current Security Tasks

## Task 1 — Resource Ownership Authorization

### Goal

Ensure an authenticated customer can only access and operate on resources that belong to them.

Example:

```text
Customer A
    ↓
Can access Customer A's resources

Customer A
    X
Cannot access Customer B's resources
```

Verify this for:

* Customer profile
* Accounts
* Account operations
* Transaction history
* Other customer-owned resources

### Important

Do **not** solve this by hardcoding a specific email address.

The authorization decision should be based on the authenticated identity/claims and the ownership relationship in the database.

---

# Task 2 — Authorization Policies

### Goal

Understand ASP.NET Core authorization policies beyond simply using `[Authorize]`.

Learn:

* Policy-based authorization
* Authorization requirements
* Authorization handlers
* Claims-based requirements
* When a policy is preferable to controller-level checks

### Scope

Implement only policies that have a real requirement in CSBank.

Do **not** introduce:

```csharp
Roles = "Customer"
Roles = "Admin"
```

unless the application actually requires multiple roles.

---

# Task 3 — HTTPS Verification

### Goal

Verify that the API is configured to require secure communication in a production-oriented environment.

Understand:

* HTTP vs HTTPS
* TLS
* HTTPS redirection
* Development certificates
* Reverse-proxy / production considerations
* Why JWT-bearing requests should not be sent over plaintext HTTP

### Verification

Confirm that HTTP requests are redirected or rejected according to the application's intended deployment configuration.

---

# Task 4 — CORS

### Goal

Understand and configure Cross-Origin Resource Sharing for a future client application.

Learn:

* Same-origin policy
* Origin
* CORS
* Preflight requests
* `OPTIONS`
* Allowed origins
* Allowed methods
* Allowed headers
* Credentials and cookies
* Why `AllowAnyOrigin()` is not an appropriate production default

### Implementation

Create an explicit CORS policy for the expected client origin rather than opening the API to every origin.

The client does not need to be implemented yet.

The API should simply be prepared to communicate securely with one.

---

# Task 5 — Rate Limiting

### Goal

Protect publicly accessible endpoints from excessive requests and basic abuse.

Learn:

* Rate limiting
* Fixed window
* Sliding window
* Token bucket / concurrency concepts
* Per-IP vs per-user limits
* Endpoint-specific limits
* HTTP `429 Too Many Requests`

### Initial Scope

Prioritize sensitive endpoints such as:

* Login
* Refresh token
* Other publicly accessible authentication endpoints

Do not prematurely optimize every endpoint.

The purpose is to understand the security mechanism and apply it where abuse is most relevant.

---

# Task 6 — Request Validation

### Goal

Ensure API input is validated before it reaches business operations.

Verify:

* Required fields
* String length limits
* Valid formats
* Numeric ranges
* Enum validity
* Invalid request behavior
* Appropriate HTTP status codes

Distinguish:

```text
Request validation
        ↓
Protect API input boundaries
```

from:

```text
Domain validation
        ↓
Protect business rules
```

Both may exist, but they serve different responsibilities.

---

# Task 7 — Input Sanitization Review

### Goal

Determine where sanitization is actually necessary rather than blindly transforming user input.

Review:

* SQL injection
* HTML/script injection
* Logging injection
* Dangerous input rendering
* Output encoding
* Parameterized SQL

Important principle:

> Validation, parameterization, encoding, and sanitization solve different problems.

Do not introduce a generic "sanitize everything" mechanism without understanding the attack being prevented.

---

# Task 8 — Security Headers

### Goal

Add appropriate HTTP response security headers.

Study and evaluate:

* `X-Content-Type-Options`
* `Content-Security-Policy`
* `Referrer-Policy`
* `Permissions-Policy`
* `Strict-Transport-Security` (HSTS)

Understand which headers belong in an API and which are primarily browser-application concerns.

Avoid blindly copying a browser security-header configuration into a backend API.

---

# Task 9 — Secrets Management

### Goal

Ensure secrets are not stored as source-controlled application configuration.

Review:

* JWT signing keys
* Database credentials
* Connection strings containing credentials
* Environment variables
* Development secrets
* Production secret stores

Principle:

```text
Source Code
    X
Secrets

Configuration
    ↓
Secret Provider
    ↓
Application
```

Do not commit production secrets to the repository.

---

# Task 10 — Database Least Privilege

### Goal

Understand and apply the principle of least privilege to PostgreSQL access.

Review:

* Database roles
* Login roles
* `GRANT`
* `REVOKE`
* Schema permissions
* Table permissions
* Sequence permissions
* Application database user permissions

The application should not automatically receive more database privileges than its operations require.

---

# Task 11 — Production Database Configuration

### Goal

Separate development database configuration from production-oriented configuration.

Review:

* Connection strings
* Environment-specific configuration
* Database credentials
* SSL/TLS database connections
* Minimum required privileges
* Secret injection
* Configuration validation
* Safe failure when required configuration is missing

Do not perform production deployment yet.

The objective at this stage is to understand how the application should be configured securely before deployment.

---

# Task 12 — Security Integration Testing

### Goal

Verify security behavior through actual HTTP/API behavior rather than source-code inspection alone.

## Authentication

* Missing JWT → rejected
* Invalid JWT → rejected
* Expired JWT → rejected

## Refresh Tokens

* Expired refresh token → rejected
* Revoked refresh token → rejected
* Reused rotated refresh token → rejected where applicable
* Logout → refresh token becomes unusable

## Authorization

* Authenticated user can access permitted resources
* User cannot access another customer's resources
* Unauthorized resource operations are rejected

## API Security

* CORS policy behaves as intended
* Rate-limited requests receive `429`
* Invalid request payloads are rejected
* Security headers are present where applicable
* HTTP/HTTPS behavior matches configuration

## Database Security

* Application cannot perform operations outside its database privileges
* Database commands respect cancellation
* Database commands respect configured timeouts

---

# Recommended Order

Work through the remaining security tasks in this order:

```text
1. Resource Ownership Authorization
        ↓
2. Authorization Policies
        ↓
3. HTTPS Verification
        ↓
4. CORS
        ↓
5. Rate Limiting
        ↓
6. Request Validation
        ↓
7. Input Sanitization Review
        ↓
8. Security Headers
        ↓
9. Secrets Management
        ↓
10. Database Least Privilege
        ↓
11. Production Database Configuration
        ↓
12. Security Integration Testing
```

This order keeps the learning progression aligned with the actual backend architecture.

---

# Definition of Done

Phase 8 Security Engineering can be considered complete when:

* Authentication works correctly.
* Protected endpoints require authentication.
* Resource ownership is enforced.
* Authorization policies are understood and implemented where justified.
* HTTPS behavior is verified.
* CORS is explicitly configured.
* Sensitive endpoints have appropriate rate limits.
* API request validation is enforced.
* Input handling has been reviewed according to the actual security threat.
* Appropriate security headers are configured.
* Secrets are separated from source-controlled configuration.
* Database access follows least privilege.
* Production-oriented database configuration is understood.
* Security behavior is covered by integration tests.
* No security mechanism exists merely because a framework feature was available.

---

# Current Task

**Start with Task 1 — Resource Ownership Authorization.**

Before adding roles or building the client, make the backend correctly enforce:

```text
Authenticated Identity
        ↓
Resource Ownership
        ↓
Authorization Decision
        ↓
Business Operation
```

The next implementation should focus on proving that one authenticated customer cannot operate on another customer's resources.
