using Spectre.Console;
using System.Globalization;

namespace ExerciseTrackerUI.Helpers;

internal static class DateTimeValidator
{
  internal static bool IsValid(string date)
  {
    if (!DateTime.TryParseExact(date, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _))
    {
      AnsiConsole.Markup("\n[red]Invalid date.[/] Must be in format [cyan1]dd-MM-yyyy hh:mm[/]. \n");
      return false;
    }

    return true;
  }

  internal static bool IsEndDateLater(string startDate, string endDate)
  {
    DateTime start = DateTime.ParseExact(startDate, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"));
    DateTime end = DateTime.ParseExact(endDate, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"));

    if (start > end)
    {
      AnsiConsole.Markup($"\n[red]End date must be later than {startDate}.[/]\n");
      return false;
    }

    return true;
  }
}