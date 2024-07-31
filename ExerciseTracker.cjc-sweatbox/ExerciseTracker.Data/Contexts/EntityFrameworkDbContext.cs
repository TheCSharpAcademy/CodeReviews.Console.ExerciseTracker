using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data.Contexts;

/// <summary>
/// Database context implmentation for EntityFrameworkCore.
/// </summary>
public class EntityFrameworkDbContext : DbContext
{
    #region Constructors

    public EntityFrameworkDbContext()
    {
    }

    public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : base(options)
    {
    }

    #endregion
    #region Properties

    public DbSet<ExerciseType> ExerciseTypes { get; set; }

    public DbSet<Exercise> Exercises { get; set; }

    #endregion
    #region Methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Required seed data.
        modelBuilder.Entity<ExerciseType>().HasData(
            new ExerciseType
            {
                Id = 1,
                Name = "Cardio"
            },
            new ExerciseType
            {
                Id = 2,
                Name = "Weights"
            }
        );

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
