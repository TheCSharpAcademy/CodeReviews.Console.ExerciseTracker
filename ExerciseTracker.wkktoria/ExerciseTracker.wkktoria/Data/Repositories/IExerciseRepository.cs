using ExerciseTracker.wkktoria.Data.Models;

namespace ExerciseTracker.wkktoria.Data.Repositories;

public interface IExerciseRepository
{
    List<Exercise> GetAllExercises();

    Exercise? GetExercise(int id);

    Exercise AddExercise(Exercise exercise);

    Exercise UpdateExercise(int id, Exercise updatedExercise);

    void DeleteExercise(int id, Exercise exerciseToDelete);
}