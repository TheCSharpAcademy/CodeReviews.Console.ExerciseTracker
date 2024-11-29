using Microsoft.Extensions.DependencyInjection;
using ExerciseTracker.Mefdev;
using ExerciseTracker.Mefdev.UserInputs;
using ExerciseTracker.Mefdev.Services;
using ExerciseTracker.Mefdev.Controllers;
using ExerciseTracker.Mefdev.Repositories;
using ExerciseTracker.Mefdev.Context;

public class Program
{
    public static void Main()
    {
        try
        {
            LoadMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void LoadMenu()
    {

        var ServiceCollection = new ServiceCollection()
            .AddScoped<ExerciseContext>()
            .AddScoped<IRepository, ExerciseRepository>()
            .AddScoped<ExerciseService>()
            .AddScoped<UserInput>()
            .AddScoped<ExerciseController>()
            .AddScoped<UserInterface>()
            .BuildServiceProvider();

        using var context = ServiceCollection.GetRequiredService<ExerciseContext>();
        var app = ServiceCollection.GetRequiredService<UserInterface>();

        app.MainMenu();
    }
}