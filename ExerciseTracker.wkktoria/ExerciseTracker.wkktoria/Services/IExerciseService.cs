using ExerciseTracker.wkktoria.Data.Models;

namespace ExerciseTracker.wkktoria.Services;

public interface IExerciseService
{
    List<Exercise> GetAllExercises();

    Exercise? GetExercise(int id);

    Exercise? AddExercise(Exercise exercise);

    Exercise UpdateExercise(Exercise updatedExercise);

    void DeleteExercise(Exercise exerciseToDelete);
}