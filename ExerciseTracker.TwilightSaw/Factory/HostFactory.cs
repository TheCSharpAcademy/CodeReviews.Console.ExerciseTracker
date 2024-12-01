using ExerciseTracker.TwilightSaw.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExerciseTracker.TwilightSaw.Factory;

public class HostFactory
{
    public static IHost CreateDbHost(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        var configuration = builder.ConfigureServices((context, services) =>
        {
            var configuration = context.Configuration;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.None)
                .UseLazyLoadingProxies());
        });
        return configuration.Build();
    }
}