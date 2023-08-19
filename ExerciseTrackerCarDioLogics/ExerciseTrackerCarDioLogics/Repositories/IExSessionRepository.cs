using ExerciseTrackerCarDioLogics.Models;

namespace ExerciseTrackerCarDioLogics.Repositories;

public interface IExSessionRepository
{
    ExSession GetSessionById(int id);
    List<ExSession> GetAllSessions();
    void AddSession(ExSession session);
    void RemoveSession(int id);
    void UpdateSession(ExSession session);
}
