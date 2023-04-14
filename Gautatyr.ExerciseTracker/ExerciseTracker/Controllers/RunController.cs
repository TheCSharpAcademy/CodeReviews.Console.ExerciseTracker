using ExerciseTracker.Services;
using ExerciseTracker.Models;

namespace ExerciseTracker.Controllers;

public class RunController : IRunController
{
    private readonly IRunService _runService;

    public RunController(IRunService runService)
    {
        _runService = runService;
    }

    public async Task<Run> GetRunByIdAsync(int id)
    {
        return await _runService.GetRunByIdAsync(id);
    }

    public async Task<Run> CreateRunAsync(Run run)
    {
        return await _runService.AddRunAsync(run);
    }

    public async Task<List<Run>> GetAllRunsAsync()
    {
        return await _runService.GetAllRunsAsync();
    }

    public async Task<Run> UpdateRunAsync(Run run)
    {
        return await _runService.UpdateRunAsync(run);
    }

    public async Task<Run> DeleteRunAsync(Run run)
    {
        return await _runService.DeleteRunAsync(run);
    }
}
