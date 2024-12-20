using System.Globalization;
using ExerciseTracker.Models;

namespace ExerciseTracker.Utilities;

public static class Validator
{
    private const string DateFormat = "yyyy-MM-dd HH:mm";

    internal static bool IsDateFormatValid(string date)
    {
        return DateTime.TryParseExact(
            date,
            DateFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out _);
    }

    internal static bool IsIdValid<T>(int input, List<T> exercises) where T : Exercise =>
        exercises.Any(exercise => exercise.Id == input);

    internal static bool IsStartDateValid(DateTime startDate, DateTime endDate)
        => startDate < endDate;

    internal static bool IsEndDateValid(DateTime startDate, DateTime endDate)
        => endDate > startDate;

    internal static bool IsDateDurationValid(DateTime startDate, DateTime endDate)
    {
        TimeSpan duration = ExerciseExtensions.CalculateDuration(startDate, endDate);
        return duration.TotalHours < 24;
    }

    internal static bool IsDistanceValid(string distance) =>
        !string.IsNullOrWhiteSpace(distance) &&
        double.TryParse(distance, out double choice) &&
        choice >= 0;
    
    internal static bool IsNumberValid(string input) =>
        !string.IsNullOrWhiteSpace(input) &&
        int.TryParse(input, out int choice) &&
        choice >= 0;
}