using ExerciseTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker
{
	internal class ExerciseTrackerContext : IdentityDbContext
	{
		public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options)
			: base(options)
		{
		}
		public DbSet<ExerciseModel> Exercises { get; set; }
	}
}
