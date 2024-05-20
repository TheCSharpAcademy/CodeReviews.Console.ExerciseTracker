using ExerciseTracker.samggannon.Controllers;
using ExerciseTracker.samggannon.Data.Repositories;
using ExerciseTracker.samggannon.Services;
using ExerciseTracker.samggannon.UserInterface;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ExerciseRepository>()
    .AddSingleton<ResistanceRespository>()
    .AddSingleton<IExerciseService, ExerciseService>()
    .AddScoped<ExerciseController>()
    .BuildServiceProvider();

var mainMenu = new MainMenu(serviceProvider);
mainMenu.ShowMenu();

