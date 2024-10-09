using Exercise_Tracker.Challenge;
using Exercise_Tracker.Challenge.Controllers;
using Exercise_Tracker.Challenge.Data;
using Exercise_Tracker.Challenge.Repositories;
using Exercise_Tracker.Challenge.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

DotNetEnv.Env.Load();

ApplicationConnection.ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");


var serviceProvder = new ServiceCollection()
    .AddDbContext<WeightDbContext>(options => {
        options.UseSqlServer(ApplicationConnection.ConnectionString);
    })
    .AddTransient<ICardioRepository, CardioRepository>()
    .AddTransient<IWeightRepository, WeightRepository>()
    .AddScoped<CardioDbContext>()
    .AddScoped<CardioService>()
    .AddScoped<WeightService>()
    .AddSingleton<CardioController>()
    .AddSingleton<WeightController>()
    .AddSingleton<ApplicationController>()
    .AddSingleton<UserInput>()
    .BuildServiceProvider();

var app = serviceProvder.GetRequiredService<ApplicationController>();

await app.Run();