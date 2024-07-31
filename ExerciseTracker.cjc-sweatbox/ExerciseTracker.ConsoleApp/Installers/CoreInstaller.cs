using ExerciseTracker.Configurations;
using ExerciseTracker.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExerciseTracker.ConsoleApp.Installers;

/// <summary>
/// Register the services required by the core library to the DI container.
/// </summary>
public class CoreInstaller : IInstaller
{
    #region Methods

    public void InstallServices(IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) =>
        {
            services.AddOptions<DatabaseOptions>().Bind(hostContext.Configuration.GetSection("DatabaseOptions"));
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IExerciseTypeService, ExerciseTypeService>();
            services.AddScoped<ISeederService, SeederService>();
        });
    }

    #endregion
}
