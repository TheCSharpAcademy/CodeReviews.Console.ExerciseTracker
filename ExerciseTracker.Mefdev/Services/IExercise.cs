using ExerciseTracker.Mefdev.Models;

namespace ExerciseTracker.Mefdev.Services;

public interface IExercise
{
    IEnumerable<Exercise> GetAll();
    Exercise? GetById(int id);
    bool Create(Exercise entity);
    bool Update(Exercise entity);
    bool Delete(int id);
}