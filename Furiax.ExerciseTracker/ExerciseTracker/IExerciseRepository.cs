using ExerciseTracker.Models;

namespace ExerciseTracker
{
	internal interface IExerciseRepository
	{
		ExerciseModel GetExerciseById(int id);
		IEnumerable<ExerciseModel> GetAllExercises();
		void AddExercise(ExerciseModel exercise);
		void UpdateExercise(ExerciseModel exercise);
		void DeleteExercise(int id);
	}
}
