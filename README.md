# Employee Management System  
**ASP.NET Core MVC | Clean Architecture | Identity & Roles**

A production-ready **Employee Management System** developed using **ASP.NET Core MVC**, designed with **Clean Architecture principles** and modern enterprise best practices.  
The application focuses on maintainability, scalability, and clear separation of concerns while implementing real-world business requirements.

---

## 📌 Project Overview

This project demonstrates how to build a structured MVC application using layered architecture, repository and service patterns, and ASP.NET Core Identity for authentication and authorization.

The system allows organizations to manage employees and departments efficiently, with support for role-based access control, soft deletion, and image handling.

---

## 🏗️ Architecture

The solution follows a **3-Layer Clean Architecture**:
```
WebApp2
│
├── PL (Presentation Layer)
│ ├── MVC Controllers
│ ├── Views
│ ├── Layouts & Partial Views
│
├── BLL (Business Logic Layer)
│ ├── Services (Interfaces & Implementations)
│ ├── ViewModels (DTO-like models)
│ ├── AutoMapper Profiles
│ ├── Business Rules
│
├── DAL (Data Access Layer)
│ ├── Entities
│ ├── Repository Pattern
│ ├── Entity Framework Core
```
Each layer is isolated and communicates only through abstractions, ensuring loose coupling and testability.

---

## ✨ Features

### 🔐 Authentication & Authorization
- ASP.NET Core Identity integration
- User registration, login, and logout
- Role-based authorization (`Admin`, `User`)
- Access Denied handling for unauthorized actions

---

### 👨‍💼 Employee Management
- Add new employees with image upload
- Edit employee information
- View employee details
- Soft delete employees
- Rehire inactive employees
- View:
  - All employees
  - Active employees
  - Inactive (deleted) employees

---

### 🏢 Department Management
- Retrieve departments
- Assign employees to departments
- Display department data in employee views

---

### 🗑️ Soft Delete Strategy
Employees are never permanently removed from the database:
- `IsDeleted = true` marks an employee as inactive
- Rehire restores the employee (`IsDeleted = false`)

This approach:
- Preserves data integrity
- Matches real enterprise business rules
- Allows auditing and recovery

---

## 🧠 Business Logic Design

- **Repository Pattern** for data access abstraction
- **Service Layer** to encapsulate business rules
- Unified response model using `Response<T>`:
  - Result
  - Error message
  - Error flag
- Exception-safe service execution

---

## 🔄 AutoMapper Usage

AutoMapper is used extensively to:
- Convert Entities ↔ ViewModels
- Flatten nested relationships (e.g., Department → Department Name)
- Eliminate repetitive manual mapping
- Improve code readability and maintainability

Mapping is centralized using a dedicated domain profile.

---

## 🧩 Dependency Injection

All dependencies are registered using ASP.NET Core’s built-in DI container:

- Repositories injected into services
- Services injected into controllers
- AutoMapper registered via modular extension methods

This ensures:
- Loose coupling
- Test-friendly design
- Clean startup configuration

---

## 🖼️ File Upload Handling

- Supports employee image upload
- Image path stored in the database
- Upload handled at service level
- Supports add and edit scenarios

---

## 🌍 Localization Support

- Culture switching via cookies
- Prepared for multi-language support
- Easy to extend with additional resources

---

## 🛠️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- AutoMapper
- SQL Server
- Razor Views
- Bootstrap & CSS
- Dependency Injection

---

## ▶️ How to Run the Project

1. Configure the SQL Server connection string
2. Apply Entity Framework migrations
3. Run the application
4. Create roles (`Admin`, `User`)
5. Register users and assign roles
6. Start managing employees

---

## 🎯 Learning Outcomes

This project demonstrates:

- Clean Architecture in ASP.NET Core
- Real MVC application flow
- Enterprise CRUD operations
- Role-based security
- Soft delete and rehire patterns
- Proper separation of concerns
- Scalable and maintainable codebase

---

## 👤 Author

**Hazem Mohamed Anter**  
Full Stack .NET Developer  
ITI Graduate – Full Stack Web Development (.NET)
