namespace ExerciseTracker.tonyissa.Repositories;

interface IExerciseRepository<T>
{
    T GetSessionById(int id);
    IEnumerable<T> GetAllSessions();
    void AddSession(T session);
    void DeleteSession(T session);
    void UpdateSession(T session);
}