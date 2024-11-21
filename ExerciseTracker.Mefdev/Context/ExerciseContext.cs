using ExerciseTracker.Mefdev.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Mefdev.Context;
public class ExerciseContext : DbContext
{
    public DbSet<Exercise> Exercises {get; set;} = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
}
