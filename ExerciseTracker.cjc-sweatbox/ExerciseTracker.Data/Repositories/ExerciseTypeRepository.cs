using ExerciseTracker.Data.Contexts;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data.Repositories;

/// <summary>
/// Concrete implementation for the ExerciseType repository.
/// </summary>
public class ExerciseTypeRepository : EntityFrameworkRepository<ExerciseType>, IExerciseTypeRepository
{
    #region Constructors

    public ExerciseTypeRepository(EntityFrameworkDbContext dbContext) : base(dbContext) { }

    #endregion
    #region Methods

    public async Task<IReadOnlyList<ExerciseType>> GetAsync()
    {
        return await Get().ToListAsync();
    }

    #endregion
}
