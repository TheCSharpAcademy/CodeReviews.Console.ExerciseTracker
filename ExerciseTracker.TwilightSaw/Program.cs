using ExerciseTracker.TwilightSaw.Controller;
using ExerciseTracker.TwilightSaw.Data;
using ExerciseTracker.TwilightSaw.Factory;
using ExerciseTracker.TwilightSaw.Model;
using ExerciseTracker.TwilightSaw.Repository;
using ExerciseTracker.TwilightSaw.Service;
using ExerciseTracker.TwilightSaw.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var app = HostFactory.CreateDbHost(args);

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
context.Database.Migrate();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

new Menu(new ExerciseController(new ExerciseService(new ExerciseRepository<Exercise>(context), 
    new ExerciseDapperRepository<Exercise>(configuration)))).AddMenu();


