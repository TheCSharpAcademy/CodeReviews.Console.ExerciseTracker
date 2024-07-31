namespace ExerciseTracker.ConsoleApp.Models;

/// <summary>
/// The required data to perform a create request for the ExerciseType object.
/// </summary>
internal class CreateExerciseTypeRequest
{
    #region Properties

    internal string Name { get; set; } = string.Empty;

    #endregion
}
