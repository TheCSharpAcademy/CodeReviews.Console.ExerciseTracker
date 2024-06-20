using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker;
public class ExerciseDatabase : DbContext
{
    public ExerciseDatabase(DbContextOptions<ExerciseDatabase> options)
    : base(options)
    {
    }
    public DbSet<Exercise> Exercise { get; set; }
}