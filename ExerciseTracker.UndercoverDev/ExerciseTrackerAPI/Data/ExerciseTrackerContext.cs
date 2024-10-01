using ExerciseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerAPI.Data;
public class ExerciseTrackerContext : DbContext
{
    public DbSet<Weight> Weights { get; set; }

    public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options)
        : base(options)
    {
    }
}