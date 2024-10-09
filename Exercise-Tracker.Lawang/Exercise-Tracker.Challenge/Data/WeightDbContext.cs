using Microsoft.EntityFrameworkCore;

namespace Exercise_Tracker.Challenge.Data;

public class WeightDbContext : DbContext
{
    public DbSet<Exercise> Weights { get; set; }
    public WeightDbContext(DbContextOptions<WeightDbContext> options) : base(options)
    {

    }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlServer(ApplicationConnection.ConnectionString);
    //     }
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>().HasData
        (
            new Exercise()
            {
                Id = 1,
                DateStart = new DateTime(2024, 02, 01),
                DateEnd = new DateTime(2024, 02, 20),
                Comments = "First month of Weight training completed successfully!"
            },

            new Exercise()
            {
                Id = 2,
                DateStart = new DateTime(2024, 03, 01),
                DateEnd = new DateTime(2024, 03, 28),
                Comments = "Had some set backs but achieved the goal of training"
            },

            new Exercise()
            {
                Id = 3,
                DateStart = new DateTime(2024, 11, 01),
                DateEnd = new DateTime(2024, 11, 28),
                Comments = "Weights training completed"
            }

        );

    }
}
