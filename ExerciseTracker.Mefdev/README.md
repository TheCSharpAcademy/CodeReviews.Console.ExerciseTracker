## Exercise Tracker Console App

This is a simple CRUD application to record exercise data using Dependency Injection, Repository pattern, Entity Framework, and SQL Server.

### Features

- Record exercise data
- Choose one type of exercise
- Use raw SQL or Entity Framework for data persistence

### Model

The `Exercise` class has the following properties:
- `Id` (int): Unique identifier for the exercise
- `DateStart` (DateTime): Start date and time of the exercise
- `DateEnd` (DateTime): End date and time of the exercise
- `Duration` (TimeSpan): Duration of the exercise
- `Comments` (string): Comments related to the exercise

### Classes

- `UserInput`: Handles user input
- `ExerciseController`: Manages exercise-related operations
- `ExerciseService`: Handles business logic for exercises
- `ExerciseRepository`: Accesses exercise data from the database

### Setup

1. Ensure you have a SQL Server instance running.
2. Set the connection string environment variable for the database connection.
3. Build and run the application using the .NET CLI.

### Dependency Injection

The application uses dependency injection to access the repository from the controller. This ensures a clean separation of concerns and makes the application easier to maintain and test.

### Running the Application

To run the application, use the following command:

```sh
dotnet run
```

Make sure to set the connection string environment variable before running the application.

### Example

Here is an example of how to set the connection string environment variable:

```sh
export ConnectionStrings__DefaultConnection="Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
```

Replace `your_server`, `your_database`, `your_user`, and `your_password` with your actual database connection details.
