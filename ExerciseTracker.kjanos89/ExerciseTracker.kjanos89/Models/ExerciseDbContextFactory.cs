using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.kjanos89.Models
{
    public class ExerciseDbContextFactory : IDesignTimeDbContextFactory<ExerciseDbContext>
    {
        public ExerciseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExerciseDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Exercises;Integrated Security=True;TrustServerCertificate=True;");

            return new ExerciseDbContext(optionsBuilder.Options);
        }
    }
}