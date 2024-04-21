using System.Text.Json.Serialization;

namespace ExerciseTrackerUI.Models;

internal record class Exercise(
                               [property: JsonPropertyName("id")] int Id,
                               [property: JsonPropertyName("name")] string Name,
                               [property: JsonPropertyName("startDate")] DateTime StartDate,
                               [property: JsonPropertyName("endDate")] DateTime EndDate,
                               [property: JsonPropertyName("duration")] TimeSpan Duration,
                               [property: JsonPropertyName("comments")] string Comments);