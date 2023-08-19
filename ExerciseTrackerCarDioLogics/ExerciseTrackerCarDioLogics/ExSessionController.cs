using ExerciseTrackerCarDioLogics.Models;

namespace ExerciseTrackerCarDioLogics;

public class ExSessionController
{
    private readonly ExSessionService _exSessionService;

    public ExSessionController(ExSessionService exSessionService)
    {
        _exSessionService = exSessionService;
    }

    public void AddExSession(DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comment)
    {
        ExSession newSession = new ExSession
        {
            DateStart = dateStart,
            DateEnd = dateEnd,
            Duration = duration,
            Comment = comment
        };

        _exSessionService.AddSession(newSession);
    }

    public ExSession GetSessionById(int id)
    {
        return _exSessionService.GetSessionById(id);
    }

    public List<ExSession> GetAllSessions()
    {
        return _exSessionService.GetAllSessions();
    }

    /*public void UpdateExSession(int id, DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comment)
    {
        ExSession updatedSession = new ExSession
        {
            Id = id,
            DateStart = dateStart,
            DateEnd = dateEnd,
            Duration = duration,
            Comment = comment
        };

        _exSessionService.UpdateSession(updatedSession);
    }*/

    public void UpdateExSession(int id, DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comment, ExSession session)
    {

        session.Id = id;
        session.DateStart = dateStart;
        session.DateEnd = dateEnd;
        session.Duration = duration;
        session.Comment = comment;

        _exSessionService.UpdateSession(session);
    }

    public void RemoveSession(int id)
    {
        _exSessionService.RemoveSession(id);
    }
}
