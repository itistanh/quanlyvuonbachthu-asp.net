# Zoo Management System 🦁🌿

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

> **A comprehensive web application for managing zoo resources, animals, and habitats, built with ASP.NET Core MVC.**

## 📘 Project Overview

**Zoo Management System** (Quản Lý Vườn Bách Thú) is a coursework project designed to demonstrate full-stack web development skills using the .NET ecosystem. The application allows administrators to track various animal species and their corresponding habitats efficiently.

This project highlights the use of **Code-First Migration**, **Dependency Injection**, and **MVC Architecture**.

## 📸 Screenshots

## 🛠 Tech Stack

* **Framework**: ASP.NET Core MVC (Model-View-Controller)
* **Language**: C#
* **Database**: SQL Server
* **ORM**: Entity Framework Core (Code First approach)
* **Frontend**: Razor Views (`.cshtml`), Bootstrap 5, jQuery
* **Tools**: Visual Studio, Git

## ✨ Key Features

* **🐘 Animal Management**:
    * CRUD operations (Create, Read, Update, Delete) for animals.
    * Track animal details (Name, Species, Age, Origin).
    * Assign animals to specific habitats.
* **deciduous_tree Habitat Management**:
    * Manage different environments (Savanna, Rainforest, Arctic, etc.).
    * View list of animals currently residing in a habitat.
* **📄 Advanced Data Handling**:
    * **Pagination**: Implemented `PagedResult` to handle large lists of data efficiently.
    * **Search & Filter**: Quickly locate animals or habitats.
    * **Validation**: Server-side and Client-side validation to ensure data integrity.

## 🗄️ Database Structure

The project uses **Entity Framework Core** to manage relationships:
* **Habitat** (1) ↔ (N) **Animal**: One habitat can contain multiple animals.
* **Migrations**: Database schema is version-controlled using EF Core Migrations.

## 🚀 Setup & Installation

1.  **Clone the repository**:
    ```bash
    git clone [https://github.com/itistanh/quanlyvuonbachthu-asp.net.git](https://github.com/itistanh/quanlyvuonbachthu-asp.net.git)
    ```
2.  **Configure Database**:
    Open `appsettings.json` and update the `ConnectionStrings` to match your local SQL Server.
3.  **Update Database**:
    Open **Package Manager Console** (or Terminal) and run:
    ```powershell
    Update-Database
    ```
    *This will automatically create the 'ZooDb' and all tables based on the Models.*
4.  **Run the Application**:
    Press **F5** in Visual Studio.
