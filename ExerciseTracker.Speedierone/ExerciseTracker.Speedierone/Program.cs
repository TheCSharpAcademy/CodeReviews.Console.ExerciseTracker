using ExerciseTracker.Speedierone;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Speedierone.Model;
using ExerciseTracker.Speedierone.Repository;

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
            services.AddTransient<ExerciseController>();
            services.AddTransient<Main_Menu>();
            services.AddTransient<UserInput>();
        })
        .UseConsoleLifetime();
}
