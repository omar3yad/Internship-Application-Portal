# 🎓 Internship Application Portal

A web-based backend system that streamlines the internship application process between university students and company HR departments. Built with **ASP.NET Core Web API** and follows Clean Architecture principles.

---

## 🚀 Features

### 👩‍🎓 Students
- View available internships.
- Apply for internships with resume upload.
- Track application status (Pending, Under Review, Accepted, Rejected).

### 🧑‍💼 Company HR
- Post and manage internship listings.
- Review applications submitted by students.
- Update application statuses.

### 🛠 Admin
- Manage students, companies, and internships.
- Assign roles and control access.

---

## 🛠 Tech Stack

| Layer | Technology |
|-------|------------|
| Backend | ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Auth | JWT Authentication |
| Mapping | AutoMapper |
| API Docs | Swagger |
| Testing Tools | Postman |
| Version Control | Git & GitHub |

---

## 🧠 Architecture

The project follows **Clean Architecture** with the following structure:

- **DTOs** – For data transfer between layers  
- **Repositories** – Handle DB operations  
- **Services** – Business logic  
- **Controllers** – Expose RESTful endpoints  

> Follows SOLID Principles and uses Repository & Unit of Work Design Patterns.

📁 Sample folder structure:

