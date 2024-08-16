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
                // case "Add Weight":
                //     AddWeight.ShowAddWeight();
                //     break;
                // case "Edit Weight":
                //     EditWeight.ShowEditWeight();
                //     break;
                // case "Delete Weight":
                //     DeleteWeight.ShowDeleteWeight();
                //     break;
                // case "Exit":
                //     isAppRunning = false;
                //     break;
                // default:
                //     AnsiConsole.Write(Color.Red, "Invalid choice. Please try again.");
                //     break;
            }
        }
    }
}