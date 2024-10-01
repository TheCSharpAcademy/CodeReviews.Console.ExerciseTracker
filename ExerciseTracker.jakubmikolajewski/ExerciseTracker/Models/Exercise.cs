using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.Models;
public class Exercise
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public DateOnly Date {  get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public TimeSpan Duration { get => EndTime - StartTime; set => _ = value; }
    public string Comments { get; set; }
}
