using System.Globalization;

namespace ExerciseTracker.Validation;

public class InputValidation
{
    public static bool IntValidation(string input)
    {
        if(int.TryParse(input, out int inputAsInt))
            return true;
        else
            return false;
    }

    public static bool IntValidation(string input, int max, int min)
    {
        if(int.TryParse(input, out int inputAsInt))
        {
            if(inputAsInt >= min && inputAsInt <= max)
                return true;          
        }
        return false;
    }

    public static bool DateValidation(string input)
    {
        if(DateTime.TryParseExact(input, "yyyy/MM/dd hh:mm", 
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime inputAsDate))
            return true;
        else
            return false;
    }

    public static bool DateValidation(string input, DateTime? startDate)
    {
        if(DateTime.TryParseExact(input, "yyyy/MM/dd hh:mm", 
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime inputAsDate))
            if (inputAsDate > startDate)
                return true;
        return false;
    }
}