using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sadklouds.ExcerciseTracker.Models;

namespace sadklouds.ExcerciseTracker.DBContext;

public class ExerciseContext : DbContext
{
  
    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options) { }


    public DbSet<ExerciseModel> Exercises { get; set; }

}
