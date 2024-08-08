namespace ExerciseTracker.ukpagrace.UserInterface
{
    public class Validation
    {
        public bool ValidateRange(DateTime firstRange, DateTime secondRange)
        {
            return firstRange > secondRange;
        }
    }
}
