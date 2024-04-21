using System.ComponentModel.DataAnnotations;

namespace ExerciseTrackerAPI.Models;

public class Exercise
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required]
  public DateTime StartDate { get; set; }

  [Required]
  public DateTime EndDate { get; set; }

  public TimeSpan Duration => EndDate - StartDate;
  public string? Comments { get; set; }
}