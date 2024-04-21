namespace ExerciseTrackerUI.Models;

internal class ExerciseInsertRequest
{
  public string? Name { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public string? Comments { get; set; }

  public ExerciseInsertRequest(string? name, DateTime startDate, DateTime endDate, string? comments)
  {
    Name = name;
    StartDate = startDate;
    EndDate = endDate;
    Comments = comments;
  }
}