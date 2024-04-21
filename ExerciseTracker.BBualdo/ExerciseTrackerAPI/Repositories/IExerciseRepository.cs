using ExerciseTrackerAPI.Models;

namespace ExerciseTrackerAPI.Repositories;

public interface IExerciseRepository
{
  Task<IEnumerable<Exercise>> GetAllExercises();
  Task<Exercise?> GetExerciseById(int id);
  Task AddExercise(Exercise exercise);
  Task UpdateExercise(int id, Exercise exercise);
  Task DeleteExercise(int id);
}