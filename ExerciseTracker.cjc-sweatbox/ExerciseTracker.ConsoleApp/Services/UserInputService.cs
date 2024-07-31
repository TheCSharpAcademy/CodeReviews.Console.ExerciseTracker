using System.Globalization;
using ExerciseTracker.ConsoleApp.Enums;
using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.Data.Entities;
using ExerciseTracker.Extensions;
using Spectre.Console;

namespace ExerciseTracker.ConsoleApp.Services;

/// <summary>
/// Helper service for getting valid user inputs of different types.
/// </summary>
internal static partial class UserInputService
{
    #region Constants

    // TODO: Validation Messages.

    #endregion
    #region Methods - Internal

    internal static bool GetConfirmation(string prompt, bool defaultValue = false)
    {
        return AnsiConsole.Confirm(prompt, defaultValue);
    }

    internal static DateTime? GetExerciseStartDateTime(string prompt, string format)
    {
        var dateTimeString = AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .ValidationErrorMessage($"[red]Invalid start time![/] Enter in the required format: [blue]{format}[/]")
            .Validate(input =>
            {
                return input == "0" || DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _)
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));

        return dateTimeString == "0" ? null : DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }

    internal static DateTime? GetExerciseEndDateTime(string prompt, string format, DateTime startDateTime)
    {
        var dateTimeString = AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .ValidationErrorMessage($"[red]Invalid end time![/] Enter in the required format: [blue]{format}[/]. End time must be after the start time.")
            .Validate(input =>
            {
                return input == "0" || IsValidExerciseEndDateTime(input, format, startDateTime)
                ? Spectre.Console.ValidationResult.Success()
                : Spectre.Console.ValidationResult.Error();
            }));

        return dateTimeString == "0" ? null : DateTime.ParseExact(dateTimeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }

    internal static ExerciseType GetExerciseType(string prompt, IReadOnlyList<ExerciseType> exerciseTypes)
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<ExerciseType>()
                .Title(prompt)
                .AddChoices(exerciseTypes)
                .UseConverter(c => c.Name)
                );
    }

    internal static string GetBlankableString(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .DefaultValue(string.Empty)
            .HideDefaultValue()
            );
    }

    internal static string GetString(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            );
    }

    internal static string GetString(string prompt, string defaultValue)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .DefaultValue(defaultValue)
            );
    }

    internal static SelectionChoice GetPageChoice(string prompt, IEnumerable<SelectionChoice> choices)
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<SelectionChoice>()
                .Title(prompt)
                .AddChoices(choices)
                .UseConverter(c => c.Name)
                );
    }

    internal static MenuChoice GetMenuChoice(string prompt, IEnumerable<MenuChoice> choices)
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<MenuChoice>()
                .Title(prompt)
                .AddChoices(choices)
                .UseConverter(c => c.GetDescription())
                );
    }

    #endregion
    #region Methods - Private

    private static bool IsValidExerciseEndDateTime(string input, string format, DateTime startDateTime)
    {
        bool isCorrectDateTimeFormat = DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDateTime);
        if (!isCorrectDateTimeFormat)
        {
            return false;
        }
        else if (endDateTime <= startDateTime)
        {
            return false;
        }

        return true;
    }

    #endregion
}

