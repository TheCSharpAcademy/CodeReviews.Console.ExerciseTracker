using ExerciseTracker.samggannon.Data.Models;
using ExerciseTracker.samggannon.Data.Repositories;
using ExerciseTracker.samggannon.UserInterface;
using ExerciseTracker.samggannon.Validation;

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
        GetAllSessions();

        int sessionIdToDelete = UserInput.GetIdInput();
        var exerciseSession = _exerciseRepository.GetSessionById(sessionIdToDelete);

        if (exerciseSession == null)
        {
            Console.WriteLine($"No session found with the id: {sessionIdToDelete}. Press [enter] to continue.");
            Console.ReadLine();
            return;
        }

        _exerciseRepository.Delete(exerciseSession);
    }

    internal void EditSession()
    {
        GetAllSessions();

        int sessionId = UserInput.GetIdInput();
        var exerciseSession = _exerciseRepository.GetSessionById(sessionId);

        if (exerciseSession == null)
        {
            Console.WriteLine($"No session found with the id: {sessionId}. Press [enter] to continue.");
            Console.ReadLine();
            return;
        }

        var updatedSession = MainMenu.UpdateMenu(exerciseSession);

        bool editTimeWasvalid = InputValidation.ValidateTime(updatedSession.DateStart, updatedSession.DateEnd);

        if(editTimeWasvalid)
        {
            updatedSession.Id = sessionId;
            _exerciseRepository.Update(updatedSession);
        }
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
