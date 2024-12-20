# Exercise Tracker Application

----
## Overview

---

The Exercise Tracker is a C# and .NET application designed to record exercise data, specifically focusing on Weights and Cardio exercises.

This application serves as a practical demonstration of essential software development concepts such as the Repository Pattern, Dependency Injection, and Separation of Concerns within the MVC architecture.

Key Features:
1. Dual Repositories:
- Weights Repository: Implements Entity Framework Core for data management.
- Cardio Repository: Utilizes Raw SQL to interact with the SQL Server database.

By combining these approaches, the application highlights how different data access strategies can coexist within a single system.

---
## IMPORTANT NOTE:
To run the application, follow these steps:

1. Create a Database: Set up a database in SQL Server named ExerciseDb.
2. Update Configuration: Open the appSettings.json file and update the DatabsePath string in the ConnectionStrings section to point to your SQL Server instance.
---

## Features

1. Record Exercise Data: Track essential exercise details like start time, end time, duration, and comments. The individual models provide additional specific details:

- Weights: Includes fields for weight, sets, and total weight lifted.
- Cardio: Captures metrics like distance covered.

2. Input Validation: Ensures data integrity using the UserInput and Validation utility classes. For example:

- DateStart must be before DateEnd.
- Numerical values (e.g., weights or distances) cannot be less than 0.
3. Branch for Separation of Concerns: Demonstrates how swapping Entity Framework with Dapper in the repository doesn’t impact other layers.


--- 
## Challenges faced

1. Repository Integration
    - Integrating two separate repositories with different data access strategies while maintaining a unified interface and adhering to the Repository Pattern posed a design challenge.
2. Dependency Injection Implementation
    - Implementing Dependency Injection for two distinct repositories—one for Weights using Entity Framework Core and one for Cardio using Raw SQL—required careful abstraction to keep the application flexible and testable.
3. Branch Management
    - Maintaining separate branches to showcase EF Core and Dapper implementations for the repositories required clear separation of code and effective Git workflows to avoid conflicts.