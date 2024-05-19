namespace ExerciseTracker.Cactus.Util
{
    public class Validator
    {
        public static bool IsValidDate(string dateStr, out DateTime date)
        {

            if (DateTime.TryParseExact(dateStr, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidTime(string timeString, out TimeSpan timeSpan)
        {
            if (TimeSpan.TryParseExact(timeString, "hh\\:mm\\:ss", null, out timeSpan))
            {
                return true;
            }
            return false;
        }
    }
}
