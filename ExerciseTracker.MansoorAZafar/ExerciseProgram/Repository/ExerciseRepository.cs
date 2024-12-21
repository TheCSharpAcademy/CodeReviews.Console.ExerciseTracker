using Microsoft.EntityFrameworkCore;
// Access the Database
using ExerciseProgram.Repository;
using ExerciseProgram.Model;

internal class Repository<T> : IRepository<T> where T : class
{
    private readonly ExerciseContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ExerciseContext context) // Use ExerciseContext instead of DbContext
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public T? GetById(int id) 
        => _dbSet.Find(id);

    public List<T> GetAll()
        => _dbSet.ToList();
    
    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity) 
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}
