using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExerciseTracker;
using Microsoft.Extensions.Configuration;
using System;

public class Startup
{
    public static IHost StartApplication()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfiguration config = builder.Build();

        string? connectionString = config.GetConnectionString("Sqlite");
        GlobalConfig.InitializeConnectionString(connectionString);
        SetupSqliteDatabase.InitializeSqliteDatabase();

        GlobalConfig.CurrentDatabase = DbOption.SqlServerEntityFramework;

        CancelSetup.CancelString = config.GetValue<string>("CancelString") ?? "c";

        var host = new HostBuilder()
            .ConfigureServices
            ((hostContext, services) =>
            {
                services.AddDbContext<ExerciseContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("SqlServer"), b => b.MigrationsAssembly("ExerciseTracker")));
                services.AddTransient(typeof(ExerciseAdoNetRepository));
                services.AddTransient(typeof(ExerciseRepositoryEf));
                services.AddTransient(typeof(IRepository<Exercise>), (r =>
                {
                    return new RepositoryDispatcher<Exercise>(() => GlobalConfig.CurrentDatabase,
                        [ r.GetRequiredService<ExerciseAdoNetRepository>(),
                            r.GetRequiredService<ExerciseRepositoryEf>(), ]);
                }));
                services.AddTransient(typeof(IExerciseController), typeof(ExerciseController));
                services.AddTransient(typeof(ExerciseService));
                services.AddTransient(typeof(ExerciseMenuHandler));
                services.AddTransient(typeof(UserInterface));
                services.BuildServiceProvider();
            }).Build();

        return host;
    }
}