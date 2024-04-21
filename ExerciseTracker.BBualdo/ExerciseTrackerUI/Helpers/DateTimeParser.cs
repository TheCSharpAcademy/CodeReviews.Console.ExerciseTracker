using System.Globalization;

namespace ExerciseTrackerUI.Helpers;

internal static class DateTimeParser
{
  public static DateTime Parse(string dateString)
  {
    return DateTime.ParseExact(dateString, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"));
  }
}