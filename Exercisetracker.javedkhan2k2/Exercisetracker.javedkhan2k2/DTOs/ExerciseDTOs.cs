using System.ComponentModel.DataAnnotations;
using Exercisetacker.Entities;

namespace Exercisetacker.DTOs;

public class ExerciseAddDto
{
    public DateTime DateStart { get; set; }
    public DateTime DateEnd {get;set;}
    public TimeSpan Duration {get;set;}
    public string Comments {get;set;}

    public Excercise ToExercise()
    {
        return new Excercise
        {
            DateStart = this.DateStart,
            DateEnd = this.DateEnd,
            Duration = this.Duration,
            Comments = this.Comments
        };
    }

}