using ExerciseTracker.Models;
using ExerciseTracker.Repositories;

namespace ExerciseTracker
{
	public class ExerciseService
	{
		private readonly IExerciseRepository _exerciseRepository;
        public ExerciseService(IExerciseRepository exerciseRepository)
        {
			_exerciseRepository = exerciseRepository;
		}
        public void AddExercise()
		{
			var exercise = new ExerciseModel();
			exercise = UserInput.GetExerciseInfo();
			_exerciseRepository.Insert(exercise);
		}
	}
}
