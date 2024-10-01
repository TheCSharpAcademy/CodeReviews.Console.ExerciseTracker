using ExerciseTracker.Models;

namespace ExerciseTracker.Services;
public interface IExerciseService
{
    public void CreateDatabase();
    public List<Exercise> GetAllExercises();
    public void AddExercise(Exercise exercise);
    public void DeleteExercise(Exercise exercise);
    public void UpdateExercise(Exercise exercise);
}
