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
        public ExerciseRepository()
        {
            
        }
        public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ExerciseModel Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ExerciseModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Insert(ExerciseModel model)
		{
			throw new NotImplementedException();
		}

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}

		public void Update(ExerciseModel model)
		{
			throw new NotImplementedException();
		}
	}
}
