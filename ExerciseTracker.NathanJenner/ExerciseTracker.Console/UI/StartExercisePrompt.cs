using ExerciseTracker.API.Models;
using ExerciseTracker.Console.Services;
using Spectre.Console;

namespace ExerciseTracker.Console.UI;

public class StartExercisePrompt
{
    ExerciseConsoleService exerciseConsoleService = new();
    MainMenuPrompt mainMenuPrompt = new();
    Exercise exercise { get; set; }

    public void StartExercise()
    {
        exerciseConsoleService.StartExercise();

        AnsiConsole.Markup("Started successful.\n\n\n\n\n");
        mainMenuPrompt.MainMenuSelection();
    }
}
