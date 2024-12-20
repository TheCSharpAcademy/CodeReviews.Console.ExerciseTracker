using System.Globalization;
using Spectre.Console;

namespace ExerciseTracker.Utilities;

public static class Util
{
    private const string DateFormat = "yyyy-MM-dd HH:mm";

    internal static DateTime ParseDateWithFormat(string date)
    {
        return DateTime.TryParseExact(
                date,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime formattedDate)
                ? formattedDate
                : default;
    }

    internal static void AskUserToContinue()
    {
        AnsiConsole.Markup("Press any key to continue...");
        Console.ReadKey();
    }

    internal static bool ReturnToMenu()
    {
        AnsiConsole.MarkupLine("Type '[bold yellow]0[/]' to exit or any other key to continue...");
        var answer = Console.ReadLine();
        return answer == "0";
    }

    internal static bool SessionsAvailable<T>(List<T> exercises) where T : class
        => exercises.Count > 0;


    internal static void DisplayNoSessionsMessage(string exerciseType)
    {
        AnsiConsole.MarkupLine($"[bold red]No {exerciseType} sessions found.[/]");
        AskUserToContinue();
    }
}