using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.ConsoleApp.Models;

/// <summary>
/// The required data to perform an update request for the Exercise object.
/// </summary>
internal class UpdateExerciseRequest
{
    #region Properties

    internal int Id { get; set; }

    internal DateTime DateStart { get; set; }

    internal DateTime DateEnd { get; set; }

    internal string Comments { get; set; } = string.Empty;

    internal ExerciseType ExerciseType { get; set; }

    #endregion
}
