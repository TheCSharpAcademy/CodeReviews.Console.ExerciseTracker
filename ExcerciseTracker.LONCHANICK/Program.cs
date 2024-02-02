// using ExerciseTracker.LONCHANICK.Menu;

/*
    revisa bien como hacer dependency injection en console aplications
*/
// Menu menu = new();
// await menu.MainMenu();


// using ExerciseTracker.LONCHANICK.Services;
// using ExerciseTracker.LONCHANICK.Controllers;
// using ExerciseTracker.LONCHANICK.Menu;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using ExerciseTracker.LONCHANICK.Repository;

// HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// // builder.Services.AddHostedService<Worker>();
// builder.Services.AddTransient<IMenu, Menu>();
// builder.Services.AddTransient<IExerciseController, ExerciseController>();
// builder.Services.AddTransient<IExerciseServices, ExerciseServices>();
// builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();

// using IHost host = builder.Build();

// host.Run();

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
        var exerciseController = serviceProvider.GetService<IMenu>();
        exerciseController!.MainMenu();
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

