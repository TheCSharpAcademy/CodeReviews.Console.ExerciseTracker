using Exercisetacker.DTOs;
using Exercisetacker.Entities;
using Exercisetacker.Repositories.Interfaces;
using Exercisetacker.Services.Interfaces;

namespace Exercisetacker.Services;

public class CardioService : ICardioService
{
    private readonly ICardioRepository _cardioRepository;

    public CardioService(ICardioRepository cardioRepository)
    {
        _cardioRepository = cardioRepository;
    }

    public async Task<Excercise> AddExercise(ExerciseAddDto exercise)
    {
        return await _cardioRepository.AddExercise(exercise.ToExercise());
    }

    public async Task<int> DeleteExercise(Excercise exercise) => await _cardioRepository.DeleteExercise(exercise);

    public async Task<List<Excercise>?> GetAllExercises() => await _cardioRepository.GetAllExercise();

    public async Task<Excercise?> GetExerciseById(int id) => await _cardioRepository.GetExerciseById(id);

    public async Task<int> UpdateExercise(Excercise exercise) => await _cardioRepository.UpdateExercise(exercise);
}