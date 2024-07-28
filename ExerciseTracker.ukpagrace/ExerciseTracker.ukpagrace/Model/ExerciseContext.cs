using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.ukpagrace.Model
{
    public class ExerciseContext: DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ExerciseTracker;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
