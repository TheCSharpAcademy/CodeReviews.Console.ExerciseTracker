using System;
namespace ExerciseTracker.ukpagrace.Interfaces
{
    public interface IExerciseRepository<T>
    {
        T GetExerciseById(int id);

        IEnumerable<T> GetExercises();

        void AddExercise(T entity);

        void UpdateExercise(T entity);

        void DeleteExercise(T entity);
    }
}
