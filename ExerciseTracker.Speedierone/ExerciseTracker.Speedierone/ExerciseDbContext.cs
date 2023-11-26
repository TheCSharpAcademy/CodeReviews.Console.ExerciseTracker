using ExerciseTracker.Speedierone.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    internal class ExerciseDbContext : DbContext
    {
        public DbSet<Exercises> Exercises { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
