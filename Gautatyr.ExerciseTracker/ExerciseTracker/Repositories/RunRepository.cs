using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

public class RunRepository : Repository<Run>, IRunRepository
{
    public RunRepository(ExerciseTrackerContext exerciseTrackerContext) : base(exerciseTrackerContext)
    {
    }

    public Task<Run> GetRunByIdAsync(int id)
    {
        return GetAll().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Run>> GetAllRunsAsync()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Run> UpdateRunAsync(Run run)
    {
        return await UpdateAsync(run);
    }

    public async Task<Run> DeleteRunAsync(Run run)
    {
        return await DeleteAsync(run);
    }
}
