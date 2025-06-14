# 📰 SonXeber - Simple News Website with Clean Architecture

This is a simple news publishing website built using **ASP.NET Core** and **Clean Architecture** principles. It allows users to create, edit, and delete news articles. The project structure promotes separation of concerns, testability, and scalability.

---

## 📐 Architecture Overview

This solution follows the **Clean Architecture** structure with the following layers:

```
SonXeber
│
├── SonXeber.Domain         → Entity models, interfaces, enums
├── SonXeber.Application    → Use cases, DTOs, interfaces, services
├── SonXeber.Infrastructure → Database context, repositories, API implementations
├── SonXeber.API            → REST API endpoints (Controller-based)
└── SonXeber.WebUI          → Razor Pages/MVC frontend (Views and Controllers)
```

---

## 🚀 Features

- ✅ List all news articles  
- 📝 Create, edit, delete news  
- 🔍 View details of each news item  
- 🧱 Clean Architecture structure  
- 🌐 Razor Views for frontend UI  
- 🔄 API-based data interaction  
- 🎯 Entity Framework Core for data access

---

## 🛠️ Technologies Used

- ASP.NET Core 8
- Entity Framework Core
- Clean Architecture
- Razor Pages / MVC
- AutoMapper
- SQL Server or SQLite (configurable)

---

## ⚙️ How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/AliHasanov97/News.git
   cd SonXeber
   ```

2. Set both **SonXeber.API** and **SonXeber.WebUI** as startup projects in Visual Studio.

3. Apply migrations:
   ```bash
   cd SonXeber.Infrastructure
   dotnet ef database update
   ```

4. Run the solution (F5 or Ctrl+F5 in Visual Studio).

---

## 📂 Folder Breakdown

| Folder                  | Purpose                             |
|-------------------------|-------------------------------------|
| `SonXeber.Domain`       | Core entities and contracts         |
| `SonXeber.Application`  | Business logic and use cases        |
| `SonXeber.Infrastructure` | EF Core implementation & repositories |
| `SonXeber.API`          | RESTful backend (API layer)         |
| `SonXeber.WebUI`        | Frontend web app with Razor views   |

---

## 🙌 Author

- Ali Hasanov
- [GitHub](https://github.com/AliHasanov97/))  

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).
