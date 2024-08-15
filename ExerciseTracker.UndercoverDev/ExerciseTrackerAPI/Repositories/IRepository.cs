using ExerciseTrackerAPI.Models;

namespace ExerciseTrackerAPI.Repositories;
public interface IRepository
{
    Task<List<Weight>> GetAllAsync();
    Task<Weight?> GetByIdAsync(int id);
    Task<Weight> CreateAsync(Weight weight);
    Task<Weight?> UpdateAsync(int id, Weight weight);
    Task<Weight?> DeleteAsync(int id);
}