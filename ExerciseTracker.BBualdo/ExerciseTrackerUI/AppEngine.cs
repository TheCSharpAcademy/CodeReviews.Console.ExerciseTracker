using ExerciseTrackerUI.Controllers;
using Spectre.Console;

namespace ExerciseTrackerUI;

internal class AppEngine
{
  internal bool IsRunning { get; set; }
  private HttpClient Client { get; set; }

  public AppEngine()
  {
    IsRunning = true;
    Client = new();
    Client.DefaultRequestHeaders.Clear();
    Client.DefaultRequestHeaders.Add("Accept", "application/json");
  }

  internal async Task MainMenu()
  {
    ConsoleEngine.ShowTitle();

    string choice = ConsoleEngine.GetChoiceSelector("What you would like to do?", ["Show Exercises", "Create Exercise", "Update Exercise", "Delete Exercise", "Quit"]);

    switch (choice)
    {
      case "Show Exercises":
        await ExercisesController.ShowExercises(Client);
        PressAnyKey();
        break;
      case "Create Exercise":
        await ExercisesController.CreateExercise(Client);
        PressAnyKey();
        break;
      case "Update Exercise":
        await ExercisesController.UpdateExercise(Client);
        PressAnyKey();
        break;
      case "Delete Exercise":
        await ExercisesController.DeleteExercise(Client);
        PressAnyKey();
        break;
      case "Quit":
        AnsiConsole.Clear();
        AnsiConsole.Markup("[cyan1]GOODBYE[/]");
        IsRunning = false;
        break;
    }
  }

  private void PressAnyKey()
  {
    AnsiConsole.Markup("\n\n[cyan1]Press any key to continue.[/]\n");
    Console.ReadKey();
  }
}