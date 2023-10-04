namespace ExerciseTracker.Forser.Repository
{
    internal class ExerciseRepository : IExerciseReposoitory
    {
        private readonly ExerciseContext _exerciseContext;
        public ExerciseRepository(ExerciseContext context)
        {
            _exerciseContext = context;
        }
        public bool AddExercise(Exercise exercise)
        {
            _exerciseContext.Add(exercise);
            int result = _exerciseContext.SaveChanges();

            if (result > 0)
            {
                return true;
            }
            else { return false; }
        }
        public bool DeleteExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
        public bool EditExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
        public bool GetExerciseById(int id, out Exercise? exercise)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Exercise> GetExercises()
        {
            return _exerciseContext.Exercises;
        }
    }
}
