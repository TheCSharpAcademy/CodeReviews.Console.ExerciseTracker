using System.Text.Json.Serialization;

namespace ExerciseTracker.API.Models;

public class Exercise : BaseEntity
{
    [JsonPropertyName("startTime")]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("endTime")]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("duration")]
    public TimeSpan Duration { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }
}
