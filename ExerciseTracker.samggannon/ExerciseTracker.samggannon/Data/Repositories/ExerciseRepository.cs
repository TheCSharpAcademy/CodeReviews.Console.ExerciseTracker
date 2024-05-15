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

    public Exercise GetSessionById(int sessionId)
    {
        using var _dbContext = new ExerciseContext();
        return _dbContext.ExerciseSet.Find(sessionId);
    }

    public void Update(Exercise entity)
    {
        using var _dbContext = new ExerciseContext();
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(Exercise entity)
    {
        using var _dbContext = new ExerciseContext();
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
        
    }
}
