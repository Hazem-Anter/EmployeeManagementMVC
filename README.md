# Employee Management System  
**ASP.NET Core MVC | Clean Architecture**

A full-featured **Employee Management System** built using **ASP.NET Core MVC**, following **Clean Architecture principles** with a clear separation of concerns across Presentation, Business, and Data layers. The project demonstrates enterprise-level structure and best practices.

---

## Project Highlights

- Secure authentication using **ASP.NET Core Identity**
- **Role-based authorization** (Admin / User)
- Complete employee lifecycle management:
  - Add, edit, view, and soft delete employees
  - Rehire inactive employees
- Department assignment and management
- Employee image upload and update support
- **AutoMapper** for Entity ↔ ViewModel mapping
- Unified service response handling with `Response<T>`

---

## Architecture Overview

PL → Controllers, Razor Views, Layouts
BLL → Services, Business Logic, ViewModels, Mapping
DAL → Entities, Repositories, EF Core


---

## Core Concepts Applied

- Clean Architecture
- Repository & Service Patterns
- Dependency Injection
- Soft Delete Strategy
- Separation of Concerns

---

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- AutoMapper
- SQL Server
- Razor Views & Bootstrap

---

## Author

**Hazem Mohamed Anter**  
Full Stack .NET Developer | ITI Graduate
