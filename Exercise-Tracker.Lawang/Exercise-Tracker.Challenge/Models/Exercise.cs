using System.ComponentModel.DataAnnotations;


namespace Exercise_Tracker.Challenge;
public class Exercise
{
    [Key]
    public int Id { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public TimeSpan Duration => DateEnd - DateStart;
    public string Comments { get; set; } = null!;
}
