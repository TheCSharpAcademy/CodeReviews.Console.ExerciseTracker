namespace Exercise_Tracker.Challenge.Repositories;

public interface ICardioRepository 
{
    Task<Exercise?> CreateAsync(Exercise entity);
    Task<List<Exercise>?> GetAllAsync();
    Task<Exercise?> UpdateAsync(Exercise entity);
    Task<Exercise?> DeleteAsync(Exercise entity);
        
}
