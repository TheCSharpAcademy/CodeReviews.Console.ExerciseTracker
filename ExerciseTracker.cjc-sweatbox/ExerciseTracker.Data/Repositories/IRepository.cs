namespace ExerciseTracker.Data.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<int> AddAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
    IQueryable<TEntity> Get();
    Task<TEntity?> GetAsync(int id);
    Task<int> UpdateAsync(TEntity entity);
}
