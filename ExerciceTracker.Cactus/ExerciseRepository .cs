using Microsoft.EntityFrameworkCore;

namespace ExerciceTracker.Cactus
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ExerciseDbContext context) : base(context)
        {
        }
    }
}
