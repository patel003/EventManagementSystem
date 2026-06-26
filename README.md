#  Event Management System

A web-based **Event Management System** developed using **ASP.NET Core MVC** with **ADO.NET**, following a clean **3-Tier Architecture**. The system allows users to register, log in, browse, and manage events in a scalable and maintainable way.

---

##  Table of Contents

- [About the Project](#about-the-project)
- [Architecture](#architecture)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Database Setup](#database-setup-adonet)
- [Contributing](#contributing)
- [Contact](#contact)

---

##  About the Project

The **Event Management System** is built on **ASP.NET Core MVC** with **ADO.NET** for database communication. It follows a **3-Tier Architecture** by implementing separate **DAL (Data Access Layer)** and **BAL (Business Access Layer)**, making the application:

- ✅ **Separable** — Each layer has its own responsibility
- ✅ **Scalable** — Easy to extend features
- ✅ **Maintainable** — Clean code structure

---

##  Architecture

This project uses a **3-Layer / 3-Tier Architecture**:

```
┌──────────────────────────────────────┐
│        Presentation Layer            │
│     (ASP.NET Core MVC - Views,       │
│      Controllers, Models)            │
├──────────────────────────────────────┤
│        Business Access Layer (BAL)   │
│  (Application Logic & Business Rules)│
├──────────────────────────────────────┤
│        Data Access Layer (DAL)       │
│  (ADO.NET - SqlConnection,           │
│   SqlCommand, SqlDataReader, etc.)   │
└──────────────────────────────────────┘
               ⬇
        SQL Server Database
```

### Layer Responsibilities:

**1. Presentation Layer (MVC)**
- Handles UI and user interaction
- Contains Controllers, Views, and Models (MVC pattern)
- Routes user requests to BAL

**2. Business Access Layer (BAL)**
- Contains all business logic and rules
- Acts as a bridge between Presentation Layer and DAL
- Validates and processes data before passing to DAL

**3. Data Access Layer (DAL)**
- Handles all database communication using **ADO.NET**
- Uses `SqlConnection`, `SqlCommand`, `SqlDataReader`, `SqlDataAdapter`
- Executes SQL queries for CRUD operations

---

##  Features

-  **User Registration** — New users can sign up
-  **User Login** — Secure authentication
-  **Browse Events** — View all available events
-  **Add / Manage Events** — Create and manage events
-  **Database Driven** — All data stored and fetched via ADO.NET
-  **3-Tier Architecture** — Clean separation of concerns

---

##  Tech Stack

| Technology          | Usage                                      |
|---------------------|--------------------------------------------|
| ASP.NET Core MVC    | Web Framework (Presentation Layer)         |
| ADO.NET (C#)        | Database Connectivity (DAL)                |
| SQL Server          | Database                                   |
| JavaScript          | Frontend Interactivity (78.9%)             |
| CSS                 | Styling & UI (19.2%)                       |
| HTML                | Structure (1.2%)                           |
| Docker              | Containerization & Deployment              |

---

##  Project Structure

```
EventManagementSystem/
├── EventManagementSystem/
│   ├── Controllers/          # MVC Controllers (Presentation Layer)
│   ├── Views/                # Razor Views (.cshtml)
│   ├── Models/               # Data Models
│   ├── BAL/                  # Business Access Layer
│   │   └── EventBAL.cs       # Business logic for events
│   ├── DAL/                  # Data Access Layer
│   │   └── EventDAL.cs       # ADO.NET database operations
│   ├── wwwroot/              # Static files (CSS, JS, Images)
│   └── appsettings.json      # Configuration & Connection String
├── .dockerignore
├── .gitattributes
├── .gitignore
├── EventManagementSystem.sln
└── README.md
```

---

##  Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (v6.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- [Docker](https://www.docker.com/) *(optional)*

---

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/patel003/EventManagementSystem.git
   cd EventManagementSystem
   ```

2. **Update Connection String** in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=EventManagementDB;Trusted_Connection=True;"
   }
   ```

3. **Build and Run**
   ```bash
   dotnet build
   dotnet run
   ```

4. Open browser → `https://localhost:5001`

---

### Running with Docker 

```bash
docker build -t event-management-system .
docker run -p 5001:5001 event-management-system
```

---

##  Database Setup (ADO.NET)

1. **Create Database** in SQL Server:
   ```sql
   CREATE DATABASE EventManagementDB;
   ```

2. **Sample Tables:**
   ```sql
   CREATE TABLE Users (
       UserId INT PRIMARY KEY IDENTITY,
       UserName VARCHAR(100),
       Email VARCHAR(100),
       Password VARCHAR(255)
   );

   CREATE TABLE Events (
       EventId INT PRIMARY KEY IDENTITY,
       EventName VARCHAR(200),
       EventDate DATETIME,
       Location VARCHAR(300),
       Description TEXT
   );
   ```

3. **ADO.NET is used in DAL for:**
   - `SqlConnection` — Database connection
   - `SqlCommand` — Execute SQL queries
   - `SqlDataReader` — Read data row by row
   - `SqlDataAdapter` + `DataSet` — Fill and manage data

---

##  Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/NewFeature`)
3. Commit your changes (`git commit -m 'Add NewFeature'`)
4. Push to the branch (`git push origin feature/NewFeature`)
5. Open a Pull Request

---

##  Contact

**Vikas Patel**
- GitHub: [@patel003](https://github.com/patel003)
- LinkedIn: [Vikas Patel](https://www.linkedin.com/in/vikaspatel4441)

---

>  If you found this project helpful, please give it a star on GitHub!
