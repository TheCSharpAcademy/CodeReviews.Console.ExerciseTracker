using ExerciseTracker.Models;

namespace ExerciseTracker.Utilities;

public static class ExerciseExtensions
{
    internal static Cardio CreateCardio()
    {
        DateTime start = GetExerciseStart();
        DateTime end = GetExerciseEnd(start);
        return new Cardio
        {
            DateStart = start,
            DateEnd = end,
            Duration = CalculateDuration(start, end),
            Comments = GetExerciseComments(),
            Distance = GetDistance()
        };
    }

    internal static Weights CreateWeights()
    {
        DateTime start = GetExerciseStart();
        DateTime end = GetExerciseEnd(start);
        return new Weights
        {
            DateStart = start,
            DateEnd = end,
            Duration = CalculateDuration(start, end),
            Comments = GetExerciseComments(),
            Sets = GetSets(),
            TotalWeight = GetTotalWeight()
        };
    }

    internal static DateTime GetExerciseEnd(DateTime start) => UserInput.DatePrompt("end", start);

    internal static TimeSpan CalculateDuration(DateTime dateStart, DateTime dateEnd) => dateEnd - dateStart;

    internal static string GetExerciseComments() => UserInput.CommentsPrompt();

    internal static DateTime GetExerciseStart(DateTime end = new DateTime(), bool update = false)
     => update ? UserInput.DatePrompt("start", end) : DateTime.Now;
    
    internal static double GetDistance() => UserInput.DistancePrompt();
    
    internal static int GetSets() => UserInput.SetsPrompt();

    internal static int GetTotalWeight() => UserInput.TotalWeightPrompt();
}