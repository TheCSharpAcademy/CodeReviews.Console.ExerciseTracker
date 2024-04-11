using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExerciseTracker.Models;

namespace ExerciseTracker;

public class ExerciseContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    private string _connectionString { get; set; }

    public ExerciseContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}