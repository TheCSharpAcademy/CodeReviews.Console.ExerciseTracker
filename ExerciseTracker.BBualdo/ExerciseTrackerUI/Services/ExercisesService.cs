using ExerciseTrackerUI.Models;
using Spectre.Console;
using System.Text;
using System.Text.Json;

namespace ExerciseTrackerUI.Services;

internal static class ExercisesService
{
  internal static async Task<List<Exercise>?> GetExercises(HttpClient client)
  {
    List<Exercise>? exercises;
    Stream stream = await client.GetStreamAsync("https://localhost:7230/api/exercises");
    exercises = JsonSerializer.Deserialize<List<Exercise>>(stream);

    if (exercises == null)
    {
      return [.. exercises];
    }

    return exercises;
  }

  internal static async Task CreateExercise(HttpClient client, ExerciseInsertRequest exercise)
  {
    var json = JsonSerializer.Serialize(exercise);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpRequestMessage req = new()
    {
      Method = HttpMethod.Post,
      RequestUri = new Uri("https://localhost:7230/api/exercises"),
      Content = content,
    };

    HttpResponseMessage res = await client.SendAsync(req);

    if (!res.IsSuccessStatusCode) AnsiConsole.Markup("\n[red]Couldn't connect to ExerciseTrackerAPI server. [/]\n");
    else AnsiConsole.Markup("\n[green]Exercise added successfully![/]\n");

    return;
  }

  internal static async Task UpdateExercise(HttpClient client, int id, ExerciseUpdateRequest exercise)
  {
    var json = JsonSerializer.Serialize(exercise);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    HttpRequestMessage req = new()
    {
      Method = HttpMethod.Put,
      RequestUri = new Uri($"https://localhost:7230/api/exercises/{id}"),
      Content = content
    };

    HttpResponseMessage res = await client.SendAsync(req);

    if (!res.IsSuccessStatusCode) AnsiConsole.Markup("\n[red]Couldn't connect to ExerciseTrackerAPI server. [/]\n");
    else AnsiConsole.Markup("\n[green]Exercise updated successfully![/]\n");

    return;
  }

  internal static async Task DeleteExercise(HttpClient client, int id)
  {
    HttpRequestMessage req = new()
    {
      Method = HttpMethod.Delete,
      RequestUri = new Uri($"https://localhost:7230/api/exercises/{id}")
    };

    HttpResponseMessage res = await client.SendAsync(req);

    if (!res.IsSuccessStatusCode) AnsiConsole.Markup("\n[red]Couldn't connect to ExerciseTrackerAPI server. [/]\n");
    else AnsiConsole.Markup("\n[green]Exercise deleted successfully![/]\n");

    return;
  }
}