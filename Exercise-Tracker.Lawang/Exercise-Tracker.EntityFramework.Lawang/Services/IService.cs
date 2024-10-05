using System;

namespace Exercise_Tracker.EntityFramework.Lawang.Services;

public interface IService<T> where T : class
{
    Task<List<T>?> GetAllAsync();
    Task<T?> CreateAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<T?> DeleteAsync(T entity);
}
