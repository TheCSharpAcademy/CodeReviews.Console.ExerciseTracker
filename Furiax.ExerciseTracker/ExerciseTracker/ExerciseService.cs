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
			var exercise = ExerciseController.AddExercise();
			_exerciseRepository.Insert(exercise);
		}

		internal void DeleteExercise()
		{
			var exercises = _exerciseRepository.GetAll().ToList();
			int id = ExerciseController.GetIdOption(exercises);
			_exerciseRepository.Delete(id);
		}

		internal void GetAll()
		{
			var exercises = _exerciseRepository.GetAll().ToList();
			ExerciseController.PrintExercisesTable(exercises);
		}

		internal void GetExerciseById()
		{
			var exercises = _exerciseRepository.GetAll().ToList();
			int id = ExerciseController.GetIdOption(exercises);
			var exercise = _exerciseRepository.GetById(id);
			ExerciseController.PrintExercise(exercise);
		}

		internal void UpdateExercise()
		{
			var exercises = _exerciseRepository.GetAll().ToList();
			int id = ExerciseController.GetIdOption(exercises);
			var exercise = _exerciseRepository.GetById(id);
			var updatedExercise = ExerciseController.GetUpdateInfo(exercise);
			_exerciseRepository.Update(updatedExercise);
		}
	}
}
