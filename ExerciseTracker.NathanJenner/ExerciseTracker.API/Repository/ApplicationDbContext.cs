using ExerciseTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.API.Repository;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public virtual DbSet<Exercise> Exercises { get; set; }
}
