using ExerciseTracker.kjanos89.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
public static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello world!");
        var serviceProvider = new ServiceCollection()
        .AddDbContext<ExerciseDbContext>(options =>
         options.UseSqlServer("Server=localhost;Database=Exercises;Integrated Security=True;TrustServerCertificate=True;"))
        .BuildServiceProvider();

        using (var context = serviceProvider.GetRequiredService<ExerciseDbContext>())
        {
            context.Database.EnsureCreated();
        }
    }
}