using System;

namespace Exercise_Tracker.EntityFramework.Lawang.Repository;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task SaveAsync();
}
