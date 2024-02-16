using ExerciseTracker.Models;
using ExerciseTracker.Repositories;

namespace ExerciseTracker.Services;

public class RunningService(RunningRepository runningRepository)
{
    private readonly RunningRepository RunningRepositoryInstance = runningRepository;

    public IEnumerable<Running>? GetAll()
    {
        return RunningRepositoryInstance.GetAll();
    }

    public Running? GetById(int id)
    {
        return RunningRepositoryInstance.GetById(id);
    }

    public bool Insert(Running modelToInsert)
    {
        return RunningRepositoryInstance.Insert(modelToInsert);
    }

    public bool Update(Running modelToUpdate)
    {
        return RunningRepositoryInstance.Update(modelToUpdate);
    }

    public bool Delete(Running modelToDelete)
    {
        return RunningRepositoryInstance.Delete(modelToDelete);
    }
}