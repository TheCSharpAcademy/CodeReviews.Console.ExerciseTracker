namespace ExerciseTracker.Forser.Repository
{
    public class ExerciseRepository : IExerciseReposoitory
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
        public void DeleteExercise(Exercise exercise)
        {
            _exerciseContext.Remove(exercise);
            _exerciseContext.SaveChanges();
        }
        public bool EditExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
        public bool GetExerciseById(int id, out Exercise? exercise)
        {
            exercise = null;
            Exercise? _ = _exerciseContext.Exercises.Find(id);
            if (_ == null)
            {
                return false;
            }
            else
            {
                exercise = _;
                return true;
            }
                
        }
        public IEnumerable<Exercise> GetExercises()
        {
            return _exerciseContext.Exercises;
        }
    }
}
