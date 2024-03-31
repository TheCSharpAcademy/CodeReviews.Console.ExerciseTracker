using ExerciseTracker.Models;
using ExerciseTracker.Repository;
using static ExerciseTracker.Models.Enums;

namespace ExerciseTracker.Service;

public class ExerciseService(IRepository repository) : IService
{
    private readonly IRepository _repository = repository;

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
    {
        return await _repository.GetAllExercisesAsync();
    }

    public async Task<Exercise?> GetExerciseByIdAsync(int id)
    {
        return await _repository.GetExerciseByIdAsync(id);
    }

    public async Task AddExerciseAsync(DateTime dateStart, DateTime dateEnd, string comments, ExerciseType exerciseType)
    {
        Exercise exercise = new()
        {
            DateStart = dateStart,
            DateEnd = dateEnd,
            Comments = comments,
            Type = exerciseType
        };

        await _repository.AddExerciseAsync(exercise);
    }

    public async Task UpdateExerciseAsync(int id, DateTime dateStart, DateTime dateEnd, string comments, ExerciseType exerciseType)
    {
        Exercise exercise = new()
        {
            Id = id,
            DateStart = dateStart,
            DateEnd = dateEnd,
            Comments = comments,
            Type = exerciseType
        };

        try
        {
            await _repository.UpdateExerciseAsync(exercise);
        }
        catch (ApplicationException)
        {
            throw;
        }
    }

    public async Task DeleteExerciseByIdAsync(int id)
    {
        try
        {
            await _repository.DeleteExerciseByIdAsync(id);
        }
        catch (ApplicationException)
        {
            throw;
        }
    }
}