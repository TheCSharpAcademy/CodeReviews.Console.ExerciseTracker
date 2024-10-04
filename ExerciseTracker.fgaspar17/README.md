# Exercise Tracker

A console-based application to help you manage your exercise sessions.
Developed using C#, Entity Framework, Spectre.Console,
SQL Server Express LocalDB, and SQLite.

## Given Requirements

- [x] This is an application where you should record exercise data.
- [x] You should choose one type of exercise only. We want to keep the app simple so
you focus on the subject you're learning and not on the business complexities.
- [x] You can choose raw SQL or Entity Framework for your data-persistence.
- [x] The model for your exercise class should have at least the following properties:
{Id INT, DateStart DateTime, DateEnd DateTime, Duration TimeSpan, Comments string}
- [x] Your application should have the following classes: UserInput, ExerciseController,
ExerciseService (where business logic will be handled) and ExerciseRepository.
These classes might feel empty at first but they'll be needed in most applications as they grow.
- [x] You can choose between SQLite or SQLServer.
- [x] You need to use dependency injection to access the repository from the controller.

## Features

- SQL Server database connection

  - The data is stored in a SQL Server database. I connect to it for the CRUD.
  - The database is managed by Entity Framework and raw SQL with ADO.NET.
  You should add an initial migration and update the database first.

- Console-based UI to navigate the menus
  - ![image](https://github.com/user-attachments/assets/c113cb8d-cbe9-4ae3-9b8f-aefabf059121)

- CRUD operations

  - From the Menu, you can create, show, or delete exercise sessions.
  To choose an option, you make use of the arrow keys and enter.
  - Inputs are validated. For start and end times, you can check the given examples.
  - ![image](https://github.com/user-attachments/assets/1ecf1d84-e6fb-4911-b3af-de329c1d6420)
  - You can cancel an operation by entering the string from the configuration file.

- Switch Exercise Sessions
  - You can change between two databases. The application starts both, so you can pick one
for one exercise and the other one for another.

## Challenges

- Repository pattern
- Create an `IHost` to configure the application.
- Switching between repositories at running time.
- Ignore a property in Entity Framework.

## Lessons Learned

- Building flexible code with interfaces and repository pattern.
- Configuring services at the start of an application.
- How dependency injection works.
- Dispatcher class implementing the strategy pattern.
- Ignoring properties in Entity Framework.

## Areas to Improve

- Design patterns.
- Dependency injection.
- Entity Framework possibilities.

## Resources used

- StackOverflow posts
- ChatGPT
- [Repository Pattern Implementation](https://medium.com/@kerimkkara/implementing-the-repository-pattern-in-c-and-net-5fdd91950485)
- [Repository Pattern in .NET Core](https://programmingwithwolfgang.com/repository-pattern-net-core/)
- [Dependency Injection Docs](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage)
- [Stack Overflow Dispatcher Class](https://stackoverflow.com/questions/29113206/change-injected-object-at-runtime)
