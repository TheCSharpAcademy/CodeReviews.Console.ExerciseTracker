using ExerciseTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.API.Repository;

public class ExerciseRepository<T>(ApplicationDbContext _dbContext) : IGenericRepository<T> where T : notnull, BaseEntity
{
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
