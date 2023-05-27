using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sadklouds.ExcerciseTracker.Controllers;
using sadklouds.ExcerciseTracker.DataInput;
using sadklouds.ExcerciseTracker.DBContext;
using sadklouds.ExcerciseTracker.Repositries;
using sadklouds.ExcerciseTracker.Services;

//var config = GetConnectionString();
IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
    services =>
    {
        services.AddDbContext<ExerciseContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Default"));
        })
       .AddTransient<IExerciseService, ExerciseService>()
       .AddTransient<IExerciseRepository, ExerciseRepository>()
       .AddTransient<IUserInput, UserInput>()
       .AddTransient<IExerciseController, ExerciseController>();
    }).Build();

var exerciseController = _host.Services.GetService<IExerciseController>();
exerciseController.Run();


static string GetConnectionString(string connectionStringName = "Default")
{
    string output = "";

    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");
    var config = builder.Build();

    output = config.GetConnectionString(connectionStringName);
    return output;
}