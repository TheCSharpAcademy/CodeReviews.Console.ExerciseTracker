using Exercisetacker.DTOs;
using Exercisetacker.Entities;

namespace Exercisetacker.Services.Interfaces;

public interface IExerciseService
{
    Task<List<Excercise>?> GetAllExercises();
    Task<Excercise?> GetExerciseById(int id);
    Task<Excercise> AddExercise(ExerciseAddDto exercise);
    Task<int> UpdateExercise(Excercise exercise);
    Task<int> DeleteExercise(Excercise exercise);
}