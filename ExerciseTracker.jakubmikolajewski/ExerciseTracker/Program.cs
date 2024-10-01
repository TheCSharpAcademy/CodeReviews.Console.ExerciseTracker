using Microsoft.Extensions.DependencyInjection;
using ExerciseTracker.Data;
using Spectre.Console;
using ExerciseTracker.Services;
using ExerciseTracker.Controllers;
using ExerciseTracker.UserInterface;

internal class Program
{
    private static void Main(string[] args)
    {
        ExercisesController controller = new(CongifureServices());

        if (controller is null)
        {
            AnsiConsole.Markup("[red]Failed to initialize controller.[/]");
            return;
        }

        controller.CreateDatabase();
        Menu menu = new(controller);
        menu.ShowMenu();
    }

    private static ServiceProvider CongifureServices()
    {
        ServiceCollection services = new();
        services.AddDbContext<ExerciseTrackerContext>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IExerciseService, ExerciseService>();
        return services.BuildServiceProvider();
    }
}