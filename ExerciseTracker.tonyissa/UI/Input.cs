using Spectre.Console;

namespace ExerciseTracker.tonyissa.UI;

public static class UserInput
{
    public static (DateTime, DateTime) GetDates()
    {
        var start = AnsiConsole.Ask<DateTime>("Enter start date:");
        var end = AnsiConsole.Ask<DateTime>("Enter end date:");

        return (start, end);
    }

    public static string GetComments()
    {
        return AnsiConsole.Ask<string>("Enter any comments:");
    }
}