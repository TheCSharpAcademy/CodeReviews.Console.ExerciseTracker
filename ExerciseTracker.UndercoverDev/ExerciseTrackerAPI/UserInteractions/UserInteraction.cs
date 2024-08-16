using System.Globalization;
using ExerciseTrackerAPI.Models;
using ExerciseTrackerAPI.Utilities;
using Spectre.Console;

namespace ExerciseTrackerUI;
public class UserInteraction
{
    public static void ShowWeightDetailTable(Weight weight)
    {
        var table = new Table()
            .AddColumn("Start Time")
            .AddColumn("End Time")
            .AddColumn("Duration")
            .Title("[bold][blue]Weight Detail[/][/]");

        if (weight != null)
        {
            table.AddRow(weight.DateStart.ToString(), weight.DateEnd.ToString(), weight.Duration.ToString());

            AnsiConsole.Write(table);
        }
    }

    internal static Weight GetWeightDetails()
    {
        var now = DateTime.Now;
        const string timeFormat = "yyyy-MM-dd HH:mm";

        var startTimeString = Validations.GetValidatedTimeInput("Enter shift start time", timeFormat, now);
        var startTime = DateTime.ParseExact(startTimeString, timeFormat, CultureInfo.InvariantCulture);

        var endTimeString = Validations.GetValidatedTimeInput("Enter shift end time", timeFormat, now, startTime);
        var endTime = DateTime.ParseExact(endTimeString, timeFormat, CultureInfo.InvariantCulture);

        var duration = endTime - startTime;

        var comment = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter comments (optional):")
                .DefaultValue("")
        );

        return new Weight { DateStart = startTime, DateEnd = endTime, Duration = duration, Comments = comment };
    }

    internal static void ShowWeights(List<Weight> weights)
    {
        weights.Insert(0, new Weight{ Comments = "Back"});

        var weightSelector = new SelectionPrompt<Weight>
        {
            Title = "[bold][blue]Select a weight to view its details[/][/]",
        };
        weightSelector.AddChoices(weights);
        weightSelector.UseConverter(w => w.Comments ?? "No Comments");

        var weightSelected = AnsiConsole.Prompt(weightSelector);

        if (weightSelected.Comments == "Back") return;

        ShowWeightDetailTable(weightSelected);
    }

    internal static Weight GetWeightOptionInput(List<Weight> weights)
    {
        weights.Insert(0, new Weight{ Comments = "Back"});
        
        var weightSelector = new SelectionPrompt<Weight>
        {
            Title = "[bold][blue]Select a weight to update or delete[/][/]",
        };
        weightSelector.AddChoices(weights);
        weightSelector.UseConverter(w => w.Comments?? "No Comments");

        var weightSelected = AnsiConsole.Prompt(weightSelector);

        return weightSelected;
    }
}