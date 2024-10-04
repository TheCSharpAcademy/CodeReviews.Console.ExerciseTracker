namespace ExerciseTracker;

public interface IExerciseController
{
    public IEnumerable<Exercise> GetExercises();
    public Exercise? GetExerciseById(int id);
    public bool CreateExercise(Exercise exercise);
    public bool UpdateExercise(Exercise exercise);
    public bool DeleteExercise(Exercise exercise);
}