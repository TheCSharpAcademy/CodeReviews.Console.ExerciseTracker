namespace ExerciseTracker.TwilightSaw.Model;

public class Exercise(string type, DateTime startTime, DateTime endTime, string? comments)
{
    public int Id { get; set; }

    public string Type { get; set; } = type;
    public DateTime StartTime { get; set; } = startTime;
    public DateTime EndTime { get; set; } = endTime;
    public TimeSpan Duration
    {
        get
        {
            var duration = EndTime.TimeOfDay - StartTime.TimeOfDay;
            return duration.Ticks >= 0 ? duration : duration.Add(TimeSpan.FromHours(24));
        }
    } 
    public string? Comments { get; set; } = comments;
}