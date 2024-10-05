using System;
using Exercise_Tracker.EntityFramework.Lawang.Data;
using Exercise_Tracker.EntityFramework.Lawang.Models;

namespace Exercise_Tracker.EntityFramework.Lawang.Repository;

public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
{
    private ApplicationDbContext _db;
    public ExerciseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _db = dbContext;
    }

    public async Task<Exercise> UpdateAsync(Exercise entity)
    {
        _db.Exercises.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}
