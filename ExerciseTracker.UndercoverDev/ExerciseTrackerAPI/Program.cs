using Microsoft.EntityFrameworkCore;
using ExerciseTrackerAPI.Data;
using ExerciseTrackerAPI.Repositories;
using ExerciseTrackerAPI.Services;
using ExerciseTrackerUI.Views;
using ExerciseTrackerAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ExerciseTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IExerciseTrackerService, ExerciseTrackerService>();
builder.Services.AddScoped<IExerciseTrackerController, ExerciseTrackerController>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var servicesExtension = scope.ServiceProvider;

var controller = servicesExtension.GetRequiredService<IExerciseTrackerController>();
var services = servicesExtension.GetRequiredService<IExerciseTrackerService>();

var weightsView = new WeightsView(controller);
var menu = new MainMenu(weightsView);

await menu.ShowMainMenu();