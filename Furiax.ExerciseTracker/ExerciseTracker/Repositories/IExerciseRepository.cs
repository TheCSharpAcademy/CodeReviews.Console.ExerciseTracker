using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories
{
    internal interface IExerciseRepository
    {
        IEnumerable<ExerciseModel> GetAll();
		ExerciseModel GetById(int id);
		void Insert(ExerciseModel exercise);
        void Update(ExerciseModel exercise);
        void Delete(int id);

        void Save();
    }
}
