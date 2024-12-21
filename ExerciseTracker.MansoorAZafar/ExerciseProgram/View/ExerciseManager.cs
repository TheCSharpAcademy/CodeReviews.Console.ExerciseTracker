namespace ExerciseProgram.View;
using ExerciseProgram.Model.Enums;
using ExerciseLibrary.Display;
using ExerciseLibrary.Utilities;
using ExerciseProgram.Controller;

internal class ExerciseManager 
{
    private ExerciseController controller = new();
    internal HomeMenu GetHomeSelection()
    {
        System.Console.Clear();
        Display.Figlet("Exercise Tracker");
        Display.DisplayHeader("Home", "left");

        return UserInput.GetSelection<HomeMenu>(item => item switch {
                HomeMenu.Update => "Update Exercise",
                HomeMenu.Delete => "Delete Exercise",
                HomeMenu.Create => "Create Exercise",
                HomeMenu.Read => "Get Exercise(s)",
                _ => item.ToString()
            });
    }

    internal void Begin() 
    {
        bool running = true;
        while(running) 
        {
            switch (this.GetHomeSelection()) 
            {
                case HomeMenu.Update:
                    System.Console.Clear();
                    Display.DisplayHeader("Update", "left");
                    this.controller.UpdateExercise();
                    break;
            
                case HomeMenu.Delete:
                    System.Console.Clear();
                    Display.DisplayHeader("Delete", "left");
                    this.controller.DeleteExercise();
                    break;
            
                case HomeMenu.Create:
                    System.Console.Clear();
                    Display.DisplayHeader("Create", "left");
                    this.controller.CreateExercise();
                    break;

                case HomeMenu.Read:
                    System.Console.Clear();
                    Display.DisplayHeader("Read", "left");
                    this.controller.ReadExercise();
                    break;

                default:
                    running = false;
                    break;
            }
            Utilities.PressKeyToContinue();
        }
        
        System.Console.Clear();
        Display.Figlet("Goodbye!");
    }
}