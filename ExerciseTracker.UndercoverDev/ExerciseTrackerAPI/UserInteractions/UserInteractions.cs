using ExerciseTrackerAPI.Models;
using Spectre.Console;

namespace ExerciseTrackerUI;
public class UserInteractions
{
    public static void ShowWeights(List<Weight> weights)
    {
        var table = new Table()
            .AddColumn("ID")
            .AddColumn("Start Time")
            .AddColumn("End Time")
            .AddColumn("Duration")
            .Title("[bold][blue]Weights[/][/]");

        if (weights != null)
        {
            var count = 1;
            foreach (var weight in weights)
            {
                table.AddRow(count.ToString(), weight.DateStart.ToString(), weight.DateEnd.ToString(), weight.Duration.ToString());
                count++;
            }

            AnsiConsole.Write(table);
        }
    }
}