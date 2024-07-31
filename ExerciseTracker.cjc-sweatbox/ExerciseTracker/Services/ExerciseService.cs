using ExerciseTracker.Data.Entities;
using ExerciseTracker.Data.Repositories;

namespace ExerciseTracker.Services;

/// <summary>
/// Service to interface between the UI layer and the Data layer.
/// </summary>
public class ExerciseService : IExerciseService
{
    #region Fields

    private readonly IExerciseRepository _exerciseRepository;

    #endregion
    #region Constructors

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    #endregion
    #region Methods

    public async Task<bool> CreateAsync(Exercise exercise)
    {
        var created = await _exerciseRepository.AddAsync(exercise);
        return created > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var exercise = await ReturnAsync(id);
        if (exercise is null)
        {
            return false;
        }

        var deleted = await _exerciseRepository.DeleteAsync(exercise);
        return deleted > 0;
    }

    public async Task<Exercise?> ReturnAsync(int id)
    {
        return await _exerciseRepository.GetAsync(id);
    }

    public async Task<IReadOnlyList<Exercise>> ReturnAsync()
    {
        return await _exerciseRepository.GetAsync();
    }

    public async Task<bool> UpdateAsync(Exercise exercise)
    {
        var updated = await _exerciseRepository.UpdateAsync(exercise);
        return updated > 0;
    }

    #endregion
}
