using ExerciseTrackerUI.Helpers;
using ExerciseTrackerUI.Models;
using Spectre.Console;

namespace ExerciseTrackerUI;

internal static class UserInput
{
  internal static string GetName(string exerciseName = "exercise")
  {
    string name = AnsiConsole.Ask<string>($"Enter new [cyan1]name[/] for [cyan1]{exerciseName}[/] or type 0 to cancel: ");

    if (name == "0") return name;

    while (!ExerciseNameValidator.IsValid(name))
    {
      name = AnsiConsole.Ask<string>("Try again: ");
      if (name == "0") return name;
    }

    return name;
  }

  internal static string GetStartDate(string name)
  {
    string startDate = AnsiConsole.Ask<string>($"Enter [cyan1]date and time[/] when you started [fuchsia]{name}[/] or type 0 to cancel. Correct format: [cyan1](dd-MM-yyyy HH:mm)[/]: ");

    if (startDate == "0") return startDate;

    while (!DateTimeValidator.IsValid(startDate))
    {
      startDate = AnsiConsole.Ask<string>("Try again: ");
      if (startDate == "0") return startDate;
    }

    return startDate;
  }

  internal static string GetEndDate(string startDate, string name)
  {
    string endDate = AnsiConsole.Ask<string>($"Enter [cyan1]date and time[/] when you finished [fuchsia]{name}[/] or type 0 to cancel. Correct format: [cyan1](dd-MM-yyyy HH:mm)[/]: ");

    if (endDate == "0") return endDate;

    while (!DateTimeValidator.IsValid(endDate))
    {
      endDate = AnsiConsole.Ask<string>("Try again: ");
      if (endDate == "0") return endDate;
    }

    while (!DateTimeValidator.IsEndDateLater(startDate, endDate))
    {
      endDate = AnsiConsole.Ask<string>("Try again: ");
      if (endDate == "0") return endDate;
    }

    return endDate;
  }

  internal static int GetExerciseId(List<Exercise> exercises, string method)
  {
    int exerciseId = AnsiConsole.Ask<int>($"Enter [cyan1]Exercise ID[/] you want to {method} or type 0 to cancel: ");
    if (exerciseId == 0) return exerciseId;

    while (!exercises.Any(exercise => exercise.Id == exerciseId))
    {
      AnsiConsole.Markup("\n[red]There is no exercise with given ID.[/]\n");
      exerciseId = AnsiConsole.Ask<int>("Try again: ");
      if (exerciseId == 0) return exerciseId;
    }

    return exerciseId;
  }

  internal static string? GetComments(string exerciseName)
  {
    string? comments = AnsiConsole.Prompt(
      new TextPrompt<string?>($"Do you want to add some [cyan1]comments[/] for [cyan1]{exerciseName}[/]? If not leave empty or type 0 to cancel: ")
      .AllowEmpty());

    if (comments == "0") return comments;

    return comments;
  }
}