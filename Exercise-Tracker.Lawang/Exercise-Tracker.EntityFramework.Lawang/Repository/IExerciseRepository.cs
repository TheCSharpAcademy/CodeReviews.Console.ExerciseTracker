using Exercise_Tracker.EntityFramework.Lawang.Models;

namespace Exercise_Tracker.EntityFramework.Lawang.Repository;

public interface IExerciseRepository : IRepository<Exercise>
{
    Task<Exercise> UpdateAsync(Exercise entity);
}
