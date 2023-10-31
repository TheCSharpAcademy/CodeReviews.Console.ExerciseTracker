namespace ExerciseTracker.wkktoria;

public static class Validation
{
    public static bool IsStartDateBeforeEndDate(DateTime startDate, DateTime endDate)
    {
        return startDate < endDate;
    }
}