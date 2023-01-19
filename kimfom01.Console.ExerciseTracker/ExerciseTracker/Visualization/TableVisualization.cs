using ConsoleTableExt;
using ExerciseTracker.Models;

namespace ExerciseTracker.Visualization;

public class TableVisualization : ITableVisualization
{
    public void DisplayTable(List<Exercise> exercises)
    {
        Console.Clear();
        ConsoleTableBuilder
            .From(exercises)
            .ExportAndWriteLine();
    }
}