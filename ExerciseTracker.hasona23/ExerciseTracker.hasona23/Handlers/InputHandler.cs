using ExerciseTracker.hasona23.Models;
using Spectre.Console;

namespace ExerciseTracker.hasona23.Handlers;

public class InputHandler
{
    public Exercise SelectExercise(List<Exercise> exercises)
    {
        var selectionPrompt = new SelectionPrompt<Exercise>()
            .Title("[yellow]Choose an Exercise: [/]")
            .AddChoices(exercises)
            .HighlightStyle(new Style(Color.Yellow));
      
        return AnsiConsole.Prompt(selectionPrompt);
    }
}