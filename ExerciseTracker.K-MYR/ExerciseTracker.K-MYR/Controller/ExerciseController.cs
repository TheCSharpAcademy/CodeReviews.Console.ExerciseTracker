namespace ExerciseTracker.K_MYR;

internal class ExerciseController : IExerciseController
{
    IExerciseService _ExerciseService;
    public ExerciseController(IExerciseService exerciseService)
    {
        _ExerciseService = exerciseService;
    }

    public IQueryable<Exercise> GetAll()
    {
        return _ExerciseService.GetAll();
    }

    public Task<Exercise> AddAsync(Exercise exerciseEntity)
    {
        return _ExerciseService.AddAsync(exerciseEntity);
    }

    public Task<Exercise> UpdateAsync(Exercise exerciseEntity)
    {
        return _ExerciseService.UpdateAsync(exerciseEntity);
    }
    public Task DeleteAsync(Exercise exerciseEntity)
    {
        return _ExerciseService.DeleteAsync(exerciseEntity);
    }
}
