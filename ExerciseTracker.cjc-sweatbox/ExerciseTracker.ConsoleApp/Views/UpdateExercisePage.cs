using ExerciseTracker.ConsoleApp.Engines;
using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.ConsoleApp.Services;
using ExerciseTracker.Data.Entities;
using Spectre.Console;

namespace ExerciseTracker.ConsoleApp.Views;

/// <summary>
/// Page which allows users to update an exercise entry.
/// </summary>
internal class UpdateExercisePage : BasePage
{
    #region Constants

    private const string PageTitle = "Update Exercise";

    #endregion
    #region Methods

    internal static UpdateExerciseRequest? Show(ExerciseDto exercise, IReadOnlyList<ExerciseType> exerciseTypes)
    {
        WriteHeader(PageTitle);

        // Show user the what is being updated.
        var table = TableEngine.GetExerciseTable(exercise);
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();

        string dateTimeFormat = Constants.DateTimeFormat;

        var type = exercise.ExerciseType;
        if (UserInputService.GetConfirmation("Update exercise type?"))
        {
            type = UserInputService.GetExerciseType($"Select the [blue]type[/] of exercise: ", exerciseTypes);
        }
        if (type == null)
        {
            return null;
        }

        DateTime? startTime = exercise.DateStart;
        if (UserInputService.GetConfirmation("Update start date and time?"))
        {
            startTime = UserInputService.GetExerciseStartDateTime(
                $"Enter the start date and time, format [blue]{dateTimeFormat}[/], or [blue]0[/] to cancel: ",
                dateTimeFormat);
        }
        if (!startTime.HasValue)
        {
            return null;
        }

        DateTime? endTime = exercise.DateEnd;
        if (UserInputService.GetConfirmation("Update end date and time?"))
        {
            endTime = UserInputService.GetExerciseEndDateTime(
                $"Enter the end date and time, format [blue]{dateTimeFormat}[/], or [blue]0[/] to cancel: ",
                dateTimeFormat,
                startTime.Value);

        }
        if (!endTime.HasValue)
        {
            return null;
        }

        var comments = exercise.Comments;
        if (UserInputService.GetConfirmation("Update comments?"))
        {
            comments = UserInputService.GetBlankableString($"Enter any [blue]comments[/] (can be blank), or [blue]0[/] to cancel: ");
        }
        if (comments is "0")
        {
            return null;
        }

        return new UpdateExerciseRequest
        {
            Id = exercise.Id,
            DateStart = startTime.Value,
            DateEnd = endTime.Value,
            Comments = comments,
            ExerciseType = type
        };
    }

    #endregion
}

