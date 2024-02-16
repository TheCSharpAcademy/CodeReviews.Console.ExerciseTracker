using ExerciseTracker.Models;
using ExerciseTracker.Services;

namespace ExerciseTracker.Controllers;

public class RunningController(RunningService runningService)
{
    private readonly RunningService RunningServiceInstance = runningService;
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