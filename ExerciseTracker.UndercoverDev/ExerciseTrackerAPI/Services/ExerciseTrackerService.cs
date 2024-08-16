using ExerciseTrackerAPI.Models;
using ExerciseTrackerAPI.Repositories;

namespace ExerciseTrackerAPI.Services;
public class ExerciseTrackerService : IExerciseTrackerService
{
    private readonly IRepository _repository;

    public ExerciseTrackerService(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Weight> AddWeightAsync(Weight weight)
    {
        return await _repository.CreateAsync(weight);
    }

    public async Task<Weight?> DeleteWeightAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<Weight?> GetWeightByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Weight>> GetWeightsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Weight?> UpdateWeightAsync(int id, Weight weight)
    {
        return await _repository.UpdateAsync(id, weight);
    }
}