using Spectre.Console;
using System.Globalization;

namespace ExerciseTracker;

public class DateTimeValidator : IValidator
{
    public string DateFormat = "yyyy-MM-dd HH:mm";
    public DateTime StartDate { get; set; }

    public string ErrorMsg { get; set; } = "Date in an invalid format";

    public ValidationResult Validate(string? input)
    {
        if (!DateTime.TryParseExact(input, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        {
            return ValidationResult.Error("[red]The Date format must be (yyyy-MM-dd HH:mm).[/]");
        }
        else
        {
            StartDate = result;
            return ValidationResult.Success();
        }
    }
}