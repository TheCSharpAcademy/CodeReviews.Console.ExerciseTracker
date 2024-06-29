using System.Configuration;
using App.ExerciseLogs.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Database.EntityFramework;

public class ExercisesDbContext : DbContext
{
    public DbSet<ExerciseLog> Exercise { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        string dbPath = ConfigurationManager.AppSettings["DbPath"] ??
                throw new ConfigurationErrorsException("DbPath configuration must be defined in App.config");

        builder.UseSqlite($"Data Source={dbPath}");
    }
}