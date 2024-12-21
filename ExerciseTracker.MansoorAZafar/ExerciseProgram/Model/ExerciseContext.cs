using ExerciseProgram.Model.ExerciseModel;
using Microsoft.EntityFrameworkCore;

namespace ExerciseProgram.Model;

public class ExerciseContext: DbContext
{
    public DbSet<Exercise> Exercises {get; set;}   

    public ExerciseContext(DbContextOptions<ExerciseContext> options): base(options) {}
}