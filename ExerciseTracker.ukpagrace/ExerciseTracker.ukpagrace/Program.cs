using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using ExerciseTracker.ukpagrace.Model;
using ExerciseTracker.ukpagrace.Interfaces;
using ExerciseTracker.ukpagrace.Repository;
using ExerciseTracker.ukpagrace.Services;
using ExerciseTracker.ukpagrace.Controllers;
using ExerciseTracker.ukpagrace.UserInterface;


var builder = Host.CreateApplicationBuilder();

builder.Services.AddDbContext<ExerciseContext>();


builder.Services.AddScoped<IExerciseRepository<Exercise>, ExerciseRepository<Exercise>>();
builder.Services.AddScoped<IExerciseService<Exercise>, ExerciseService<Exercise>>();
builder.Services.AddScoped<ExerciseController>();
builder.Services.AddScoped<Menu>();

using IHost app = builder.Build();

var menu = app.Services.GetRequiredService<Menu>();

menu.Main();