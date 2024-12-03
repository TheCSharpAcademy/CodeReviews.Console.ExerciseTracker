using ExerciseTracker.TwilightSaw.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExerciseTracker.TwilightSaw.Data;

public class AppDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }

    private readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>();
    }
}