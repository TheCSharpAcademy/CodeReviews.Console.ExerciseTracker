using ExerciseTracker.TwilightSaw.Controllers;
using ExerciseTracker.TwilightSaw.Data;
using ExerciseTracker.TwilightSaw.Factory;
using ExerciseTracker.TwilightSaw.Model;
using ExerciseTracker.TwilightSaw.Repository;
using ExerciseTracker.TwilightSaw.Service;
using ExerciseTracker.TwilightSaw.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var app = HostFactory.CreateDbHost(args);

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
context.Database.Migrate();

new Menu(new ExerciseController(new ExerciseService(new ExerciseRepository<Exercise>(context)))).AddMenu();


