namespace ExerciseTracker.K_MYR;

internal class ExerciseService : IExerciseService
{
    private IExerciseRepository _ExerciseRepository;
    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _ExerciseRepository = exerciseRepository;
    }
    public IQueryable<Exercise> GetAll()
    {
        return _ExerciseRepository.GetAll();
    }

    public Task<Exercise> AddAsync(Exercise exerciseEntity)
    {
        return _ExerciseRepository.AddAsync(exerciseEntity);
    }

    public Task<Exercise> UpdateAsync(Exercise exerciseEntity)
    {
        return _ExerciseRepository.UpdateAsync(exerciseEntity);
    }
    public Task DeleteAsync(Exercise exerciseEntity)
    {
        return _ExerciseRepository.DeleteAsync(exerciseEntity);
    }
}
