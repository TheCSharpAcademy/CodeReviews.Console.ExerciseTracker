using Spectre.Console;
using ExerciseTracker.Mefdev.Models;
using ExerciseTracker.Mefdev.Controllers;

namespace ExerciseTracker.Mefdev;

public class UserInterface : ExerciseBase
{
    private readonly ExerciseController _exerciseController;

    public UserInterface(ExerciseController exerciseController)
    {
        _exerciseController = exerciseController;
    }

    public void MainMenu()
    {
        while (true)
        {
                AnsiConsole.Write(new FigletText("Exercise Tracker").Color(Color.DodgerBlue1).Centered());

                AnsiConsole.Clear();

                var options = Enum.GetValues(typeof(ExerciseMenu.Options))
                .Cast<ExerciseMenu.Options>()
                .ToList();

                var mainChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<ExerciseMenu.Options>()
                        .Title("Choose an option:")
                        .AddChoices(options)
                        .UseConverter(option => option.GetDisplayName())
                );

            switch (mainChoice)
                {
                    
                    case ExerciseMenu.Options.Quit:
                        DisplayMessage("Exiting the app...", "red");
                        Environment.Exit(0);
                        break;
                    case ExerciseMenu.Options.Create:
                        _exerciseController.CreateExercise();
                        break;
                    case ExerciseMenu.Options.Update:
                        _exerciseController.UpdateExercise();
                        break;
                    case ExerciseMenu.Options.Delete:
                        _exerciseController.DeleteExercise();
                        break;
                    case ExerciseMenu.Options.View:
                        _exerciseController.GetExercise();
                        break;
                    case ExerciseMenu.Options.ViewAll:
                        _exerciseController.GetExercises();
                        break;
                    default:
                        DisplayMessage("Invalid choice. Please select a valid option.", "red");
                        break;
                }
        }
    }
}