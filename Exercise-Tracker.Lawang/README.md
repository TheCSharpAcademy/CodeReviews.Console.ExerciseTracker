
# Exercise-Tracker.Lawang
This project contains two sub folder :-
- Exercise-Tracker.EntityFramework is the main folder which serves the project requirements
- Exercise-Tracker.Challenge is the fork of the main project where we use EF core for Weights table and Dapper(Raw SQL) for Cardio table. 

## Features
- Uses Repository pattern, enabling Separation of Concerns and De-Coupling the business logic from the database operation.
- Repository Pattern is mostly noticed in the .NET projects so learning here is a bonus.







## Deployment

To deploy this project Create .env file and inside .env file replace "YOUR_CONNECTION_STRING" with your desired connection string.

`ConnectionString = YOUR_CONNECTION_STRING`

- Update a database to the migration
```bash
dotnet ef database update

```


 ## Screen shots:


![Screenshot from 2024-10-05 19-47-49](https://github.com/user-attachments/assets/7b54b07c-4736-4bd6-8613-d9bfeeba9706)



![Screenshot from 2024-10-05 19-48-07](https://github.com/user-attachments/assets/c4a8c565-ca45-45f2-b863-524564384a1b)


![Screenshot from 2024-10-05 19-48-28](https://github.com/user-attachments/assets/67debfea-41aa-4ffd-be79-2f481c1ac612)

- Data is presented to user in Table format, using the external library Spectre.Console.
- This app is beautified using Spectre.Console.



## Project Summary
#### What challenges did you face and how did you overcome them?

* I had previous expericnce using and creating .NET/WEB Api so this project was kind of a revision for me.




## 🛠 Skills Learned
### Repositorry pattern
- Repository pattern have two purposes; first it is an abstraction of the data layer and second it is a way of centralising the handling of the domain objects, this project helped me learn this pattern.

#### ENTITY-FRAMEWORK
* I had previous experiences with entity framework but doing this project was like a revision for me and helped me retain some crucial information

#### Spectre.Console
* I honed my Spectre.Console skill in this project which i previously learned.


## FAQ

#### How to beautify the table in the project?

Answer I used the Microsoft.Spectre.Console package, which you can get for Nuget package manager. Install it and add Reference to your project. 

For more information u can visit the docs https://spectreconsole.net




## Feedback

If you have any feedback, please reach out to us at depeshgurung44@gmail.com

