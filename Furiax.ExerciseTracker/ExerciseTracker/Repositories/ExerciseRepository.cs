using ExerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public ExerciseModel Get(int id)
		{
			var exerciseInDb = _context.Exercises.Find(id);
			return exerciseInDb;
		}

		public IEnumerable<ExerciseModel> GetAll()
		{
			var allExercises = _context.Exercises;
			return allExercises;
		}

		public void Insert(ExerciseModel model)
		{
			_context.Exercises.Add(model);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(ExerciseModel model)
		{
			var exerciseInDb = _context.Exercises.Find(model.ExerciseId);
			if (exerciseInDb != null)
			{
				exerciseInDb.ExerciseType = model.ExerciseType;
				exerciseInDb.DateStart = model.DateStart;
				exerciseInDb.DateEnd = model.DateEnd;
				exerciseInDb.Comments = model.Comments;
			}
		}
	}
}
