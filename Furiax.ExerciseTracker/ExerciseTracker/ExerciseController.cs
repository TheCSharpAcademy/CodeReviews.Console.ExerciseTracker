using ExerciseTracker.Models;
using ExerciseTracker.Repositories;

namespace ExerciseTracker
{
	public class ExerciseController
	{
		private readonly IExerciseRepository _exerciseRepository;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
			_exerciseRepository = exerciseRepository;
		}
        public void InsertExercise(ExerciseModel exercise)
		{
			_exerciseRepository.Insert(exercise);
		}
	}
}
