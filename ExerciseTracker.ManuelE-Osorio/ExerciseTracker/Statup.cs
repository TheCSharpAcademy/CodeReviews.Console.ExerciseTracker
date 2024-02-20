using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using ExerciseTracker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ExerciseTracker;

public class StartUp
{
    public static IHost AppInit()
    {    // wait for configuration UI Messague;
        var appBuilder = new HostBuilder();
        appBuilder.ConfigureAppConfiguration(p =>
            p.AddJsonFile("appsettings.json").Build());

        appBuilder.ConfigureServices((host, services) =>
        {
            services.AddDbContext<ExerciseTrackerContext>(options => options
                .UseSqlServer(host.Configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine));
            services.AddScoped<IExerciseRepository<Running>, RunningRepository>();
            services.AddScoped<IExerciseService<Running>, RunningService>();
            services.AddScoped<RunningController>();
        });

        var app = appBuilder.Build();
        var exerciseController = app.Services.CreateScope()
            .ServiceProvider.GetRequiredService<RunningController>();

        exerciseController.TryConnection();

        return app;
    }
}