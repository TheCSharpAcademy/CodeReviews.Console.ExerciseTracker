using ExerciseTracker.ukpagrace.Interfaces;

namespace ExerciseTracker.ukpagrace.Services
{
    public class ExerciseService<T> : IExerciseService<T>
    {
        private readonly IExerciseRepository<T> _exerciseRepository;

        public ExerciseService(IExerciseRepository<T> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }   

        public void AddExercise( T exercise)
        {
           _exerciseRepository.AddExercise(exercise);
        }

        public IEnumerable<T> GetExercises()
        {
            return _exerciseRepository.GetExercises();
        }


        public T GetExercise(int id)
        {
            return _exerciseRepository.GetExerciseById(id);
        }


        public void UpdateExercise(T exercise)
        {
            _exerciseRepository.UpdateExercise(exercise);
        }

        public void DeleteExercise(T exercise)
        {
            _exerciseRepository.DeleteExercise(exercise);
        }
    }
}
