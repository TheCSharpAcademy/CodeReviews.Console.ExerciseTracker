using ExerciseTracker.Models;
using Spectre.Console;

namespace ExerciseTracker.Views;

public static class TableVisualisation
{
    internal static void ShowWeightsTable(List<Weights> weights)
    {
        var table = new Table().AddColumns(
            "ID",
            "Start",
            "End",
            "Sets",
            "Total Weight",
            "Duration",
            "Comments"
        );
        
        foreach (var weight in weights)
        {
            table.AddRow(
                weight.Id.ToString(),
                weight.DateStart.ToString("yyyy-MM-dd HH:mm"),
                weight.DateEnd.ToString("yyyy-MM-dd HH:mm"),
                weight.Sets.ToString(),
                weight.TotalWeight.ToString(),
                weight.Duration.ToString(@"hh\:mm\:ss"),
                weight.Comments
            );
        }
        AnsiConsole.Write(table);
    }

    internal static void ShowCardioTable(List<Cardio> cardioSessions)
    {
        var table = new Table().AddColumns(
            "ID",
            "Start",
            "End",
            "Distance (K/M)",
            "Duration",
            "Comments");

        foreach (var cardio in cardioSessions)
        {
            table.AddRow(
                cardio.Id.ToString(),
                cardio.DateStart.ToString("yyyy-MM-dd HH:mm"),
                cardio.DateEnd.ToString("yyyy-MM-dd HH:mm"),
                cardio.Distance.ToString(),
                cardio.Duration.ToString(@"hh\:mm\:ss"),
                cardio.Comments
            );
        }
        AnsiConsole.Write(table);
    }
}