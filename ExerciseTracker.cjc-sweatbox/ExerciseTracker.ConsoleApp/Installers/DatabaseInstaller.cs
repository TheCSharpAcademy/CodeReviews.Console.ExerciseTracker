using ExerciseTracker.Data.Contexts;
using ExerciseTracker.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExerciseTracker.ConsoleApp.Installers;

/// <summary>
/// Register the services required by the Database to the DI container.
/// </summary>
public class DatabaseInstaller : IInstaller
{
    #region Methods

    public void InstallServices(IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) =>
        {
            var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<EntityFrameworkDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IExerciseTypeRepository, ExerciseTypeRepository>();
        });
    }

    #endregion
}
