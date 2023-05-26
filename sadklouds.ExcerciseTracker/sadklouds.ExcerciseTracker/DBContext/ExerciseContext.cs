using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sadklouds.ExcerciseTracker.Models;

namespace sadklouds.ExcerciseTracker.DBContext;

public class ExerciseContext : DbContext
{
    public ExerciseContext()
    {

    }

    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options) { }


    public DbSet<ExerciseModel> Exercises { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        var config = builder.Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("Default"));
    }



}
