using ExerciseTracker.Models;
using Spectre.Console;

namespace ExerciseTracker.Utilities;

public static class UserInput
{
    internal static DateTime DatePrompt(string text, DateTime exerciseDate)
    {
        string exerciseDateFormatted = exerciseDate.ToString("yyyy-MM-dd HH:mm");
        var date = AnsiConsole.Prompt(
            new TextPrompt<string>($"Enter [bold yellow]{text}[/] date/time in format [green]'yyyy-MM-dd HH:mm'[/].")
                .Validate(input =>
                {
                    if (!Validator.IsDateFormatValid(input))
                        return ValidationResult.Error(
                            "[bold red]Invalid date. Enter a date/time in format [green]'yyyy-MM-dd HH:mm'[/].[/]");

                    DateTime parsedDate = Util.ParseDateWithFormat(input);

                    if (text == "start")
                        if (!Validator.IsStartDateValid(parsedDate, exerciseDate))
                            return ValidationResult.Error(
                                $"[Bold red]Enter a date before the end date. [/][blue]End: {exerciseDateFormatted}[/]");
                        else if (!Validator.IsDateDurationValid(parsedDate, exerciseDate))
                            return ValidationResult.Error(
                                $"[Bold red]Enter a date from the previous 24 hours. [/][blue]Start: {exerciseDateFormatted}[/] ");

                    if (text == "end")
                        if (!Validator.IsEndDateValid(exerciseDate, parsedDate))
                            return ValidationResult.Error(
                                $"[Bold red]Enter a date after the start date. [/][blue]Start: {exerciseDateFormatted}[/]");
                        else if (!Validator.IsDateDurationValid(exerciseDate, parsedDate))
                            return ValidationResult.Error(
                                $"[Bold red]Enter a date within the next 24 hours. [/][blue]Start: {exerciseDateFormatted}[/] ");

                    return ValidationResult.Success();
                }));
        return Util.ParseDateWithFormat(date);
    }

    internal static string CommentsPrompt()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>("Enter exercise comments: "));
    }

    internal static int IdPrompt<T>(List<T> exercises) where T : Exercise
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter exercise ID: ")
                .Validate(input =>
                    Validator.IsIdValid(input, exercises)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Invalid ID. Please enter ID From table![/]"
                        )));
        return input;
    }

    internal static double DistancePrompt()
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter cardio distance: ")
                .Validate(input =>
                    Validator.IsDistanceValid(input)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[bold red]Invalid cardio distance. Please enter a valid postive number![/]")
                ));
        return double.Parse(input);
    }

    internal static int SetsPrompt()
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter number of sets: ")
                .Validate(input =>
                    Validator.IsNumberValid(input) 
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[bold red]Invalid number of sets. Please enter a valid number![/]")
                ));
        return int.Parse(input);
    }

    internal static int TotalWeightPrompt()
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter total weight: ")
                .Validate(input =>
                    Validator.IsNumberValid(input)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[bold red]Invalid total weight. Please enter a valid number![/]")));
        
        return int.Parse(input);
    }
}