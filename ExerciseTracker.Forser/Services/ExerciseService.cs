namespace ExerciseTracker.Forser.Services
{
    internal class ExerciseService : IExerciseService
    {
        private readonly IExerciseReposoitory _exerciseReposoitory;
        public ExerciseService(IExerciseReposoitory exerciseReposoitory)
        {
            _exerciseReposoitory = exerciseReposoitory;
        }
        public bool AddExercise(DateTime start, DateTime end, string? comments)
        {
            Exercise newExercise = new()
            {
                DateStart = start,
                DateEnd = end,
                Duration = end - start,
                Comments = comments
            };
            return _exerciseReposoitory.AddExercise(newExercise);   
        }

        public void DeleteExercise(int id)
        {
            throw new NotImplementedException();
        }

        public void DisplayExercises()
        {
            List<Exercise> exercises = _exerciseReposoitory.GetExercises().ToList();
            UserInterface.DisplayExerciseTable(exercises);
        }

        public void EditExercise(int id, DateTime start, DateTime end, string? comments)
        {
            throw new NotImplementedException();
        }
    }
}