namespace ExerciseTracker.Forser.UI
{
    internal interface IUserInterface
    {
        DateTime GetEndTime(DateTime startTime);
        int GetExerciseId();
        string GetExerciseOption();
        DateTime GetStartTime();
    }
}