using ExerciseTracker.kalsson;
using ExerciseTracker.kalsson.Controllers;
using ExerciseTracker.kalsson.DataAccess;
using ExerciseTracker.kalsson.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = CreateHostBuilder(args).Build();
var userInput = host.Services.GetRequiredService<UserInput>();

await userInput.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<ExerciseDbContext>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ExerciseService>();
            services.AddScoped<ExerciseController>();
            services.AddScoped<UserInput>();
        });