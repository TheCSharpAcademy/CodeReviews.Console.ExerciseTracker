using ExerciseTrackerUI.Models;
using Spectre.Console;

namespace ExerciseTrackerUI;

internal static class ConsoleEngine
{
  internal static string GetChoiceSelector(string title, string[] choices)
  {
    SelectionPrompt<string> prompt = new SelectionPrompt<string>()
                                     .Title(title)
                                     .AddChoices(choices)
                                     .HighlightStyle(Color.Cyan1);

    string choice = AnsiConsole.Prompt(prompt);

    return choice;
  }

  internal static bool ShowExercisesTable(List<Exercise>? exercises)
  {
    if (exercises == null)
    {
      AnsiConsole.Markup("[red]Exercises not found.[/] Try to create one first.");
      return false;
    }

    Table table = new();
    table.Title("EXERCISES");
    table.AddColumn(new TableColumn("[cyan1]ID[/]"));
    table.AddColumn(new TableColumn("[cyan1]Name[/]"));
    table.AddColumn(new TableColumn("[cyan1]Start Date[/]"));
    table.AddColumn(new TableColumn("[cyan1]End Date[/]"));
    table.AddColumn(new TableColumn("[cyan1]Duration[/]"));
    table.AddColumn(new TableColumn("[cyan1]Comments[/]"));

    foreach (Exercise exercise in exercises)
    {
      table.AddRow(exercise.Id.ToString(), exercise.Name, exercise.StartDate.ToString("dd-MM-yyyy HH:mm"), exercise.EndDate.ToString("dd-MM-yyyy HH:mm"), exercise.Duration.TotalMinutes.ToString() + " minutes", exercise.Comments ?? "");
    }

    AnsiConsole.Write(table);
    return true;
  }

  internal static void ShowTitle()
  {
    AnsiConsole.Clear();

    Rule rule = new("Exercise Tracker");
    rule.Centered().HeavyBorder().Style = new Style(Color.Cyan1);

    AnsiConsole.Write(rule);
  }
}