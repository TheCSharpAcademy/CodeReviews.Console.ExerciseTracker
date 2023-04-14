using ExerciseTracker.Models;
using ExerciseTracker.Repositories;

namespace ExerciseTracker.Services;

public class RunService : IRunService
{
    private readonly IRunRepository _runRepository;

    public RunService(IRunRepository runRepository)
    {
        _runRepository = runRepository;
    }

    public async Task<List<Run>> GetAllRunsAsync()
    {
        return await _runRepository.GetAllRunsAsync();
    }

    public async Task<Run> GetRunByIdAsync(int id)
    {
        return await _runRepository.GetRunByIdAsync(id);
    }

    public async Task<Run> AddRunAsync(Run newRun)
    {
        return await _runRepository.AddAsync(newRun);
    }

    public async Task<Run> UpdateRunAsync(Run newRun)
    {
        return await _runRepository.UpdateRunAsync(newRun);
    }

    public async Task<Run> DeleteRunAsync(Run run)
    {
        return await _runRepository.DeleteRunAsync(run);
    }
}
