using ExerciseTracker.Controllers;
using ExerciseTracker.Data;
using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using ExerciseTracker.Services;
using ExerciseTracker.Utilities;
using ExerciseTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = ConfigureServices();
RunApplication(serviceProvider);

ServiceProvider ConfigureServices()
{
    string connectionString = DataExtensions.GetConnectionString();
    
    var services = new ServiceCollection()
        .AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString)) // Registers AppDbContext with dependency injection
        .AddScoped(typeof(IRepository<>), typeof(WeightRepository<>))
        .AddScoped<IRepository<Cardio>, CardioRepository>()
        .AddScoped(typeof(IExerciseService<>), typeof(ExerciseService<>)) // Generic service
        .AddScoped<WeightsController>() // Register controllers
        .AddScoped<CardioController>()
        .BuildServiceProvider(); // Build the service provider

    return services;
}

void RunApplication(ServiceProvider serviceProvider)
{
    var weightController = serviceProvider.GetService<WeightsController>();
    var cardioController = serviceProvider.GetService<CardioController>();

    if (weightController == null || cardioController == null)
    {
        Console.WriteLine("Unable to initialise controllers.");
        return;
    }
    
    var userInterface = new UserInterface(weightController, cardioController);
    userInterface.Run();
}