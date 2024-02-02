using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.LONCHANICK.Models;

public class ExerciseRecord
{
    [Key]
    public int ID {get; set;}
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public TimeSpan Duration {get; set;}
    public string? Comments { get; set; }

    public override string ToString()
    {
        return $"{ID}\n{DateStart}\n{DateEnd}\n{Duration}\n{Comments}\n";
    }
}