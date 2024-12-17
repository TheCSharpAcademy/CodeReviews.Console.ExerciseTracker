using ExerciseTracker.API.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ExerciseTracker.Console.Services;

internal class ExerciseConsoleService
{
    public HttpClient _httpClient = new HttpClient();

    public async Task<Exercise> StartExercise()
    {
        Exercise exercise = new();
        exercise.StartTime = DateTime.Now;

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync("https://localhost:7298/api/Exercise/add", exercise);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("\nException: ");
            System.Console.WriteLine(ex.Message);
            System.Console.ReadLine();
        }

        return exercise;
    }

    public async Task<Exercise> EndExercise(string comment)
    {
        List<Exercise> allExercises = await GetExerciseHistory();
        Exercise lastEntry = allExercises[allExercises.Count - 1];

        lastEntry.EndTime = DateTime.Now;

        TimeSpan difference = lastEntry.EndTime - lastEntry.StartTime; //Calculating the difference
        lastEntry.Duration = difference;
        lastEntry.Comments = comment;

        try
        {
            HttpResponseMessage responseMessage = await _httpClient.PatchAsJsonAsync("https://localhost:7298/api/Exercise/update", lastEntry);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("\nException: ");
            System.Console.WriteLine(ex.Message);
            System.Console.ReadLine();
        }

        return lastEntry;
    }

    public async Task<List<Exercise>> GetExerciseHistory()
    {
        string exerciseJson = "";
        try
        {
            exerciseJson = await _httpClient.GetStringAsync("https://localhost:7298/api/Exercise/get");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("\nException: ");
            System.Console.WriteLine(ex.Message);
            System.Console.ReadLine();
        }

        return JsonSerializer.Deserialize<List<Exercise>>(exerciseJson);
    }
}
