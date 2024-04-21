using Spectre.Console;

namespace ExerciseTrackerUI.Helpers;

internal static class ExerciseNameValidator
{
  internal static bool IsValid(string name)
  {
    if (int.TryParse(name, out _))
    {
      AnsiConsole.Markup("\n[red]Name can't be numeric value.[/]\n");
      return false;
    }

    return true;
  }
}