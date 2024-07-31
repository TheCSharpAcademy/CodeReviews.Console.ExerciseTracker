using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.ConsoleApp.Models;

/// <summary>
/// The required data to perform a create request for the Exercise object.
/// </summary>
internal class CreateExerciseRequest
{
    #region Properties

    internal DateTime DateStart { get; set; }

    internal DateTime DateEnd { get; set; }

    internal TimeSpan Duration { get; set; }

    internal string Comments { get; set; } = string.Empty;

    internal ExerciseType ExerciseType { get; set; }

    #endregion
}
