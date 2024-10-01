using Spectre.Console;

namespace ExerciseTracker.UserInterface;
internal class Validator
{
    public static DateOnly ValidateDate()
    {
        return AnsiConsole.Prompt(new TextPrompt<DateOnly>
            ("Choose the date (yyyy-MM-dd):")
            .ValidationErrorMessage("[red]Entry needs to be a date (yyyy-MM-dd)[/]\n"));
    }

    public static TimeOnly ValidateStartTime()
    {
        return AnsiConsole.Prompt(new TextPrompt<TimeOnly>
            ("Choose the start time:")
            .ValidationErrorMessage("[red]Entry needs to be a time (HH:mm:ss)[/]\n"));
    }

    public static TimeOnly ValidateEndTime(TimeOnly startTime)
    {
        return AnsiConsole.Prompt(new TextPrompt<TimeOnly>
            ("Choose the end time:")
            .ValidationErrorMessage("[red]Entry needs to be a time (HH:mm:ss)[/]\n"));
    }

    public static string ValidateString()
    {
        return AnsiConsole.Prompt(new TextPrompt<string>
            ("Enter the comment:"));
    }
}
