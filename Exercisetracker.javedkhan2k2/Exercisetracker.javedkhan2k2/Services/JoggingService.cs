using Exercisetacker.DTOs;
using Exercisetacker.Entities;
using Exercisetacker.Repositories.Interfaces;
using Exercisetacker.Services.Interfaces;

namespace Exercisetacker.Services;

public class JoggingService : IJoggingService
{
    private readonly IJoggingRepository _joggingRepository;

    public JoggingService(IJoggingRepository joggingRepository)
    {
        _joggingRepository = joggingRepository;
    }

    public async Task<Excercise> AddExercise(ExerciseAddDto exercise)
    {
        return await _joggingRepository.AddExercise(exercise.ToExercise());
    }

    public async Task<int> DeleteExercise(Excercise exercise) => await _joggingRepository.DeleteExercise(exercise);

    public async Task<List<Excercise>?> GetAllExercises() => await _joggingRepository.GetAllExercise();

    public async Task<Excercise?> GetExerciseById(int id) => await _joggingRepository.GetExerciseById(id);

    public async Task<int> UpdateExercise(Excercise exercise) => await _joggingRepository.UpdateExercise(exercise);
}