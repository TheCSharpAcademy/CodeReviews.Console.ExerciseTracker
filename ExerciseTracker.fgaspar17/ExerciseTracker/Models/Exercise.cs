using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker;

public class Exercise
{
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    [NotMapped]
    public TimeSpan Duration { get => DateEnd - DateStart; }
    public string? Comments { get; set; }
}