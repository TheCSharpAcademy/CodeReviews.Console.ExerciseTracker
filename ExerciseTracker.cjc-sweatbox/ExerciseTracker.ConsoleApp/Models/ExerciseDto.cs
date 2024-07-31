using ExerciseTracker.Data.Entities;

namespace ExerciseTracker.ConsoleApp.Models;

/// <summary>
/// UI display version of the Shift model.
/// </summary>
internal class ExerciseDto
{
    #region Properties

    internal int Id { get; set; }

    internal DateTime DateStart { get; set; }

    internal string DateStartString => DateStart.ToString(Constants.DateTimeFormat);

    internal DateTime DateEnd { get; set; }

    internal string DateEndString => DateEnd.ToString(Constants.DateTimeFormat);

    internal TimeSpan Duration { get; set; }

    internal string DurationInMinutesString => Duration.TotalMinutes.ToString("F2");

    internal string Comments { get; set; } = string.Empty;

    internal ExerciseType ExerciseType { get; set; }

    internal string Type => ExerciseType.Name;

    #endregion
    #region Methods

    internal static ExerciseDto MapFrom(Exercise exercise)
    {
        return new ExerciseDto
        {
            Id = exercise.Id,
            DateStart = exercise.DateStart,
            DateEnd = exercise.DateEnd,
            Duration = exercise.Duration,
            Comments = exercise.Comments,
            ExerciseType = exercise.ExerciseType
        };
    }

    internal string ToSelectionChoice()
    {
        return $"{Type}: {DateStartString} - {DateEndString} ({DurationInMinutesString} Minutes)";
    }

    #endregion
}
