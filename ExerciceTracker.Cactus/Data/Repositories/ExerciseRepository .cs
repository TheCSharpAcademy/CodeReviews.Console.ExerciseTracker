using ExerciseTracker.Cactus.Data.Interfaces;
using ExerciseTracker.Cactus.Model;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Cactus.Data.Repositories
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ExerciseDbContext context) : base(context)
        {
        }
    }
}
