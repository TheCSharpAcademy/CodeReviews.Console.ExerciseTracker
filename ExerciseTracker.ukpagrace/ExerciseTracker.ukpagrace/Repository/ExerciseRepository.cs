using ExerciseTracker.ukpagrace.Interfaces;
using ExerciseTracker.ukpagrace.Model;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.ukpagrace.Repository
{
    public class ExerciseRepository<T>: IExerciseRepository<T> where T : class
    {
        private readonly ExerciseContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public ExerciseRepository(ExerciseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }

        public T GetExerciseById(int id)
        {
            return _dbSet.Find(id) ?? throw new KeyNotFoundException($"No exercise found with ID {id}"); ;
        }

        public IEnumerable<T> GetExercises() 
        { 
            return _dbSet.ToList();
        }

        public void AddExercise(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateExercise(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteExercise(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
