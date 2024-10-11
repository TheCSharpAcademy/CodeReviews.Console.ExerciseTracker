# ExerciseTracker.UndercoverDev

## Overview

ExerciseTracker.UndercoverDev is a robust API-driven application designed to help users track their exercise routines and fitness progress. Built with ASP.NET Core, this project implements a clean architecture pattern, separating concerns into distinct layers for improved maintainability and scalability.

## Features

- RESTful API for managing exercise data
- Entity Framework Core for database operations
- Dependency Injection for loose coupling
- Logging capabilities
- Customizable database connection

## Project Structure

The project is organized into several key components:

- `ExerciseTrackerAPI`: The main API project
- `Data`: Contains the database context
- `Repositories`: Implements data access patterns
- `Services`: Houses business logic
- `Controllers`: Manages API endpoints
- `Views`: Contains UI components
- `UserInteractions`: Controls user interaction in console
- `Utilities`: Utility methods for project

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server

### Installation

1. Clone the repository:
`git clone https://github.com/yourusername/ExerciseTracker.UndercoverDev.git`

2. Navigate to the project directory:
`cd ExerciseTracker.UndercoverDev`

3. Restore dependencies:
`dotnet restore`

4. Update the connection string in `appsettings.json` to point to your SQL Server instance.

5. Run the application:
`dotnet run`


## Configuration

The application uses dependency injection for configuration. Key services and repositories are registered in the `Program.cs` file:

```csharp```
```
builder.Services.AddDbContext<ExerciseTrackerContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IExerciseTrackerService, ExerciseTrackerService>();
builder.Services.AddScoped<IExerciseTrackerController, ExerciseTrackerController>();
```

## Database

The project uses Entity Framework Core with SQL Server. Ensure your connection string in `appsettings.json` is correctly configured.