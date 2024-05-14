using ExerciseTracker.samggannon.Data.Repositories;
using ExerciseTracker.samggannon.Services;

namespace ExerciseTracker.samggannon.Controllers;

public class ExerciseController
{
    private readonly ExerciseService _exerciseService;

    public ExerciseController(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public void InsertSession()
    {
        _exerciseService.InsertSession();
    }

    public void GetAllSessions()
    {
        _exerciseService.GetAllSessions();
    }

    public void DeleteSessionById()
    {
        throw new NotImplementedException();
    }

    public void EditSession()
    {
        throw new NotImplementedException();
    }
}
