using Exercisetacker.DTOs;
using Exercisetacker.Entities;

namespace Exercisetacker.Repositories.Interfaces;

public interface IExerciseRepository
{
    Task<List<Excercise>?> GetAllExercise();
    Task<Excercise> GetExerciseById(int id);
    Task<Excercise> AddExercise(Excercise exercise);
    Task<int> UpdateExercise(Excercise exercise);
    Task<int> DeleteExercise(Excercise exercise);
}