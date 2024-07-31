using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.ConsoleApp.Services;
using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.ConsoleApp.Views;

/// <summary>
/// Page which allows users to create an exercise entry.
/// </summary>
internal class CreateExercisePage : BasePage
{
    #region Constants

    private const string PageTitle = "Create Exercise";

    #endregion
    #region Methods

    internal static CreateExerciseRequest? Show(IReadOnlyList<ExerciseType> exerciseTypes)
    {
        WriteHeader(PageTitle);

        string dateTimeFormat = Constants.DateTimeFormat;

        var exerciseType = UserInputService.GetExerciseType($"Select the [blue]type[/] of exercise: ", exerciseTypes);
        if (exerciseType == null)
        {
            return null;
        }

        var startTime = UserInputService.GetExerciseStartDateTime(
            $"Enter the start date and time, format [blue]{dateTimeFormat}[/], or [blue]0[/] to cancel: ",
            dateTimeFormat);
        if (!startTime.HasValue)
        {
            return null;
        }

        var endTime = UserInputService.GetExerciseEndDateTime(
            $"Enter the end date and time, format [blue]{dateTimeFormat}[/], or [blue]0[/] to cancel: ",
            dateTimeFormat,
            startTime.Value);
        if (!endTime.HasValue)
        {
            return null;
        }

        var comments = UserInputService.GetBlankableString($"Enter any [blue]comments[/] (can be blank), or [blue]0[/] to cancel: ");
        if (comments is "0")
        {
            return null;
        }

        return new CreateExerciseRequest
        {
            DateStart = startTime.Value,
            DateEnd = endTime.Value,
            Duration = endTime.Value - startTime.Value,
            Comments = comments is null ? "" : comments,
            ExerciseType = exerciseType
        };
    }

    #endregion
}

