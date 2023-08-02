using ExerciseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerAPI.DataAccess
{
	public class ExerciseTrackerContext : DbContext
	{
		public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options) : base(options) 
		{ 
		}	
		public DbSet<ExerciseModel> Exercises { get; set; }
	}
}
