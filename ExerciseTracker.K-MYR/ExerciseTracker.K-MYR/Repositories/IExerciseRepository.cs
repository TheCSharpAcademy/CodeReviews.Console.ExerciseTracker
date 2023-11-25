
namespace ExerciseTracker.K_MYR;

internal interface IExerciseRepository
{
    IQueryable<Exercise> GetAll();
    Task<Exercise> AddAsync(Exercise exerciseEntity);
    Task<Exercise> UpdateAsync(Exercise exerciseEntity);   
    Task DeleteAsync(Exercise exerciseEntity);
}