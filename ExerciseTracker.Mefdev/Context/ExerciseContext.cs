using ExerciseTracker.Mefdev.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ExerciseTracker.Mefdev.Context;
public class ExerciseContext : DbContext
{
    public DbSet<Exercise> Exercises {get; set;} = null!;
    private static IConfiguration _configuration = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Exercise>().HasData(
            new Exercise
            {
                Id = 1,
                DateStart = new DateTime(2024, 11, 1, 8, 0, 0),
                DateEnd = new DateTime(2024, 11, 1, 9, 0, 0),
                Duration = TimeSpan.Parse("01:00:00"),
                Comments = "Morning workout: Running and stretching.",
                Type = "Cardio"
            },
            new Exercise
            {
                Id = 2,
                DateStart = new DateTime(2024, 11, 2, 10, 0, 0),
                DateEnd = new DateTime(2024, 11, 2, 11, 0, 0),
                Duration = TimeSpan.Parse("01:00:00"),
                Comments = "Strength training: Upper body workout.",
                Type = "Strength"
            },
            new Exercise
            {
                Id = 3,
                DateStart = new DateTime(2024, 11, 3, 7, 30, 0),
                DateEnd = new DateTime(2024, 11, 3, 8, 30, 0),
                Duration = TimeSpan.Parse("01:00:00"),
                Comments = "Yoga and stretching session.",
                Type = "Flexibility"
            },
            new Exercise
            {
                Id = 4,
                DateStart = new DateTime(2024, 11, 4, 6, 0, 0),
                DateEnd = new DateTime(2024, 11, 4, 7, 0, 0),
                Duration = TimeSpan.Parse("01:00:00"),
                Comments = "Cycling and cardio exercises.",
                Type = "Cardio"
            }
        );
    }

    private static string GetCurrentPath()
    {
        return Environment.CurrentDirectory.Replace("bin/Debug/net8.0", "");
    }

    private static string? GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(GetCurrentPath())
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
        return _configuration.GetConnectionString("DefaultConnection");
    }

}


