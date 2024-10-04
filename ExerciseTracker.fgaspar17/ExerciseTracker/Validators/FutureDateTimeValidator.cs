using Spectre.Console;
using System.Globalization;

namespace ExerciseTracker;

public class FutureDateTimeValidator : IValidator
{
    private readonly DateTimeValidator _dateTimeValidator;

    public string ErrorMsg { get; set; } = "The End time must be later than the Start time.";
    public FutureDateTimeValidator(DateTimeValidator dateTimeValidator)
    {
        _dateTimeValidator = dateTimeValidator;
    }

    public ValidationResult Validate(string? input)
    {
        if (_dateTimeValidator.Validate(input) == ValidationResult.Success())
        {
            if (DateTime.ParseExact(input, _dateTimeValidator.DateFormat, CultureInfo.InvariantCulture) <= _dateTimeValidator.StartDate)
            {
                return ValidationResult.Error("[red]The End time must be later than the Start time.[/]");
            }
            return ValidationResult.Success();
        }
        return ValidationResult.Error("[red]Invalid date format. Please use (yyyy-MM-dd HH:mm).[/]");
    }
}