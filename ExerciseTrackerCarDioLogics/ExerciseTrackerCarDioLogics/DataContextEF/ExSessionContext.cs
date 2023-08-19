using ExerciseTrackerCarDioLogics.Models;
using Microsoft.EntityFrameworkCore;
namespace ExerciseTrackerCarDioLogics.Data;

public class ExSessionContext : DbContext
{
    public DbSet<ExSession> ExSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ExerciseTrackerDB;Trusted_Connection=True;");
    }
}
