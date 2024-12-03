using System.Text.RegularExpressions;
using ExerciseTracker.TwilightSaw.Model;
using Spectre.Console;

namespace ExerciseTracker.TwilightSaw.Helper;

public class UserInput
{

    public static string CreateRegex(string regexString, string messageStart, string messageError)
    {
        var regex = new Regex(regexString);
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>($"[green]{messageStart} or 0 to exit:[/]")
                .Validate(value => regex.IsMatch(value)
                    ? ValidationResult.Success()
                    : ValidationResult.Error($"[red]{messageError}[/]")));
        Console.Clear();
        return input;
    }

    public static string Create(string messageStart)
    {
        var input = AnsiConsole.Prompt(
            new TextPrompt<string>($"[green]{messageStart} or 0 to exit: [/]")
                .AllowEmpty());
        Console.Clear();
        return input;
    }

    public static string CreateChoosingList(List<string> variants, string backVariant)
    {
        variants.Add(backVariant);
        return AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[blue]Please, choose an option from the list below:[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more categories[/]")
            .AddChoices(variants));
    }

    public static Exercise CreateExerciseChoosingList(List<Exercise> variants, string? backVariant)
    {
        variants.Add(new Exercise("",DateTime.Now, DateTime.Now, backVariant));
        return AnsiConsole.Prompt(new SelectionPrompt<Exercise>()
            .Title("[blue]Please, choose an option from the list below:[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more categories[/]")
            .UseConverter(
        exercise => exercise.Comments != backVariant ? $"Date: {exercise.StartTime.ToShortDateString()}\n " +
                                                           $" Start Time: {exercise.StartTime.TimeOfDay}, " +
                                                           $"End Time: {exercise.EndTime.TimeOfDay}, " +
                                                           $"Duration: {exercise.Duration}\n" +
                                                           $"  Comments: {exercise.Comments}" :
            "[red]Return[/]"
            )
            .AddChoices(variants));
    }

    public static string CreateUpdateChoosingList(List<string> variants, Exercise exercise, string backVariant)
    {
        var var = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[blue]Please, choose an option from the list below:[/]")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more categories[/]")
            .AddChoices(variants));

        var selectedIndex = variants.IndexOf(var);
        return selectedIndex switch
        {
            0 => "1",
            1 => "2",
            2 => "3",
            3 => "4",
            _ => "5"
        };
    }
}