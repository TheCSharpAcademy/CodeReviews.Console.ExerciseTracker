using ExerciseTracker.API.Models;

namespace ExerciseTracker.API.Repository;

public interface IGenericRepository<T> where T : notnull, BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
}
