using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.Services;

public interface IExerciseTypeService
{
    Task<bool> CreateAsync(ExerciseType exerciseType);
    Task<bool> DeleteAsync(int id);
    Task<ExerciseType?> ReturnAsync(int id);
    Task<IReadOnlyList<ExerciseType>> ReturnAsync();
    Task<bool> UpdateAsync(ExerciseType exerciseType);
}