using ExerciseTrackerAPI.Controllers;
using Spectre.Console;

namespace ExerciseTrackerUI.Views;
public class WeightsView
{
    private readonly IExerciseTrackerController _controller;

    public WeightsView(IExerciseTrackerController controller)
    {
        _controller = controller;
    }
    
    public async Task ShowAllWeights()
    {
        var weights = await _controller.GetWeights();

        if (weights == null || weights.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold][red]No shifts found.[/][/]");
            return;
        }

        UserInteractions.ShowWeights(weights);
    }
}