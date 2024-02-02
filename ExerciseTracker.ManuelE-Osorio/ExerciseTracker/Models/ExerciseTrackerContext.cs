using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Models;
public class ExerciseTrackerContext : DbContext
{
    public static readonly int CommentsLength = 200;
    public static string? ShiftsLoggerConnectionString {get; set;}
    public DbSet<Running> RunningExercise {get; set;}

    public ExerciseTrackerContext()
    {
        try
        {
            Database.OpenConnection();
            Database.CanConnect();
        }
        catch
        {
            throw new Exception("The app cannot connect to the Database. "+
                "Please check your Connection String configuration in your appsettings.json");
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .UseSqlServer(ShiftsLoggerConnectionString,
        sqlServerOptions => sqlServerOptions.CommandTimeout(5)
        )
        .LogTo(Console.WriteLine);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Running>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Running>()
            .Property(p => p.Id)
            .UseIdentityColumn();

        modelBuilder.Entity<Running>()
            .Property(p => p.Comments)
            .HasMaxLength(CommentsLength)
            .IsUnicode(true);  
    }
}