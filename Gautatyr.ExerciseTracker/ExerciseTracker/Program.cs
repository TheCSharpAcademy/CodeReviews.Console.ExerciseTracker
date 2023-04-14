using ExerciseTracker;
using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using ExerciseTracker.Services;

ExerciseTrackerContext context = new ExerciseTrackerContext();
RunRepository runRepository = new RunRepository(context);
RunService runService = new RunService(runRepository);
RunController runController = new(runService);

//For testing purposes
Run newRun = new()
{
    Start = DateTime.Now,
    End = DateTime.Now,
    Distance = "15",
    Comment = "This is a test"
};

newRun.SetDuration();

await runController.CreateRunAsync(newRun);

UserInput userInput = new(runController);

await userInput.MainMenuAsync();