using Spectre.Console;
using System.Globalization;

namespace ExerciseTracker;

public class FutureDateTimeValidator : IValidator
{
    private readonly DateTimeValidator _dateTimeValidator;
    private readonly DateTime _startDate;

    public string ErrorMsg { get; set; } = "The End time must be later than the Start time.";
    public FutureDateTimeValidator(DateTimeValidator dateTimeValidator, DateTime startDate)
    {
        _dateTimeValidator = dateTimeValidator;
        _startDate = startDate;
    }

    public ValidationResult Validate(string? input)
    {
        if (_dateTimeValidator.Validate(input).Successful)
        {
            if (DateTime.ParseExact(input, _dateTimeValidator.DateFormat, CultureInfo.InvariantCulture) <= _startDate)
            {
                return ValidationResult.Error("[red]The End time must be later than the Start time.[/]");
            }
            return ValidationResult.Success();
        }
        return ValidationResult.Error("[red]Invalid date format. Please use (yyyy-MM-dd HH:mm).[/]");
    }
}