using System;
using Exercise_Tracker.EntityFramework.Lawang.Data;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Tracker.EntityFramework.Lawang.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private ApplicationDbContext _dbContext { get; set; }
    private DbSet<T> _dbSet;
    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await SaveAsync();
        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
