using ExerciseTracker.tonyissa.Models;
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
            Console.Clear();
            var result = MenuSelection("What would you like to do?", MenuOptions.MainMenu);

            switch (result)
            {
                case "Log a new exercise shift":
                    CreateNewSession();
                    break;
                case "View all exercise shifts":
                    ViewAll();
                    break;
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

    public void ViewAll()
    {
        var log = _service.GetExerciseLog();
        var table = new Table { Title = new TableTitle("Log") };

        table.AddColumns("Number", "Start", "End", "Comments", "Duration (hours)");

        for (int i = 0; i < log.Count; i++)
        {
            var pos = (i + 1).ToString();
            var start = log[i].Start.ToString("g");
            var end = log[i].End.ToString("g");
            var comments = log[i].Comments ?? "";
            var duration = log[i].Duration.ToString("g");

            table.AddRow(pos, start, end, comments, duration);
        }

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void CreateNewSession()
    {
        var (start, end) = UserInput.GetDates();
        var comments = UserInput.GetComments();

        var session = new ExerciseSession
        {
            Start = start,
            End = end,
            Comments = comments,
            Duration = end - start
        };

        _service.AddExerciseSession(session);
        AnsiConsole.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}