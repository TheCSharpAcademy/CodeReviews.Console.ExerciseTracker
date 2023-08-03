using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories
{
	internal class ExerciseRepository : IExerciseRepository
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
		}

		public IEnumerable<ExerciseModel> GetAll()
		{
			var allExercises = _context.Exercises;
			return allExercises;
		}

		public ExerciseModel GetById(int id)
		{
			var exerciseInDb = _context.Exercises.Find(id);
			return exerciseInDb;
		}

		public void Insert(ExerciseModel exercise)
		{
			_context.Exercises.Add(exercise);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Update(ExerciseModel exercise)
		{
			var exerciseInDb = _context.Exercises.Find(exercise.ExerciseId);
			if(exerciseInDb != null)
			{
				exerciseInDb.ExerciseType = exercise.ExerciseType;
				exerciseInDb.DateStart = exercise.DateStart;
				exerciseInDb.DateEnd = exercise.DateEnd;
				exerciseInDb.Comments = exercise.Comments;
			}
		}
	}
}
