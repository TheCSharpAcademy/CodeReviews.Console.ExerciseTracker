namespace ExerciseTracker.ukpagrace.Interfaces
{
    public interface IExerciseService<T>
    {
        public void AddExercise(T exercise);
        public IEnumerable<T> GetExercises();

        public T GetExercise(int id);
    }
}
