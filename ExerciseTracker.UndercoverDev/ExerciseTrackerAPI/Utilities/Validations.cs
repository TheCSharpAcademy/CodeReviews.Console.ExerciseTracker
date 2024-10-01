using System.Globalization;
using Spectre.Console;

namespace ExerciseTrackerAPI.Utilities;
public class Validations
{
    internal static string GetValidatedTimeInput(string prompt, string format, DateTime now, DateTime? startTime = null)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>($"{prompt} ({format}):")
                .Validate(input =>
                {
                    if (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedTime))
                        return ValidationResult.Error($"[red]Invalid date format. Please use {format}[/]");
                    if (parsedTime < now)
                        return ValidationResult.Error("[red]Time cannot be in the past[/]");
                    if (startTime.HasValue && parsedTime < startTime.Value)
                        return ValidationResult.Error("[red]End time must be after start time[/]");
                    return ValidationResult.Success();
                })
        );
    }
}