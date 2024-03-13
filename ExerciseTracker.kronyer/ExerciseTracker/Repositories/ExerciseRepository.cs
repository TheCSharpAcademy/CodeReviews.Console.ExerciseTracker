using ExerciseTracker.Models;
using ExerciseTracker.Repositories.Interfaces;

namespace ExerciseTracker.Repositories
{
    internal class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }

        public void AddExercise(Exercise exercise)
        {
            _context.Add(exercise);
            _context.SaveChanges();
        }

        public Exercise GetById(int id)
        {
            return _context.Exercises.Find(id);
        }

        public List<Exercise> GetAll()
        {
            return _context.Exercises.ToList();
        }

        public void UpdateExercise(Exercise exercise)
        {
            _context.Update(exercise);
            _context.SaveChanges();
        }

        public void DeleteExercise(int id)
        {
            var exercise = _context.Exercises.Find(id);
            _context.Remove(exercise);
            _context.SaveChanges();
        }
    }
}
