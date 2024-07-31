using ExerciseTracker.Data.Entities;
using ExerciseTracker.Data.Repositories;

namespace ExerciseTracker.Services;

/// <summary>
/// Service to interface between the UI layer and the Data layer.
/// </summary>
public class ExerciseTypeService : IExerciseTypeService
{
    #region Fields

    private readonly IExerciseTypeRepository _exerciseTypeRepository;

    #endregion
    #region Constructors

    public ExerciseTypeService(IExerciseTypeRepository exerciseTypeRepository)
    {
        _exerciseTypeRepository = exerciseTypeRepository;
    }

    public async Task<bool> CreateAsync(ExerciseType exerciseType)
    {
        var created = await _exerciseTypeRepository.AddAsync(exerciseType);
        return created > 0;
    }

    #endregion
    #region Methods

    public async Task<bool> DeleteAsync(int id)
    {
        var exerciseType = await ReturnAsync(id);
        if (exerciseType is null)
        {
            return false;
        }

        var deleted = await _exerciseTypeRepository.DeleteAsync(exerciseType);
        return deleted > 0;
    }

    public async Task<ExerciseType?> ReturnAsync(int id)
    {
        return await _exerciseTypeRepository.GetAsync(id);
    }

    public async Task<IReadOnlyList<ExerciseType>> ReturnAsync()
    {
        return await _exerciseTypeRepository.GetAsync();
    }

    public async Task<bool> UpdateAsync(ExerciseType exerciseType)
    {
        var updated = await _exerciseTypeRepository.UpdateAsync(exerciseType);
        return updated > 0;
    }

    #endregion
}
