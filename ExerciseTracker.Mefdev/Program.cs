using Microsoft.Extensions.DependencyInjection;
using ExerciseTracker.Mefdev;
using ExerciseTracker.Mefdev.UserInputs;
using ExerciseTracker.Mefdev.Services;
using ExerciseTracker.Mefdev.Controllers;
using ExerciseTracker.Mefdev.Repositories;
using ExerciseTracker.Mefdev.Context;

var serviceProvider = new ServiceCollection()
               .AddScoped<ExerciseContext>()
               .AddScoped<IRepository, ExerciseRepository>()
               .AddScoped<ExerciseService>()
               .AddScoped<UserInput>()
               .AddScoped<ExerciseController>()
               .AddScoped<UserInterface>()
               .BuildServiceProvider();

var app = serviceProvider.GetRequiredService<UserInterface>();
app.MainMenu();