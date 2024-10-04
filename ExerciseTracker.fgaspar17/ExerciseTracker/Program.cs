using ExerciseTracker;
using Microsoft.Extensions.DependencyInjection;

var host = Startup.StartApplication();

var userInterface = host.Services.GetRequiredService<UserInterface>();
userInterface.Run();