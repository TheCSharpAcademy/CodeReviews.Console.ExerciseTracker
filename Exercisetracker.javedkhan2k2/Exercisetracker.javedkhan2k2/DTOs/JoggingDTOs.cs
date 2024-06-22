using System.ComponentModel.DataAnnotations;

namespace Exercisetacker.DTOs;

public class JoggingAddDto
{
    [Required]
    public DateTime DateStart { get; set; }
    [Required]
    public DateTime EndTime {get;set;}
    [Required]
    public TimeSpan Duration {get;set;}
    [Required]
    [MaxLength(255)]
    public string Comments {get;set;}

}