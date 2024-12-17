using ExerciseTracker.Console.Services;
using Spectre.Console;

namespace ExerciseTracker.Console.UI;

public class EndExercisePrompt
{
    ExerciseConsoleService exerciseConsoleService = new();
    MainMenuPrompt mainMenuPrompt = new();

    public void EndExercise()
    {
        AnsiConsole.Markup("Please enter comments for your exercise entry: ");
        string commentsInput = System.Console.ReadLine();
        exerciseConsoleService.EndExercise(commentsInput);

        AnsiConsole.Markup("\n\n\n\nExercise session recorded.\n\n\n\n\n\n\n\n");
        mainMenuPrompt.MainMenuSelection();
    }
}
