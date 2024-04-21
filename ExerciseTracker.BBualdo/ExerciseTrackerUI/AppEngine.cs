using ExerciseTrackerUI.Helpers;
using ExerciseTrackerUI.Models;
using ExerciseTrackerUI.Services;
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
        await ShowExercises();
        PressAnyKey();
        break;
      case "Create Exercise":
        await CreateExercise();
        PressAnyKey();
        break;
      case "Update Exercise":
        await UpdateExercise();
        PressAnyKey();
        break;
      case "Delete Exercise":
        await DeleteExercise();
        PressAnyKey();
        break;
      case "Quit":
        AnsiConsole.Clear();
        AnsiConsole.Markup("[cyan1]GOODBYE[/]");
        IsRunning = false;
        break;
    }
  }

  private async Task ShowExercises()
  {
    List<Exercise>? exercises = await ExercisesService.GetExercises(Client);
    ConsoleEngine.ShowExercisesTable(exercises);
  }

  private async Task CreateExercise()
  {
    string exerciseName = UserInput.GetName();
    if (exerciseName == "0") return;

    string startDateStr = UserInput.GetStartDate(exerciseName);
    if (startDateStr == "0") return;

    string endDateStr = UserInput.GetEndDate(startDateStr, exerciseName);
    if (endDateStr == "0") return;

    string? comments = UserInput.GetComments(exerciseName);
    if (comments == "0") return;

    DateTime startDate = DateTimeParser.Parse(startDateStr);
    DateTime endDate = DateTimeParser.Parse(endDateStr);

    ExerciseInsertRequest exercise = new(exerciseName, startDate, endDate, comments);

    await ExercisesService.CreateExercise(Client, exercise);
  }

  private async Task UpdateExercise()
  {
    List<Exercise>? exercises = await ExercisesService.GetExercises(Client);

    bool rowsPresent = ConsoleEngine.ShowExercisesTable(exercises);

    if (!rowsPresent || exercises == null) return;

    int id = UserInput.GetExerciseId(exercises, "update");
    if (id == 0) return;

    Exercise exercise = exercises.First(exercise => exercise.Id == id);
    ExerciseUpdateRequest updatedExercise = new(exercise.Id, exercise.Name, exercise.StartDate, exercise.EndDate, exercise.Comments);

    string name = UserInput.GetName(exercise.Name);
    if (name == "0") return;
    updatedExercise.Name = name;

    string startDate = UserInput.GetStartDate(name);
    if (startDate == "0") return;
    updatedExercise.StartDate = DateTimeParser.Parse(startDate);

    string endDate = UserInput.GetEndDate(startDate, name);
    if (endDate == "0") return;
    updatedExercise.EndDate = DateTimeParser.Parse(endDate);

    string? comments = UserInput.GetComments(name);
    if (comments == "0") return;
    updatedExercise.Comments = comments;

    await ExercisesService.UpdateExercise(Client, id, updatedExercise);
  }

  private async Task DeleteExercise()
  {
    List<Exercise>? exercises = await ExercisesService.GetExercises(Client);

    bool rowsPresent = ConsoleEngine.ShowExercisesTable(exercises);

    if (!rowsPresent || exercises == null) return;

    int id = UserInput.GetExerciseId(exercises, "delete");
    if (id == 0) return;

    await ExercisesService.DeleteExercise(Client, id);
  }

  private void PressAnyKey()
  {
    AnsiConsole.Markup("\n\n[cyan1]Press any key to continue.[/]\n");
    Console.ReadKey();
  }
}