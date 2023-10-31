using System.Configuration;
using ExerciseTracker.wkktoria.Controllers;
using ExerciseTracker.wkktoria.Data;
using ExerciseTracker.wkktoria.Data.Repositories;
using ExerciseTracker.wkktoria.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IExerciseController, ExerciseController>();
    });

var host = builder.Build();