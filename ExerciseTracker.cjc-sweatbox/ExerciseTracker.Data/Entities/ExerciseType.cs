using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities;

/// <summary>
/// Database version of the ExerciseType object.
/// </summary>
[Table(nameof(ExerciseType))]
public class ExerciseType
{
    #region Properties

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<Exercise> Exercises { get; set; }

    #endregion
}
