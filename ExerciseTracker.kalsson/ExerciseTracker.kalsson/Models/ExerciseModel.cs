using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.kalsson.Models;

public class ExerciseModel
{
    [Key]
    public int Id { get; set; }
    public DateTime StartExercise { get; set; }
    public DateTime EndExercise { get; set; }
    public TimeSpan DurationExercise { get; set; }
    public string? ExerciseComment { get; set; }
}