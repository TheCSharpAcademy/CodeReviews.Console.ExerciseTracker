using System.Globalization;

namespace Exercise_Tracker.Challenge;

public static class Validation
{
    public static DateTime? ValidateDate(string date)
    {
        DateTime dateResult;
        if(DateTime.TryParseExact(date, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateResult))
        {
            return dateResult;
        }
        return null;
    }

    public static bool ValidateId(List<Exercise> exercises, int id)
    {
        return exercises.Any(e => e.Id == id);
    }
}
