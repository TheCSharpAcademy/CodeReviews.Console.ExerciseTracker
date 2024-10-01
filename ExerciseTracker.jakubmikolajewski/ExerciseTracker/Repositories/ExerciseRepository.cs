using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Models;

namespace ExerciseTracker.Data;
internal class ExerciseRepository : IExerciseRepository
{
    private readonly ExerciseTrackerContext _context;
    private readonly DbSet<Exercise> _dbSet;

    public ExerciseRepository(ExerciseTrackerContext context)
    {
        _context = context;
        _dbSet = _context.Set<Exercise>();
    }

    public void CreateDatabase()
    {
        _context.Database.Migrate();
    }

    public List<Exercise> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(Exercise exercise)
    {
        _dbSet.Add(exercise);
    }

    public void Update(Exercise exercise)
    {
        _dbSet.Update(exercise);
    }

    public void Delete(Exercise exercise)
    {
        _dbSet.Remove(exercise);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
