using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Models;
using System.Configuration;

namespace ExerciseTracker.Data;
internal class ExerciseTrackerContext : DbContext
{
    private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    public ExerciseTrackerContext()
    {
    }

    public ExerciseTrackerContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Exercise>()
            .Property(e => e.Duration)
            .UsePropertyAccessMode(PropertyAccessMode.Property);

    public DbSet<Exercise> Exercises { get; set; }
}
