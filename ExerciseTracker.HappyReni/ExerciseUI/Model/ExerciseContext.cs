using Microsoft.EntityFrameworkCore;

namespace ExerciseUI.Model
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext() { }

        public ExerciseContext(DbContextOptions options) : base(options) { }

        public DbSet<ExerciseModel> Exercises { get; set; } = null!;
    }
}
