using ExerciseTracker.Speedierone;
using Microsoft.Identity.Client;

namespace ExerciseTracker;

class Program
{
    static void Main(string[] args)
    {
        //var repository = new ExerciseRepository();
        //var service = new ExerciseService(repository);
        
        static void ShowMenu()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("Welcome to the exercise tracker app");
                Console.WriteLine("Please choose from the following options");
                Console.WriteLine("0 = Exit Program");
                Console.WriteLine("1 = View all exercises");
                Console.WriteLine("2 = Add new exercise");
                Console.WriteLine("3 = Update current exercise");
                Console.WriteLine("4 = Delete exercise");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        UserInput.ShowAll();
                        break;
                    default:
                        Console.WriteLine("Invalid entry.");
                        command = Console.ReadLine();
                        break;
                }
            }
        }
        ShowMenu();
    }
}
