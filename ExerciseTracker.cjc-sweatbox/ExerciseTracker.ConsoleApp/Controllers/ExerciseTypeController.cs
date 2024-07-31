using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.Services;

namespace ExerciseTracker.ConsoleApp.Controllers;

/// <summary>
/// Controller for interfacing to the required application services.
/// </summary>
internal class ExerciseTypeController : IExerciseTypeController
{
    #region Fields

    private readonly IExerciseService _exerciseService;
    private readonly IExerciseTypeService _exerciseTypeService;

    #endregion
    #region Constructors

    public ExerciseTypeController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService)
    {
        _exerciseService = exerciseService;
        _exerciseTypeService = exerciseTypeService;
    }

    #endregion
    #region Methods

    public async Task<bool> CreateAsync(CreateExerciseTypeRequest request)
    {
        var exerciseType = new ExerciseType
        {
            Name = request.Name
        };

        return await _exerciseTypeService.CreateAsync(exerciseType);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _exerciseTypeService.DeleteAsync(id);
    }

    public async Task<ExerciseType?> ReturnAsync(int id)
    {
        return await _exerciseTypeService.ReturnAsync(id);
    }

    public async Task<IReadOnlyList<ExerciseType>> ReturnAsync()
    {
        return await _exerciseTypeService.ReturnAsync();
    }

    public async Task<bool> UpdateAsync(UpdateExerciseTypeRequest request)
    {
        var exerciseType = new ExerciseType
        {
            Id = request.Id,
            Name = request.Name,
        };

        return await _exerciseTypeService.UpdateAsync(exerciseType);
    }

    #endregion
}
