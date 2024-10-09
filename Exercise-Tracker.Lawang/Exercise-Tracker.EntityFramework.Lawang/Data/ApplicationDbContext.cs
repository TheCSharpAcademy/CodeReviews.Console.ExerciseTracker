using Exercise_Tracker.EntityFramework.Lawang.Models;
using Microsoft.EntityFrameworkCore;


namespace Exercise_Tracker.EntityFramework.Lawang.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base (options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>().HasData
        (
            new Exercise() 
            {
                Id = 1,
                DateStart = new DateTime(2024, 01, 01),
                DateEnd = new DateTime(2024, 01, 30),
                Comments = "New year resolve. Completed successfully for the first month!"
            },
            new Exercise()
            {
                Id = 2,
                DateStart = new DateTime(2024, 03, 01),
                DateEnd = new DateTime(2024, 04, 30),
                Comments = "Now able to run 10 km and completed the cardio routine."
            },
            new Exercise()
            {
                Id = 3,
                DateStart = new DateTime(2024, 05, 01),
                DateEnd = new DateTime(2024, 06, 28),
                Comments = "Started Weight Training Now able to lift 70 kg deadlift."
            },
            new Exercise()
            {
                Id = 4,
                DateStart = new DateTime(2024, 08, 01),
                DateEnd = new DateTime(2024, 08, 30),
                Comments = "Started the body flexibility training"
            }
        );
    }

}
