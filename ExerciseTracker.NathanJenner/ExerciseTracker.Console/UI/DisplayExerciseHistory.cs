using ExerciseTracker.API.Models;
using ExerciseTracker.Console.Services;
using Spectre.Console;

namespace ExerciseTracker.Console.UI;

public class DisplayExerciseHistory
{
    ExerciseConsoleService consoleService = new();
    MainMenuPrompt menuPrompt = new();

    public void ShowExerciseHistory()
    {
        Task<List<Exercise>> allExercisesTask = consoleService.GetExerciseHistory();
        List<Exercise> allExercises = allExercisesTask.Result;

        AnsiConsole.Clear();
        AnsiConsole.Markup("[bold yellow]Exercise History[/]\n");
        var table = new Table();
        table.AddColumn("Start Time");
        table.AddColumn("End Time");
        table.AddColumn("Duration");
        table.AddColumn("Comments");

        foreach (var ex in allExercises)
        {
            table.AddRow(ex.StartTime.ToString(), ex.EndTime.ToString(), ex.Duration.ToString(), ex.Comments);
        }
        AnsiConsole.Render(table);
        AnsiConsole.WriteLine("\n\n\n\n\n");
        menuPrompt.MainMenuSelection();
    }
}
