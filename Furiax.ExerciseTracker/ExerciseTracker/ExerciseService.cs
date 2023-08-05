using ExerciseTracker.Models;

namespace ExerciseTracker
{
	public class ExerciseService
	{
		public void AddExercise()
		{
			var exercise = new ExerciseModel();
			exercise = UserInput.GetExerciseInfo();
			ExerciseController.InsertExercise(exercise);

		}
	}
}
