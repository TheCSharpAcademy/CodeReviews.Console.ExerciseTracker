using ExerciseTrackerCarDioLogics.Data;
using ExerciseTrackerCarDioLogics.Models;

namespace ExerciseTrackerCarDioLogics.Repositories;

//implementation of the ExSession interface into Entity Framework
public class EFExSessionRepository : IExSessionRepository
{
    private readonly ExSessionContext _context;

    //constructor
    public EFExSessionRepository(ExSessionContext context)
    {
        _context = context;
    }

    public ExSession GetSessionById(int id)
    {
        return _context.ExSessions.Find(id);
    }

    public List<ExSession> GetAllSessions()
    {
        return _context.ExSessions.ToList();
    }

    public void AddSession(ExSession session)
    {
        _context.ExSessions.Add(session);
        _context.SaveChanges();
    }

    public void RemoveSession(int id)
    {
        var session = _context.ExSessions.Find(id);

        if (session != null)
        {
            _context.ExSessions.Remove(session);
            _context.SaveChanges();
        }
    }

    public void UpdateSession(ExSession session)
    {
        _context.ExSessions.Update(session);
        _context.SaveChanges();
    }
}
