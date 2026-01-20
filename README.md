# Memberships

Opinionated **membership management backend** built with **.NET 10**, showcasing **Clean Architecture**, **strict CQRS**, **transactional pipelines**, and an **OpenAPI-first** approach using **Minimal APIs**.

This repository is intended as a **reference implementation**, not a demo or tutorial project.

---

## ✨ Key Characteristics

- **.NET 10**
- **Clean Architecture**
- **Strict CQRS (Commands / Queries separated)**
- **Transactional pipeline behavior**
- **Minimal APIs**
- **OpenAPI-first (no Swagger UI)**
- **Scalar for modern API reference (dev only)**
- **Entity Framework Core**
- **SQL Server (LocalDB for development)**
- **Soft Delete with global query filters**
- **Nullable Reference Types enabled**

---

## 🧱 Architecture Overview

The solution follows Clean Architecture principles, enforcing strict dependency boundaries:

```text

Memberships
├── Memberships.Domain
│   ├── Entities
│   ├── ValueObjects
│   └── BusinessRules
│
├── Memberships.Application
│   ├── Commands
│   ├── Queries
│   ├── DTOs
│   ├── Behaviors
│   │   ├── Validation
│   │   └── Transactions
│   └── Abstractions
│
├── Memberships.Infrastructure
│   ├── Persistence
│   │   ├── DbContext
│   │   ├── Configurations
│   │   └── Repositories
│
└── Memberships.Api
    ├── Endpoints
    ├── OpenAPI
    └── Bootstrap


```

### Dependency Rules

- **Domain** has no dependencies.
- **Application** depends only on Domain.
- **Infrastructure** depends on Application and Domain.
- **API** depends on Application and Infrastructure.

## 🔁 CQRS Strategy

This project uses **strict CQRS**:

- **Commands**
  - Change system state
  - Do not return entities
  - Executed inside a transaction
- **Queries**
  - Read-only
  - Never modify state
  - No transactions

Each use case has:
- A dedicated command or query
- A single handler
- Explicit validation

---

## 💼 Transaction Management

All commands are wrapped in a **transactional pipeline behavior**:

- Transactions are started automatically for commands
- Queries bypass transaction handling
- `SaveChanges` is centralized
- Application layer remains persistence-agnostic

This ensures:
- Atomic operations
- Consistent state
- Clean separation of concerns

---

## 🗄️ Persistence

- **Entity Framework Core**
- **Fluent API configurations**
- **No DataAnnotations**
- **Soft delete** implemented at the domain level
- **Global query filters** enforce soft delete automatically
- **SQL Server LocalDB** for development

---

## 📄 OpenAPI & API Documentation

This API follows an **OpenAPI-first** approach.

- OpenAPI specification:

/openapi/v1.json


- In **Development**, a modern API reference UI is available:


/scalar


### Why no Swagger UI?

Swagger UI is intentionally not bundled.  
The API exposes a clean OpenAPI contract that can be consumed by modern tools such as:

- Scalar
- Postman
- Bruno
- Insomnia

This keeps the backend **tooling-agnostic and decoupled**.

---

## ⚙️ Configuration

### Connection String (Development)

`appsettings.Development.json`:

```json
{
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MembershipsDb.Dev;Trusted_Connection=True;MultipleActiveResultSets=true"
}
}

🧪 Migrations

From the solution root:

dotnet ef migrations add InitialCreate \
  --project Memberships.Infrastructure \
  --startup-project Memberships.Api

dotnet ef database update \
  --project Memberships.Infrastructure \
  --startup-project Memberships.Api

🚀 Running the API
dotnet run --project Memberships.Api


The API will be available at:

https://localhost:<port>/
