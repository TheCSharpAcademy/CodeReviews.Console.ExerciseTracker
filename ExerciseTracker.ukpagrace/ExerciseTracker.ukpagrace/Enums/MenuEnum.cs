using System.ComponentModel;

namespace ExerciseTracker.ukpagrace.Enums
{
    public enum MenuEnum
    {
        [Description("View Exercise")]
        ViewExercise,
        [Description("View All Exercise")]
        ViewExercises,
        [Description("Add An Exercise")]
        AddExercise,
        [Description("Update An Exercise")]
        UpdateExercise,
        [Description("Delete An Exercise")]
        DeleteExercise,
        [Description("Exit Application")]
        Exit
    }
}
