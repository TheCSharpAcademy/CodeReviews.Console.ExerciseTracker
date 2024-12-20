using ExerciseTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Repository;

public class WeightRepository<T>(AppDbContext context) : IRepository<T> where T : class
{
    private readonly DbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public T GetById(int id) => _dbSet.Find(id);

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        SaveChanges();
    }

    public void SaveChanges() => _context.SaveChanges();
}