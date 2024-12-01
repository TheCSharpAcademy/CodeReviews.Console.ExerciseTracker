namespace ExerciseTracker.TwilightSaw.Model;

public class Exercise(DateTime startTime, DateTime endTime, TimeSpan duration, string? comments)
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; } = startTime;
    public DateTime EndTime { get; set; } = endTime;
    public TimeSpan Duration { get; set; } = duration;
    public string? Comments { get; set; } = comments;
}