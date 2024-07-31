using ExerciseTracker.Data.Contexts;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data.Repositories;

/// <summary>
/// Concrete implementation for the Exercise repository.
/// </summary>
public class ExerciseRepository : EntityFrameworkRepository<Exercise>, IExerciseRepository
{
    #region Constructors

    public ExerciseRepository(EntityFrameworkDbContext dbContext) : base(dbContext) { }

    #endregion
    #region Methods

    public async Task<IReadOnlyList<Exercise>> GetAsync()
    {
        return await Get()
            .Include(x => x.ExerciseType)
            .OrderBy(o => o.DateStart)
            .ThenBy(o => o.DateEnd)
            .ToListAsync();
    }

    #endregion
}
