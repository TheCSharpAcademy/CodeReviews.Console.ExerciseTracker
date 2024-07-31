using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities;

/// <summary>
/// Database version of the Exercise object.
/// </summary>
[Table(nameof(Exercise))]
public class Exercise
{
    #region Properties

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime DateStart { get; set; }

    [Required]
    public DateTime DateEnd { get; set; }

    [Required]
    public TimeSpan Duration { get; set; }

    public string Comments { get; set; } = string.Empty;

    public int ExerciseTypeId { get; set; }

    public ExerciseType ExerciseType { get; set; }

    #endregion
}
