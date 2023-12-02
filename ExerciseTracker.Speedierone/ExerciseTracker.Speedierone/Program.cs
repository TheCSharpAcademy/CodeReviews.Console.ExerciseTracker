using ExerciseTracker.Speedierone;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExerciseTracker.Speedierone.Repository;
using ExerciseTracker.Speedierone.Service;

namespace ExerciseTracker;

class Program
{
   static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var mainMenu = host.Services.GetRequiredService<Main_Menu>();
        mainMenu.ShowMenu();
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<ExerciseDbContext>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<Main_Menu>();
            services.AddTransient<UserInput>();
        })
        .UseConsoleLifetime();
}
