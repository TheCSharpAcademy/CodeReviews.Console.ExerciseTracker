using Exercisetacker.Data;
using Exercisetacker.DTOs;
using Exercisetacker.Entities;
using Exercisetacker.Repositories.Interfaces;

namespace Exercisetacker.Repositories;

public class JoggingRepository : JoggingRepositoryInterface
{
    private readonly JoggingDbContext _context;

    public JoggingRepository(JoggingDbContext context)
    {
        _context = context;
    }

    public Task<Jogging> AddJogging(JoggingAddDto jogging)
    {
        throw new NotImplementedException();
    }

    public Task DeleteJoggingById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Jogging>?> GetAllJogging()
    {
        throw new NotImplementedException();
    }

    public Task<Jogging> GetJoggingById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateJogging(Jogging jogging)
    {
        throw new NotImplementedException();
    }
}