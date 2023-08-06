using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly ExerciseTrackerContext _context;
		public ExerciseRepository(ExerciseTrackerContext context)
		{
			_context = context;
		}
		public void Delete(int id)
		{
			var exerciseInDb = _context.Exercises.Find(id);
			if (exerciseInDb != null)
			{
				_context.Remove(exerciseInDb);
			}
			_context.SaveChangesAsync();
		}

		public ExerciseModel GetById(int id)
		{
			return GetAll().FirstOrDefault(x => x.ExerciseId == id);
		}

		public IEnumerable<ExerciseModel> GetAll()
		{
			var allExercises = _context.Exercises;
			return allExercises;
		}

		public void Insert(ExerciseModel model)
		{
			_context.Exercises.Add(model);
			_context.SaveChanges();
		}

		public void Update(ExerciseModel model)
		{
			var exerciseInDb = _context.Exercises.Find(model.ExerciseId);
			if (exerciseInDb != null)
			{
				exerciseInDb = model;
			}
			_context.SaveChanges();
		}
	}
}
