using ExerciseTracker.kalsson.Controllers;
using ExerciseTracker.kalsson.DataAccess;
using ExerciseTracker.kalsson.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

var host = CreateHostBuilder(args).Build();
var controller = host.Services.GetRequiredService<ExerciseController>();

var exit = false;
while (!exit)
{
    AnsiConsole.Clear();
    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("What would you like to do?")
            .AddChoices("View Exercises", "Add Exercise", "Update Exercise", "Delete Exercise", "Exit"));

    switch (choice)
    {
        case "View Exercises":
            await controller.DisplayAllExercisesAsync();
            break;
        case "Add Exercise":
            await controller.AddExerciseAsync();
            break;
        case "Update Exercise":
            await controller.UpdateExerciseAsync();
            break;
        case "Delete Exercise":
            await controller.DeleteExerciseAsync();
            break;
        case "Exit":
            exit = true;
            break;
    }

    if (!exit)
    {
        AnsiConsole.MarkupLine("[yellow]Press any key to continue...[/]");
        Console.ReadKey();
    }
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((
            context, services) =>
        {
            services.AddDbContext<ExerciseDbContext>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ExerciseService>();
            services.AddScoped<ExerciseController>();
        });