namespace ExerciseTracker.ConsoleApp.Enums;

/// <summary>
/// Supported choices for all menu pages in the application.
/// </summary>
internal enum MenuChoice
{
    [System.ComponentModel.Description("Default")]
    Default,
    [System.ComponentModel.Description("Close application")]
    CloseApplication,
    [System.ComponentModel.Description("Close page")]
    ClosePage,
    [System.ComponentModel.Description("Log an exercise")]
    CreateExercise,
    [System.ComponentModel.Description("Delete an exercise")]
    DeleteExercise,
    [System.ComponentModel.Description("Update an exercise")]
    UpdateExercise,
    [System.ComponentModel.Description("View all exercises")]
    ViewExercises,
}
