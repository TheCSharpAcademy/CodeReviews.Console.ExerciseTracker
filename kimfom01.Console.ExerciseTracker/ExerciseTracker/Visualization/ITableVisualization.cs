using ExerciseTracker.Models;

namespace ExerciseTracker.Visualization;

public interface ITableVisualization
{
    public void DisplayTable(List<Exercise> exercises);
}