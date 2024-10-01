using Spectre.Console;

namespace ExerciseTrackerUI.Views;
public class MainMenu
{
    private readonly WeightsView _weightsView;

    public MainMenu(WeightsView weightsView)
    {
        _weightsView = weightsView;
    }
    
    public async Task ShowMainMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Welcome to Exercise Tracker")
                .AddChoices(
                    "View Weights",
                    "Add Weight",
                    "Edit Weight",
                    "Delete Weight",
                    "Exit"
                )
            );

            switch (choice)
            {
                case "View Weights":
                    await _weightsView.ShowAllWeights();
                    break;
                case "Add Weight":
                    await _weightsView.AddWeight();
                    break;
                case "Edit Weight":
                    await _weightsView.EditWeight();
                    break;
                case "Delete Weight":
                    await _weightsView.DeleteWeight();
                    break;
                case "Exit":
                    isAppRunning = false;
                    AnsiConsole.MarkupLine("[bold][green]Exiting the application...[/][/]");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}