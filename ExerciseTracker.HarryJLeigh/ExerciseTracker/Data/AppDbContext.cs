using ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Weights> Weights { get; set; }
    public DbSet<Cardio> CardioSessions { get; set; }
}