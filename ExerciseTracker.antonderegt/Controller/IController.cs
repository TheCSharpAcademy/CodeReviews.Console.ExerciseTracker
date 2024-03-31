using ExerciseTracker.Models;

namespace ExerciseTracker.Controller;

public interface IController
{
    Task MainMenu();
    Task<IEnumerable<Exercise>?> ShowAllExercisesAsync();
    Task AddExerciseAsync();
    Task UpdateExerciseAsync();
    Task DeleteExerciseByIdAsync();
}