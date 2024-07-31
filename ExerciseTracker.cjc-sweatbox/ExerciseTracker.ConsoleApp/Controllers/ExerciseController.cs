using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.Services;

namespace ExerciseTracker.ConsoleApp.Controllers;

/// <summary>
/// Controller for interfacing to the required application services.
/// </summary>
internal class ExerciseController : IExerciseController
{
    #region Fields

    private readonly IExerciseService _exerciseService;
    private readonly IExerciseTypeService _exerciseTypeService;

    #endregion
    #region Constructors

    public ExerciseController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService)
    {
        _exerciseService = exerciseService;
        _exerciseTypeService = exerciseTypeService;
    }

    #endregion
    #region Methods

    public async Task<bool> CreateAsync(CreateExerciseRequest request)
    {
        var exercise = new Exercise
        {
            DateStart = request.DateStart,
            DateEnd = request.DateEnd,
            Duration = request.DateEnd - request.DateStart,
            Comments = request.Comments,
            ExerciseType = request.ExerciseType,
        };

        return await _exerciseService.CreateAsync(exercise);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _exerciseService.DeleteAsync(id);
    }

    public async Task<ExerciseDto?> ReturnAsync(int id)
    {
        var entity = await _exerciseService.ReturnAsync(id);
        return entity is null ? null : ExerciseDto.MapFrom(entity);
    }

    public async Task<IReadOnlyList<ExerciseDto>> ReturnAsync()
    {
        var entities = await _exerciseService.ReturnAsync();
        return entities.Select(ExerciseDto.MapFrom).ToList();
    }

    public async Task<bool> UpdateAsync(UpdateExerciseRequest request)
    {
        var exercise = await _exerciseService.ReturnAsync(request.Id);
        if (exercise is null)
        {
            return false;
        }

        exercise.DateStart = request.DateStart;
        exercise.DateEnd = request.DateEnd;
        exercise.Duration = request.DateEnd - request.DateStart;
        exercise.Comments = request.Comments;
        exercise.ExerciseType = request.ExerciseType;

        return await _exerciseService.UpdateAsync(exercise);
    }

    #endregion
}
