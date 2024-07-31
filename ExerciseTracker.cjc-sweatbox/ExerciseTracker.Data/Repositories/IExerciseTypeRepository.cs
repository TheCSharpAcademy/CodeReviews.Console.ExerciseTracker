using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.Data.Repositories;

public interface IExerciseTypeRepository : IRepository<ExerciseType>
{
    Task<IReadOnlyList<ExerciseType>> GetAsync();
}