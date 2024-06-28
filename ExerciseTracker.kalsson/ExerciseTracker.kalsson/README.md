# Exercise Tracker

## Overview
Exercise Tracker is a console application for recording exercise data using the Repository Pattern. This application demonstrates how to create a simple, loosely-coupled, testable, and maintainable application using C# and Entity Framework Core with dependency injection.

## Features
- Record exercise data including start time, end time, duration, and comments.
- View all recorded exercises.
- Update existing exercises.
- Delete exercises.
- Interactive console interface using Spectre.Console.

## Technologies Used
- C#
- .NET Core
- Entity Framework Core
- SQL Server (or SQLite)
- Spectre.Console

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- SQL Server or SQLite installed and configured.

## Setup Instructions
1. **Clone the Repository**
2. **Restore Dependencies**: "dotnet restore".
3. **Configure Database**
* Update the connection string in appsettings.json to point to your SQL Server or SQLite database: 

**"Default": "Server=(localdb)\\MSSQLLocalDB;Database=ExerciseTracker;Trusted_Connection=True;"**

4. **Apply Migrations and Update Database**
-   dotnet ef migrations add InitialCreate
-   dotnet ef database update

5. **Run the Application**: dotnet run

## Usage
On running the application, you will be presented with a menu to choose actions:
- View Exercises
- Add Exercise
- Update Exercise
- Delete Exercise
- Exit

Follow the prompts to interact with the application and manage your exercise records