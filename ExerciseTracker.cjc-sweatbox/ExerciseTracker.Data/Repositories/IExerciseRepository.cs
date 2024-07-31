using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.Data.Repositories;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<IReadOnlyList<Exercise>> GetAsync();
}