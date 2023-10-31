namespace ExerciseTracker.wkktoria.Data.Models.Dtos;

public class ExerciseViewDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public TimeSpan Duration { get; set; }

    public string? Comment { get; set; }

    public override string ToString()
    {
        return $"Start Date: {StartDate:f}\tEnd Date: {EndDate:f}";
    }
}