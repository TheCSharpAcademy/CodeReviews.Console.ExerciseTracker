using Spectre.Console;
using ExerciseTracker.Models;

namespace ExerciseTracker.UserInterface;
internal class Presentation
{
    public static void ShowTable(List<Exercise> exerciseList, string title)
    {
        Table table = new();
        string[] columns = ["Id", "Date", "StartTime", "EndTime", "Duration", "Comments"];
        table.Title = new TableTitle(title, style: "underline yellow");
        table.AddColumns(columns);

        exerciseList.ForEach(exercise =>
            table.AddRow($"{exercise.Id}", 
            $"{exercise.Date}",
            $"{exercise.StartTime}",
            $"{exercise.EndTime}",
            $"{exercise.Duration}",
            $"{exercise.Comments}"));

        AnsiConsole.Write(table);
    }
}
