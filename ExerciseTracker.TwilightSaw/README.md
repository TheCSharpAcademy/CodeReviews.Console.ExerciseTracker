# ExerciseTracker

## Given Requirements:
- [x] This is an application where you can record exercise data.
- [x] You should be able to Add, Delete, Update and Read from a database, using the console.
- [x] Using Entity Framework or/and raw SQL.
- [x] Using SQL Server or SQLite.
- [x] Use Dependency Injection in the repository.
- [x] Application should have at least the following classes: UserInput, ExerciseController, ExerciseService and ExerciseRepository.
- [x] The Exercise model class should have at least the following properties: {Id INT, DateStart DateTime, DateEnd DateTime, Duration TimeSpan, Comments string}.

## Features

* SQL Server database connection with Entity Framework and Dapper ORM.
> [!IMPORTANT]
> After downloading the project, you should check appsetting.json and write your own path to connect the db.
> 
> ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/appsettings.png)

> [!IMPORTANT]
> Also you should do starting migrations to create db with all necessary tables, simply write ```dotnet ef database update``` in CLI.
> 
> ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/migrations.png)

* A console based UI where you can navigate by user input.

  ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/ui.png)

  ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/crud.png)

* CRUD abilities for your tracked exercises.

  ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/ui2.png)

  ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/crud2.png)

* Repository pattern structure

  ![image](https://github.com/TwilightSaw/CodeReviews.Console.ExerciseTracker/blob/main/ExerciseTracker.TwilightSaw/images/repository.png)	

## Challenges and Learned Lessons
- Repository pattern is very useful thing, you can swap different implementations of the same repository and it will work fine as well. 
- Moreover, you can say the same about interfaces as a whole.
- Delegates, predicates and generic types is a must to know.

## Areas to Improve
- Better usage of delegates and generic type parameters.

## Resources Used
- C# Academy guidelines and roadmap.
- ChatGPT for new information as EF usage, Repository Pattern, etc..
- Spectre.Console documentation.
- EF and Dapper ORM documentation.
- Various StackOverflow articles.
﻿
