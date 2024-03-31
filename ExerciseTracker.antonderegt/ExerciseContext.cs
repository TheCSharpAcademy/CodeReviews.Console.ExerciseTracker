using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ExerciseTracker.Models;

namespace ExerciseTracker;

public class ExerciseContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public string ConnectionString { get; set; }

    public ExerciseContext()
    {
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}