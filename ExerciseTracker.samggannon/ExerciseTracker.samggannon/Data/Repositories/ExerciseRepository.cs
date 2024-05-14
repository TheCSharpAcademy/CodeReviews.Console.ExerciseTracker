using ExerciseTracker.samggannon.Data.Models;

namespace ExerciseTracker.samggannon.Data.Repositories;

internal class ExerciseRepository : IExerciseRepository
{
    public void Add(Exercise entity)
    {
        using var _dbContext = new ExerciseContext();
        _dbContext.ExerciseSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public List<Exercise> GetAllSessions()
    {
        using var _dbContext = new ExerciseContext();
        return _dbContext.ExerciseSet.ToList();
    }

    public void Delete(Exercise entity)
    {
        throw new NotImplementedException();
    }

    public Exercise GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Exercise entity)
    {
        throw new NotImplementedException();
    }
}
