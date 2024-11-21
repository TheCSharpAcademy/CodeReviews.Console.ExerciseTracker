
dotnet new console -n $1
cd $1
dotnet new sln -n $1
dotnet sln add $1.csproj
mkdir Context Controllers Models Repositories Services Validators UserInputs
touch Context/Context.cs Controllers/Controller.cs Models/Model.cs Repositories/Repository.cs Services/Service.cs
touch Validators/Validator.cs UserInputs/UserInput.cs

