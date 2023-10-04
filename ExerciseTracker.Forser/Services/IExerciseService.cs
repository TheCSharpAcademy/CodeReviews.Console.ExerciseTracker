namespace ExerciseTracker.Forser.Services
{
    internal interface IExerciseService
    {
        bool AddExercise(DateTime start, DateTime end, string? comments);
        void DeleteExercise(int id);
        void EditExercise(int id, DateTime start, DateTime end, string? comments);
        void DisplayExercises();
    }
}