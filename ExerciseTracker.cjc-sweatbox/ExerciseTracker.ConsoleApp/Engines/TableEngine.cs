using ExerciseTracker.ConsoleApp.Models;
using Spectre.Console;

namespace ExerciseTracker.ConsoleApp.Engines;

/// <summary>
/// Engine for Spectre.Table generation.
/// </summary>
internal class TableEngine
{
    #region Methods

    internal static Table GetExerciseTable(ExerciseDto exercise)
    {
        var table = new Table
        {
            Expand = true,
        };

        table.AddColumn("Type");
        table.AddColumn("Start");
        table.AddColumn("End");
        table.AddColumn("Duration (Minutes)");
        table.AddColumn("Comments");

        table.AddRow(
            exercise.Type,
            exercise.DateStartString,
            exercise.DateEndString,
            exercise.DurationInMinutesString,
            exercise.Comments
            );

        return table;
    }

    internal static Table GetExercisesTable(IReadOnlyList<ExerciseDto> exercises)
    {
        var table = new Table
        {
            Caption = new TableTitle($"{exercises.Count} exercises found."),
            Expand = true,
        };

        table.AddColumn("ID");
        table.AddColumn("Start");
        table.AddColumn("End");
        table.AddColumn("Duration (Minutes)");
        table.AddColumn("Comments");
        table.AddColumn("Type");

        foreach (var x in exercises)
        {
            table.AddRow(
                x.Id.ToString(),
                x.DateStartString,
                x.DateEndString,
                x.DurationInMinutesString,
                x.Comments,
                x.Type);
        }

        return table;
    }

    #endregion
}
