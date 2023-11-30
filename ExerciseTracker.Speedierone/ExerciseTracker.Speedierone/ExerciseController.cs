using ExerciseTracker.Speedierone.Model;
using ExerciseTracker.Speedierone.Repository;

namespace ExerciseTracker.Speedierone
{
    public class ExerciseController
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public IEnumerable<Exercises> GetAll()
        {
            var allExercises = _exerciseRepository.GetAll();
            return allExercises;
        }
        
        public void AddExercise(Exercises exercises)
        {
            _exerciseRepository.Add(exercises);
            _exerciseRepository.Save();
        }
        public void UpdateExercise(Exercises exercises)
        {
            _exerciseRepository.Update(exercises);
            _exerciseRepository.Save();
        }
        public void DeleteExercise(int id)
        {
            _exerciseRepository.Delete(id);
            _exerciseRepository.Save();

        }
    }
}
