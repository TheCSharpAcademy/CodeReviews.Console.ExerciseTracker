
using System.Globalization;
using Exercisetacker.DTOs;
using Exercisetacker.Entities;
using Exercisetacker.UI;
using Exercisetacker.Validators;
using Shiftlogger.UI.Constants;
using Spectre.Console;

namespace Exercisetacker;

internal class UserInput
{
    internal static ExerciseAddDto? GetNewExercise()
    {
        ExerciseAddDto exercise = new ExerciseAddDto();
        do
        {
            exercise.DateStart = GetDateInput("Enter Start date and time in [bold green](yyyy-MM-dd HH:mm:ss)[/] format.", "yyyy-MM-dd HH:mm:ss");
            if (exercise.DateStart == DateTime.MinValue) return null;

            exercise.DateEnd = GetDateInput("Enter End date and time in [bold green](yyyy-MM-dd HH:mm:ss)[/] format.", "yyyy-MM-dd HH:mm:ss");
            if (exercise.DateEnd == DateTime.MinValue) return null;

            if (ValidatorHelper.IsValidDateTimeInputs(exercise.ToExercise()))
            {
                exercise.Duration = exercise.DateEnd.Subtract(exercise.DateStart);
                break;
            }
            else
            {
                VisualizationEngine.DisplayDateTimeError();
            }

        } while (true);
        exercise.Comments = GetStringInput("Enter Comments for the Exercise Session");
        if(exercise.Comments == "") return null;

        return exercise;
    }

    internal static bool GetUpdateExercise(Excercise exercise)
    {
        do
        {
            exercise.DateStart = AnsiConsole.Confirm($"{Messages.GetStartDateUpdate(exercise.DateStart)}") ? GetDateInput(Messages.StartTime, Messages.TimeFormat) : exercise.DateStart;
            if (exercise.DateStart == DateTime.MinValue) return false;

            exercise.DateEnd = AnsiConsole.Confirm($"{Messages.GetEndDateUpdate(exercise.DateEnd)}") ? GetDateInput(Messages.EndTime, Messages.TimeFormat) : exercise.DateEnd;
            if (exercise.DateEnd == DateTime.MinValue) return false;

            if (ValidatorHelper.IsValidDateTimeInputs(exercise))
            {
                exercise.Duration = exercise.DateEnd.Subtract(exercise.DateStart);
                break;
            }
            else
            {
                VisualizationEngine.DisplayDateTimeError();
            }

        } while (true);
        exercise.Comments = AnsiConsole.Confirm(Messages.GetCommentsUpdate(exercise.Comments)) ? GetStringInput(Messages.Comments) : exercise.Comments;
        if(exercise.Comments == "") return false;

        return true;
    }

    private static string GetStringInput(string message)
    {
        string? userInput = AnsiConsole.Ask<string?>($"{message} Or Enter 0 to cancel:");
        while(!ValidatorHelper.IsValidComment(userInput))
        {
            userInput = AnsiConsole.Ask<string?>($"[bold]Invalid input [red]({userInput})[/][/].\n{message} Or Enter 0 to cancel:");
        }
        return userInput == "0" ? "" : userInput;
    }

    internal static DateTime GetDateInput(string message, string format)
    {
        string? userInput = AnsiConsole.Ask<string?>($"{message} Or Enter 0 to cancel:");
        while (!ValidatorHelper.IsValidDateInput(userInput, format))
        {
            userInput = AnsiConsole.Ask<string?>($"[bold]Invalid input [red]({userInput})[/][/].\n{message} Or Enter 0 to cancel:");
        }
        return userInput == "0" ? DateTime.MinValue : DateTime.ParseExact(userInput, format, new CultureInfo("en-US"));
    }

    internal static int GetIntInput()
    {
        int id = AnsiConsole.Ask<int>("Enter an Id from the table Or Enter 0 to Cancel: ");
        return id;
    }

}