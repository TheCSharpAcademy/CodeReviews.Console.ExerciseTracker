using ExerciseTrackerUI.Helpers;
using ExerciseTrackerUI.Models;
using ExerciseTrackerUI.Services;

namespace ExerciseTrackerUI.Controllers;

internal static class ExercisesController
{
  public static async Task ShowExercises(HttpClient client)
  {
    List<Exercise>? exercises = await ExercisesService.GetExercises(client);
    ConsoleEngine.ShowExercisesTable(exercises);
  }

  public static async Task CreateExercise(HttpClient client)
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

    await ExercisesService.CreateExercise(client, exercise);
  }

  public static async Task UpdateExercise(HttpClient client)
  {
    List<Exercise>? exercises = await ExercisesService.GetExercises(client);

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

    await ExercisesService.UpdateExercise(client, id, updatedExercise);
  }

  public static async Task DeleteExercise(HttpClient client)
  {
    List<Exercise>? exercises = await ExercisesService.GetExercises(client);

    bool rowsPresent = ConsoleEngine.ShowExercisesTable(exercises);

    if (!rowsPresent || exercises == null) return;

    int id = UserInput.GetExerciseId(exercises, "delete");
    if (id == 0) return;

    await ExercisesService.DeleteExercise(client, id);
  }
}
