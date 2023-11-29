using ExerciseTracker.Speedierone.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public class ExerciseDbContext : DbContext
    {
        public DbSet<Exercises> Exercises { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
