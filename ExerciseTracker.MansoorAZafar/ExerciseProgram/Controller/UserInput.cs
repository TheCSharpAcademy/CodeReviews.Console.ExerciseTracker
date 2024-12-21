namespace ExerciseProgram.Controller;

using ExerciseLibrary.Utilities;
using ExerciseProgram.Model.ExerciseModel;

internal static class UserInput
{
    internal static T GetSelection<T>(Func<T, string>? alternateNames = null) where T: struct, Enum 
        => Utilities.GetSelection<T>
            (
                Enum.GetValues<T>(),
                "Choose your selection",
                alternateNames is not null ? alternateNames : null
            );

    internal static Exercise CreateExercise()
    {
        DateTime startTime = Utilities.GetInput<DateTime>("Enter a Starting Time (MM/DD/YY HH/mm/ss)");
        DateTime endTime = Utilities.GetInput<DateTime>("Enter an Ending Time (MM/DD/YY HH/mm/ss)", item => item >= startTime);
        TimeSpan duration = endTime - startTime;
        String comments = Utilities.GetInput<String>("Enter any comments, Don't leave it blank");
        
        return new Exercise(startTime, endTime, duration, comments);
    }

    internal static int GetId(Func<int, Exercise> func)
    => Utilities.GetInput<int>("Enter the ID or enter -1 to exit", item => func(item) is not null || item == -1);
}