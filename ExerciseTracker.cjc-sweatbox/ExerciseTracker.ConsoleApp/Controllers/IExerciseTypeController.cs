using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.ConsoleApp.Controllers;

internal interface IExerciseTypeController
{
    Task<bool> CreateAsync(CreateExerciseTypeRequest request);
    Task<bool> DeleteAsync(int id);
    Task<IReadOnlyList<ExerciseType>> ReturnAsync();
    Task<ExerciseType?> ReturnAsync(int id);
    Task<bool> UpdateAsync(UpdateExerciseTypeRequest request);
}