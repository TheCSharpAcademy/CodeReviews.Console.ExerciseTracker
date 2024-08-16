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
        Console.Clear();
        var weights = await _controller.GetWeights();

        if (weights == null || weights.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold][red]No weights found.[/][/]");
            return;
        }

        UserInteraction.ShowWeights(weights);
    }

    internal async Task AddWeight()
    {
        var weight = UserInteraction.GetWeightDetails();

        var createdWeight = await _controller.AddWeight(weight);

        if (createdWeight == null)
        {
            AnsiConsole.MarkupLine("[bold][red]Failed to add weight.[/][/]");
            return;
        }

        Console.Clear();
        AnsiConsole.MarkupLine("[bold][green]Weight added successfully.[/][/]");
    }

    internal async Task DeleteWeight()
    {
        Console.Clear();
        var weights = await _controller.GetWeights();

        if (weights == null || weights.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold][red]No weights found.[/][/]");
            return;
        }

        var selectedWeight = UserInteraction.GetWeightOptionInput(weights);

        if (selectedWeight == null || selectedWeight.Comments == "Back") return;

        await _controller.DeleteWeight(selectedWeight.Id);
        Console.Clear();

        AnsiConsole.MarkupLine("[bold][green]Weight deleted successfully.[/][/]");
    }

    internal async Task EditWeight()
    {
        Console.Clear();
        var weights = await _controller.GetWeights();

        if (weights == null || weights.Count == 0)
        {
            AnsiConsole.MarkupLine("[bold][red]No weights found.[/][/]");
            return;
        }

        var selectedWeight = UserInteraction.GetWeightOptionInput(weights);

        if (selectedWeight == null || selectedWeight.Comments == "Back") return;

        var updatedWeight = UserInteraction.GetWeightDetails();

        await _controller.UpdateWeight(selectedWeight.Id, updatedWeight);
        Console.Clear();

        AnsiConsole.MarkupLine("[bold][green]Weight updated successfully.[/][/]");
    }
}