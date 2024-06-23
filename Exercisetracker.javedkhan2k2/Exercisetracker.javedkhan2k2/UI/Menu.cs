using Spectre.Console;

namespace Exercisetacker.UI;

public class Menu
{
    public static string CancelOperation = $"[maroon]Go Back[/]";

    public string[] MainMenu = ["Cardios", "Joggings", "Exit"];
    public string[] JoggingMenu = ["View All Jogging Sessions", "Add Jogging Session", "Update Jogging Session", "Delete Jogging Session", CancelOperation];
    public string[] CardioMenu = ["View All Cardio Sessions", "Add Cardio Session", "Update Cardio Session", "Delete Cardio Session", CancelOperation];
    public string Title = "[yellow]Please Select An [blue]Action[/] From The Options Below[/]";
    internal string GetMainMenu()
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(Title)
                    .PageSize(10)
                    .AddChoices(MainMenu)
        );
    }

    internal string GetJoggingsMenu()
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(Title)
                    .PageSize(10)
                    .AddChoices(JoggingMenu)
        );
    }

    internal string GetCardiosMenu()
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(Title)
                    .PageSize(10)
                    .AddChoices(CardioMenu)
        );
    }

}