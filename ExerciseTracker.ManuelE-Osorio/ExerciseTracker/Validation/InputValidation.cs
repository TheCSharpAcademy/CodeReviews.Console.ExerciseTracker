using System.Globalization;

namespace ExerciseTracker.Validation;

public class InputValidation
{
    public static bool IntValidation(string input, out int inputAsInt)
    {
        if(int.TryParse(input, out inputAsInt))
            return true;
        else
            return false;
    }

    public static bool IntValidation(string input, int max, int min, out int inputAsInt)
    {
        if(int.TryParse(input, out inputAsInt))
        {
            if(inputAsInt >= min && inputAsInt <= max)
                return true;          
        }
        return false;
    }

    public static bool DateValidation(string input, out DateTime date)
    {
        if(DateTime.TryParseExact(input, "yyyy/MM/dd hh:mm", 
            CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            return true;
        else
            return false;
    }

    public static bool DateValidation(string input, DateTime? startDate, out DateTime date)
    {
        if(DateTime.TryParseExact(input, "yyyy/MM/dd hh:mm", 
            CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            if (date > startDate)
                return true;
        return false;
    }
}