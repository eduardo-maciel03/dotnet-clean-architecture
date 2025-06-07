# TaskManager.CleanArch

ASP.NET Core project that implements Clean Architecture with a focus on layered organization, cookie-based authentication, minimalist endpoints, automated testing with xUnit and FluentAssertions. Ideal for demonstrating good practices in scalable, secure and testable APIs.

## 🔧 Technologies

- **ASP.NET Core 8**
- **Minimal APIs**
- **Cookie Authentication**
- **Clean Architecture (Domain, Application, Infrastructure, Presentation)**
- **xUnit + FluentAssertions** (tests)
- **Swagger/OpenAPI**

---

## 🧱 Project Structure
```
TaskManager/
├── Domain/ → Domain entities and interfaces
├── Application/ → Use cases and DTOs
├── Infrastructure/ → Repositories (mock/in-memory)
├── WebAPI/ → Endpoints, authentication and configuration
├── Tests/ → Unit tests with xUnit
```

---

## ✅ Features

- ✅ Creating tasks with title and description
- ✅ Listing tasks
- ✅ Authentication with cookie (login/logout)
- ✅ Protecting routes for authenticated users
- ✅ Unit tests for use cases
- ✅ Swagger UI for documentation

---

## 🔐 Authentication

The system uses **cookie-based authentication** with simulated identity for demonstration purposes.

### Login

```http
POST /api/authentication/login
Content-Type: application/json

{
  "email": "admin@admin.com",
  "password": "123456"
} 
```

Returns a valid authentication cookie to use in protected routes.

## 📦 Main Endpoints

```http
GET /api/tasks — list tasks (requires authentication)
POST /api/tasks — create task (requires authentication)
```

## 🧪 xUnit

In TaskManager.Tests, run: dotnet test
