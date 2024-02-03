 

using ExerciseTracker.LONCHANICK.Controllers;
using ExerciseTracker.LONCHANICK.Data;
using ExerciseTracker.LONCHANICK.Menu;
using ExerciseTracker.LONCHANICK.Repository;
using ExerciseTracker.LONCHANICK.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal static class Program
{
    static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        var serviceProvider = host.Services;
        var MainMenu = serviceProvider.GetService<IMenu>();
        MainMenu!.MainMenu();
    }
    
    static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services
            .AddDbContext<ExerciseDbContext>()
            .AddScoped<IMenu, Menu>()
            .AddScoped<IExerciseController, ExerciseController>()
            .AddScoped<IExerciseServices, ExerciseServices>()
            .AddScoped<IExerciseRepository, ExerciseRepository>();
        });
    }
}

