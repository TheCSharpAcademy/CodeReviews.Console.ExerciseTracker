using ExerciseTracker.kalsson.DataAccess;
using ExerciseTracker.kalsson.Models;

namespace ExerciseTracker.kalsson.Services;

public class ExerciseService
{
    private readonly IExerciseRepository _repository;

    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ExerciseModel>> GetAllExercisesAsync()
    {
        return _repository.GetAllExercisesAsync();
    }

    public Task<ExerciseModel> GetExerciseByIdAsync(int id)
    {
        return _repository.GetExerciseByIdAsync(id);
    }

    public Task AddExerciseAsync(ExerciseModel exercise)
    {
        return _repository.AddExerciseAsync(exercise);
    }

    public Task UpdateExerciseAsync(ExerciseModel exercise)
    {
        return _repository.UpdateExerciseAsync(exercise);
    }

    public Task DeleteExerciseAsync(int id)
    {
        return _repository.DeleteExerciseAsync(id);
    }
}