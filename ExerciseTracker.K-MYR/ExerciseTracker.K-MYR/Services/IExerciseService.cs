namespace ExerciseTracker.K_MYR;

internal interface IExerciseService
{
    internal IQueryable<Exercise> GetAll();   
    internal Task<Exercise> AddAsync(Exercise exerciseEntity);
    internal Task<Exercise> UpdateAsync(Exercise exerciseEntity);
    internal Task DeleteAsync(Exercise exerciseEntity);
}