using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.K_MYR;

public class ExerciseDbContext : DbContext
{    
    private readonly string? _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
   
    public DbSet<Exercise> Exercises {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);
}