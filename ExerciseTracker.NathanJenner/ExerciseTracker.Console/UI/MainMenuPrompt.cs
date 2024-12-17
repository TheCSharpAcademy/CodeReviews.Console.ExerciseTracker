using Spectre.Console;

namespace ExerciseTracker.Console.UI;

internal class MainMenuPrompt
{
    public void MainMenuSelection()
    {
        StartExercisePrompt startExercisePrompt = new();
        EndExercisePrompt endExercisePrompt = new();
        DisplayExerciseHistory displayExerciseHistory = new();

        var mainMenuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Please select from the options below: [/]")
                .PageSize(20)
                .AddChoices(new[] {
                    "Start Excercise", "End Exercise", "Show Exercise History", "Exit Application"
                }));

        switch (mainMenuSelection)
        {
            case "Start Excercise": startExercisePrompt.StartExercise(); break;
            case "End Exercise": endExercisePrompt.EndExercise(); break;
            case "Show Exercise History": displayExerciseHistory.ShowExerciseHistory(); break;
            case "Exit Application": Environment.Exit(0); break;
        }
    }
}
