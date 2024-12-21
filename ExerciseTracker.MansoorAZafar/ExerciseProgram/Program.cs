using ExerciseProgram.View;
using ExerciseProgram.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExerciseProgram.Repository;

//Setup the database
var services = new ServiceCollection();

services.AddDbContext<ExerciseContext>(options => 
    options.UseSqlite(new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", false, false)
                      .Build()["DB_CONN_STR"]));

services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<ExerciseService>();
var serviceProvider = services.BuildServiceProvider();

using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ExerciseContext>();
    context.Database.Migrate();
}

Dto.exerciseService = serviceProvider.GetRequiredService<ExerciseService>();

// Ensure the cache has the most updated version of the database when the application starts
Cache.UpdateList();

ExerciseManager manager = new();
manager.Begin();