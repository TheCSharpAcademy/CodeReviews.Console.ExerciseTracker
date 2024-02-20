using ExerciseTracker.Models;
using ExerciseTracker.Services;

namespace ExerciseTracker.Controllers;

public class RunningController(IExerciseService<Running> runningService)
{
    private readonly IExerciseService<Running> RunningServiceInstance = runningService;

    public bool TryConnection()
    {
        try
        {
            return RunningServiceInstance.TryConnection();
        }
        catch
        {
            throw;
        }
    }

    public List<Running>? GetAll()
    {
        return RunningServiceInstance.GetAll()?.ToList();
    }

    public Running? GetById()
    {
        var id = InputController.GetId();
        if(id is null)
            return null;
        return RunningServiceInstance.GetById((int)id);     
    }

    public bool Insert()
    {
        var exercise = InputController.GetRunningExercise();
        if (exercise is null)
            return false;
        return RunningServiceInstance.Insert(exercise);
    }

    public bool Delete() //Implement
    {
        throw new NotImplementedException();
    }

    public bool Update() //Implement
    {
        throw new NotImplementedException();
    }
}