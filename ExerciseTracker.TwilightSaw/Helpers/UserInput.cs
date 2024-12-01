using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.TwilightSaw.Helpers;

using System.Text.RegularExpressions;
using Spectre.Console;


public class UserInput
{

    public static string CreateRegex(string regexString, string messageStart, string messageError)
    {
        Regex regex = new Regex(regexString);
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
            new TextPrompt<string>($"[green]{messageStart} or 0 to exit: [/]"));
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
}