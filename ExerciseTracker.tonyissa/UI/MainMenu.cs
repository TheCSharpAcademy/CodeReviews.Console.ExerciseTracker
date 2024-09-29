using ExerciseTracker.tonyissa.Services;
using Spectre.Console;

namespace ExerciseTracker.tonyissa.UI;

public class MainMenuController
{
    private readonly ExerciseService _service;

    public MainMenuController(ExerciseService service)
    {
        _service = service;
    }

    public void StartMainMenu()
    {
        while (true)
        {
            var result = MenuSelection("What would you like to do?", MenuOptions.MainMenu);

            switch (result)
            {
                case "View log":
                    throw new NotImplementedException();
                case "Add session":
                    throw new NotImplementedException();
                case "Remove session":
                    throw new NotImplementedException();
                case "Update session":
                    throw new NotImplementedException();
                default:
                    return;
            }
        }
    }

    public static string MenuSelection(string title, string[] options)
    {
        var selection = AnsiConsole.Prompt<string>(
            new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(options)
        );

        return selection;
    }
}