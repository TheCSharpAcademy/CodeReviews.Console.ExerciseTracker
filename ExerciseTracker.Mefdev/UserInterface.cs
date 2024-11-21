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

                var mainChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<Enums.UserOptions>()
                        .Title("Choose an option:")
                        .AddChoices(Enum.GetValues(typeof(Enums.UserOptions)).Cast<Enums.UserOptions>())
                );

                switch (mainChoice)
                {
                    case Enums.UserOptions.Quit:
                        DisplayMessage("Exiting the app...", "red");
                        Environment.Exit(0);
                        break;
                    case Enums.UserOptions.CreateExercise:
                        _exerciseController.CreateExercise();
                        break;
                    case Enums.UserOptions.UpdateExercise:
                        _exerciseController.UpdateExercise();
                        break;
                    case Enums.UserOptions.DeleteExercise:
                        _exerciseController.DeleteExercise();
                        break;
                    case Enums.UserOptions.ViewExercise:
                        _exerciseController.GetExercise();
                        break;
                    case Enums.UserOptions.ViewExercises:
                            _exerciseController.GetExercises();
                        break;
                    default:
                        DisplayMessage("Invalid choice. Please select a valid option.", "red");
                        break;
                }
        }
    }
}