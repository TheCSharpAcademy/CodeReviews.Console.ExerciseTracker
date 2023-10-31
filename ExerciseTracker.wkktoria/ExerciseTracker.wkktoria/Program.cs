using System.Configuration;
using ExerciseTracker.wkktoria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
    });

var host = builder.Build();