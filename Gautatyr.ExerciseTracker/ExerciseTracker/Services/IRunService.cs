using ExerciseTracker.Models;

namespace ExerciseTracker.Services;

public interface IRunService
{
    Task<List<Run>> GetAllRunsAsync();
    Task<Run> GetRunByIdAsync(int id);
    Task<Run> AddRunAsync(Run newRun);
    Task<Run> UpdateRunAsync(Run newRun);
    Task<Run> DeleteRunAsync(Run run);
}
