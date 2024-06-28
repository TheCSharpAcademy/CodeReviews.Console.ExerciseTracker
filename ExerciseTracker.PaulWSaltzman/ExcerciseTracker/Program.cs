using ExerciseTracker.Controllers;
using ExerciseTracker.Data;
using ExerciseTracker.Repositories;
using ExerciseTracker.UserInterface;
using Microsoft.Extensions.DependencyInjection;



namespace ExerciseTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ExerciseTrackerContext>()
                .AddScoped<IExerciseRepository, ExerciseRepository>()
                .AddScoped<ExerciseController>()
                .BuildServiceProvider();

            var controller = serviceProvider.GetService<ExerciseController>();

            if (controller != null)
            {
                var menu = new Menu(controller);
                menu.MainMenu();
            }
            else
            {
                Console.WriteLine("Failed to initialize controller.");
            }
        }
    }
}




//https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU
//https://www.youtube.com/watch?v=xMktEpPmadI
//https://www.youtube.com/watch?v=8fFBWmbUaIg&t=994s
//https://stackoverflow.com/questions/1101872/how-to-set-space-on-enum
//https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
//https://www.youtube.com/watch?v=shzPIfZ70Pw
//https://www.youtube.com/watch?v=8fFBWmbUaIg&t=994s  7:19

// https://www.youtube.com/watch?v=Jnv7hNNuTqs

