using ExerciseTrackerCarDioLogics.Models;
using ExerciseTrackerCarDioLogics.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace ExerciseTrackerCarDioLogics;

public class ExSessionService
{
    private readonly IExSessionRepository _ExSessionRepo;

    public ExSessionService(IExSessionRepository exSessionRepo)
    {
        _ExSessionRepo = exSessionRepo;
    }

    public ExSession GetSessionById(int id)
    {
        return _ExSessionRepo.GetSessionById(id);
    }

    public List<ExSession> GetAllSessions()
    {
        return _ExSessionRepo.GetAllSessions();
    }

    public void AddSession(ExSession session)
    {
        _ExSessionRepo.AddSession(session);
    }

    public void RemoveSession(int id)//Im still deciding if i want to use an int or ExSession type
    {
        _ExSessionRepo.RemoveSession(id);
    }

    public void UpdateSession(ExSession session)
    {
        _ExSessionRepo.UpdateSession(session);
    }
}
