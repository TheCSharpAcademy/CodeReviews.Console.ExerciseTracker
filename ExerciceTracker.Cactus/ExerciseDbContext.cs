using Microsoft.EntityFrameworkCore;

namespace ExerciceTracker.Cactus
{
    public class ExerciseDbContext : DbContext
    {
        public DbSet<Exercise> ExerciseSet { get; set; }

        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
