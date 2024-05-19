using ExerciseTracker.Cactus.Data.Interfaces;
using ExerciseTracker.Cactus.Model;

namespace ExerciseTracker.Cactus.Service
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAllAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _exerciseRepository.GetByIdAsync(id);
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.AddAsync(exercise);
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.UpdateAsync(exercise);
        }

        public async Task DeleteExerciseAsync(int id)
        {
            await _exerciseRepository.DeleteAsync(id);
        }
    }
}
