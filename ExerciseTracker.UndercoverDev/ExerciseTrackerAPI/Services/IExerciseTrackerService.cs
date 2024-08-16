using ExerciseTrackerAPI.Models;

namespace ExerciseTrackerAPI.Services;
public interface IExerciseTrackerService
{
    Task<List<Weight>> GetWeightsAsync();
    Task<Weight?> GetWeightByIdAsync(int id);
    Task<Weight> AddWeightAsync(Weight weight);
    Task<Weight?> UpdateWeightAsync(int id, Weight weight);
    Task<Weight?> DeleteWeightAsync(int id);

}