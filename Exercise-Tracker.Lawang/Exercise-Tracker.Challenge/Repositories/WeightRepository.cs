using System;
using System.Data.Common;
using Exercise_Tracker.Challenge.Data;
using Microsoft.EntityFrameworkCore;

namespace Exercise_Tracker.Challenge.Repositories;

public class WeightRepository : IWeightRepository
{
    private readonly WeightDbContext _db;
    private readonly DbSet<Exercise> _dbSet;
    public WeightRepository(WeightDbContext db)
    {
        _db = db;
        _dbSet = _db.Set<Exercise>();
    }
    public async Task<Exercise?> CreateAsync(Exercise entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();

            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }

        return null;
    }

    public async Task<Exercise?> DeleteAsync(Exercise entity)
    {
        try
        {
             _dbSet.Remove(entity);
             await _db.SaveChangesAsync();
             return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        return null;
    }

    public async Task<List<Exercise>?> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }

        return null;
    }

    public async Task<Exercise?> UpdateAsync(Exercise entity)
    {
        try
        {
            _dbSet.Update(entity);
            await SaveAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }

        return null;
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
