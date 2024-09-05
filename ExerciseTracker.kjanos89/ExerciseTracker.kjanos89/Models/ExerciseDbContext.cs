using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.kjanos89.Models;

public class ExerciseDbContext : DbContext 
{
    public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) { }
    public DbSet<Exercise> Exercises { get; set; }
}