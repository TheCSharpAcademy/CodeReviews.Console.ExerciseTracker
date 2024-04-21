using ExerciseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerAPI;

public class ExercisesContext : DbContext
{
  public ExercisesContext(DbContextOptions<ExercisesContext> options) : base(options) { }

  public DbSet<Exercise> Exercises { get; set; }
}