using ExerciseTracker.samggannon.Data.Models;
using ExerciseTracker.samggannon.Data.Repositories;
using ExerciseTracker.samggannon.UserInterface;

namespace ExerciseTracker.samggannon.Services;

public class ExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    internal ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    internal void DeleteSessionById()
    {
        throw new NotImplementedException();
    }

    internal void EditSession()
    {
        throw new NotImplementedException();
    }

    internal void GetAllSessions()
    {
        List<Exercise> exercises = _exerciseRepository.GetAllSessions();
        Visualization.ShowTable(exercises);

        Console.WriteLine("Press [enter] to continue");
        Console.ReadLine();
    }

    internal void InsertSession()
    {
        Exercise exerciseSession = UserInput.GetSessionDetails();
        _exerciseRepository.Add(exerciseSession);
    }
}
