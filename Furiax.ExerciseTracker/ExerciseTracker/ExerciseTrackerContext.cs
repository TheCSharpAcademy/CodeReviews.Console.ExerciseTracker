using ExerciseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker
{
	internal class ExerciseTrackerContext : DbContext
	{
        public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext>options) 
			: base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<ExerciseModel> Exercises { get; set; }
	}
}
