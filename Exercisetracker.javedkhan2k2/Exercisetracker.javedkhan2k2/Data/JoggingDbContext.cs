using Exercisetacker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercisetacker.Data;

public class JoggingDbContext : DbContext
{
    public DbSet<Excercise> Excercises {get;set;}

    public JoggingDbContext(DbContextOptions<JoggingDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            Console.Clear();
            Console.WriteLine("Please configure the DefaultConnection\n");
            System.Environment.Exit(0);
        }
    }
}