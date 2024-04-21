namespace ExerciseTrackerUI.Models;

internal class ExerciseUpdateRequest
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public string? Comments { get; set; }

  public ExerciseUpdateRequest(int id, string? name, DateTime startDate, DateTime endDate, string? comments)
  {
    Id = id;
    Name = name;
    StartDate = startDate;
    EndDate = endDate;
    Comments = comments;
  }
}