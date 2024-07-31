using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.Services;

public interface IExerciseService
{
    Task<bool> CreateAsync(Exercise exercise);
    Task<bool> DeleteAsync(int id);
    Task<Exercise?> ReturnAsync(int id);
    Task<IReadOnlyList<Exercise>> ReturnAsync();
    Task<bool> UpdateAsync(Exercise exercise);
}