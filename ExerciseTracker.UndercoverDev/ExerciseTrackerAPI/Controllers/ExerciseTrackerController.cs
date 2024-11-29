using ExerciseTrackerAPI.Models;
using ExerciseTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTrackerAPI.Controllers;

public class ExerciseTrackerController : ControllerBase, IExerciseTrackerController
{
    private readonly IExerciseTrackerService _service;

    public ExerciseTrackerController(IExerciseTrackerService service)
    {
        _service = service;
    }

    public async Task<Weight> AddWeight(Weight weight)
    {
        return await _service.AddWeightAsync(weight);
    }

    public Task<Weight?> DeleteWeight(int id)
    {
        return _service.DeleteWeightAsync(id);
    }

    public Task<Weight?> GetWeightById(int id)
    {
        return _service.GetWeightByIdAsync(id);
    }

    public Task<List<Weight>> GetWeights()
    {
        return _service.GetWeightsAsync();
    }

    public Task<Weight?> UpdateWeight(int id, Weight weight)
    {
        return _service.UpdateWeightAsync(id, weight);
    }
}