using ExerciseTracker.Models;

namespace ExerciseTracker.Data;
public interface IExerciseRepository
{
    void CreateDatabase();
    List<Exercise> GetAll();
    void Add(Exercise exercise);
    void Update(Exercise exercise);
    void Delete(Exercise exercise);
    void Save();
}
