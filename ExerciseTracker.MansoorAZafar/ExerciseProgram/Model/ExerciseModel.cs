using System.Linq.Expressions;

namespace ExerciseProgram.Model.ExerciseModel;

public class Exercise 
{
    public static String[] headers = ["Id", "DateStart", "DateEnd", "Duration", "Comments"];
    public int Id {get; set; }
    public DateTime? DateStart {get; set;}
    public DateTime? DateEnd {get; set;}
    public TimeSpan? Duration {get; set;}
    public String? Comments {get; set;}

    public Exercise() {}
    public Exercise(int id)
    {
        this.Id = id;
    }

    public Exercise(DateTime start, DateTime end, TimeSpan duration, String comments)
    {
        this.DateStart = start;
        this.DateEnd = end;
        this.Duration = duration;
        this.Comments = comments;
    }

    public Exercise(DateTime start, DateTime end, TimeSpan duration)
    {
        this.DateStart = start;
        this.DateEnd = end;
        this.Duration = duration;
    }

    public void Update(Exercise other)
    {
        this.DateEnd = other.DateEnd;
        this.DateStart = other.DateStart;
        this.Comments = other.Comments;
    }
}