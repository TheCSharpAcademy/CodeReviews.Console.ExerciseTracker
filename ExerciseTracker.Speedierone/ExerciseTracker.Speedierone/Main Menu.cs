using ExerciseTracker.Speedierone.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public class Main_Menu
    {
       private readonly IExerciseRepository _exerciseService;
        private readonly UserInput _userInput;
        public Main_Menu(IExerciseRepository exerciseService, UserInput userInput)
        {
            _exerciseService = exerciseService;
            _userInput = userInput;
        }
        public void ShowMenu()
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
                        //UserInput.ShowAll();
                        break;
                    case "2":
                        Exercises newExercise = _userInput.GetSession();
                        _exerciseService.Add(newExercise);
                        Console.WriteLine("New sessions added.");
                        break;
                    default:
                        Console.WriteLine("Invalid entry.");
                        command = Console.ReadLine();
                        break;
                }
            }
        }
    }
}
