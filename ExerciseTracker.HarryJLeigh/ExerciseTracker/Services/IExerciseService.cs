namespace ExerciseTracker.Services;

public interface IExerciseService<T>  where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAllExercises();
    void AddExercise(T entity);
    void UpdateExercise(T entity);
    void DeleteExercise(int id);
}