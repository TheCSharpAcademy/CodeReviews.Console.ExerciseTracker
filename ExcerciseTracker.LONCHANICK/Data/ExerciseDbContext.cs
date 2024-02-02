using ExerciseTracker.LONCHANICK.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.LONCHANICK.Data;
public class ExerciseDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Exercise.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ExerciseRecord> ExerciseRecords {get; set;}

}