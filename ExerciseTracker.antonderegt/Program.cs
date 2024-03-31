using ExerciseTracker;
using ExerciseTracker.Controller;
using ExerciseTracker.Input;
using ExerciseTracker.Repository;
using ExerciseTracker.Service;

ExerciseContext context = new();
ExerciseRepository repository = new(context);
ExerciseService service = new(repository);
UserInput input = new();
ExerciseController exerciseController = new(service, input);

await exerciseController.MainMenu();