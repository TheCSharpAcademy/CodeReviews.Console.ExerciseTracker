using Exercisetacker.Controllers;
using Exercisetacker.Data;
using Exercisetacker.Repositories;
using Exercisetacker.Repositories.Interfaces;
using Exercisetacker.Services;
using Exercisetacker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        config.AddUserSecrets<Program>();
    })
    .ConfigureLogging((context, logging) =>
    {
        logging.ClearProviders();
        logging.AddConsole();
        logging.AddConfiguration(context.Configuration.GetSection("Logging"));
    })
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<JoggingDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.LogTo(Console.WriteLine, LogLevel.Warning); // Configure EF Core to log at Warning level
        });

        services.AddScoped<IJoggingRepository, JoggingRepository>();
        services.AddScoped<IJoggingService, JoggingService>();
        services.AddScoped<JoggingController>();

        services.AddHostedService<ConsoleAppService>();
    })
    .Build();

await host.RunAsync();