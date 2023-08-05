using ExerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Repositories
{
	public interface IExerciseRepository
	{
		public IEnumerable<ExerciseModel> GetAll();
        ExerciseModel Get(int id);
		void Insert(ExerciseModel model);
		void Update(ExerciseModel model);
		void Delete(int id);
    }
}
