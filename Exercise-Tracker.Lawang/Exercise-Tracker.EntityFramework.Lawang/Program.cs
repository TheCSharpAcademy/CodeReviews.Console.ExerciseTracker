using Exercise_Tracker.EntityFramework.Lawang;
using Exercise_Tracker.EntityFramework.Lawang.Controller;
using Exercise_Tracker.EntityFramework.Lawang.Data;
using Exercise_Tracker.EntityFramework.Lawang.Models;
using Exercise_Tracker.EntityFramework.Lawang.Repository;
using Exercise_Tracker.EntityFramework.Lawang.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

DotNetEnv.Env.Load();

var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

// instance of service collection is created to register the services
var serviceCollection = new ServiceCollection();

serviceCollection.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(connectionString);
});

serviceCollection.AddTransient<IExerciseRepository, ExerciseRepository>();
serviceCollection.AddScoped<IExerciseService, ExerciseService>();
serviceCollection.AddScoped<ExerciseController>();
serviceCollection.AddScoped<UserInput>();


// Creates the instance of sevice provider to get access the services from the service collection
var serviceProvider = serviceCollection.BuildServiceProvider();
var controller = serviceProvider.GetRequiredService<ExerciseController>();
await controller.Run();
