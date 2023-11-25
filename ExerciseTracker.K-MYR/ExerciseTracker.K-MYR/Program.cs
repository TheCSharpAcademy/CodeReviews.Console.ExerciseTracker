using ExerciseTracker.K_MYR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseController, ExerciseController>();
builder.Services.AddScoped<UserInput>();
builder.Services.AddDbContext<ExerciseDbContext>();

using IHost host = builder.Build();

var ui = host.Services.GetRequiredService<UserInput>();
ui.ShowMainMenu();

