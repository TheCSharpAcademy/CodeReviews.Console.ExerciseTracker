using ExerciseTracker.ukpagrace.Controllers;
using ExerciseTracker.ukpagrace.Enums;
using ExerciseTracker.ukpagrace.Helper;
using Spectre.Console;

namespace ExerciseTracker.ukpagrace.UserInterface
{
    
    public class Menu
    {
        public readonly ExerciseController _exerciseController;

       public Menu(ExerciseController exerciseController)
       {
           _exerciseController = exerciseController;
       }   


        public void Main()
        {
            var runApp = true;
            AnsiConsole.Write(new FigletText("ExerciseTracker"));

            do
            {
                var menuOption = new SelectionPrompt<MenuEnum>();
                menuOption.Title("Choose a menu option");
                menuOption.AddChoice(MenuEnum.AddExercise);
                menuOption.AddChoice(MenuEnum.ViewExercises);
                menuOption.AddChoice(MenuEnum.ViewExercise);
                menuOption.AddChoice(MenuEnum.UpdateExercise);
                menuOption.AddChoice(MenuEnum.DeleteExercise);
                menuOption.AddChoice(MenuEnum.Exit);
                menuOption.UseConverter(option => option.GetEnumDescription());

                var selectedOption = AnsiConsole.Prompt(menuOption);

                switch (selectedOption) 
                {
                    case MenuEnum.AddExercise:
                        Console.Clear();
                        _exerciseController.AddExercise();
                        break;
                    case MenuEnum.ViewExercises:
                        Console.Clear();
                        _exerciseController.GetExercises();
                        break;
                    case MenuEnum.ViewExercise:
                        Console.Clear();
                        _exerciseController.GetExercise();
                        break;
                    case MenuEnum.UpdateExercise:
                        Console.Clear();
                        _exerciseController.UpdateExercise();
                        break;
                    case MenuEnum.DeleteExercise:
                        Console.Clear();
                        _exerciseController.DeleteExercise();
                        break;
                    case MenuEnum.Exit:
                        runApp = false;
                        Environment.Exit(0);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (runApp);
        }
    }
}
