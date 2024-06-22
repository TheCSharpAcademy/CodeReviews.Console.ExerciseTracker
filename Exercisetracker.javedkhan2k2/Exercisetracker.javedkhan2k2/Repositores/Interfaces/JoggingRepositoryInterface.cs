using Exercisetacker.DTOs;
using Exercisetacker.Entities;

namespace Exercisetacker.Repositories.Interfaces;

public interface JoggingRepositoryInterface
{
    Task<List<Jogging>?> GetAllJogging();
    Task<Jogging> GetJoggingById(int id);
    Task<Jogging> AddJogging(JoggingAddDto jogging);
    Task UpdateJogging(Jogging jogging);
    Task DeleteJoggingById(int id);
}