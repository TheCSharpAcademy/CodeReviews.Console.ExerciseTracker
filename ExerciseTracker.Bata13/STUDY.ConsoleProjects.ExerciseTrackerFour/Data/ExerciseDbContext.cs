using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Data;
internal class ExerciseDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.config")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ExerciseDbContext"));
    }
}
