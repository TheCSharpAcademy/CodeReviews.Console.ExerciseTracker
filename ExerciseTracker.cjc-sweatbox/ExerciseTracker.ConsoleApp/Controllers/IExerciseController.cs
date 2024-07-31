using ExerciseTracker.ConsoleApp.Models;

namespace ExerciseTracker.ConsoleApp.Controllers;

internal interface IExerciseController
{
    Task<bool> CreateAsync(CreateExerciseRequest request);
    Task<bool> DeleteAsync(int id);
    Task<ExerciseDto?> ReturnAsync(int id);
    Task<IReadOnlyList<ExerciseDto>> ReturnAsync();
    Task<bool> UpdateAsync(UpdateExerciseRequest request);
}