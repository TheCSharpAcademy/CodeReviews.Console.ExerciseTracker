namespace ExerciseTracker.ConsoleApp.Models;

/// <summary>
/// The required data to perform an update request for the ExerciseType object.
/// </summary>
internal class UpdateExerciseTypeRequest
{
    #region Properties

    internal int Id { get; set; }

    internal string Name { get; set; } = string.Empty;

    #endregion
}
