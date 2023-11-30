using ExerciseTracker.Speedierone.Model;

namespace ExerciseTracker.Speedierone.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        public readonly ExerciseDbContext _context;
        public ExerciseRepository(ExerciseDbContext context)
        {
            _context = context;
        }
        public void Add(Exercises exercises)
        {
            _context.Exercises.Add(exercises);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var exerciseToDelete = _context.Exercises.Find(id);
            if (exerciseToDelete != null)
            {
                _context.Exercises.Remove(exerciseToDelete);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Could not find session matching that ID");
            }
        }

        public IEnumerable<Exercises> GetAll()
        {
            return _context.Exercises.ToList();
        }
        public List<Exercises> GetById(int id)
        {
            Exercises result = _context.Exercises.SingleOrDefault(e => e.Id == id);

            List<Exercises> resultList = result != null ? new List<Exercises> { result } : new List<Exercises>();

            return resultList;
        }

        public void Update(Exercises exercisesToUpdate)
        {
            UserInput session = new UserInput();
            session.GetSessionForUpdate(exercisesToUpdate);
            _context.Update(exercisesToUpdate);
            _context.SaveChanges();
        }
        public void Save()
        {

        }
    }
}
