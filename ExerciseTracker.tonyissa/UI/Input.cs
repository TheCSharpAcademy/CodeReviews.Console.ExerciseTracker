using ExerciseTracker.tonyissa.Models;
using Spectre.Console;

namespace ExerciseTracker.tonyissa.UI;

public static class UserInput
{
    public static string GetMenuSelection(string[] options)
    {
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What would you like to do?")
                .AddChoices(options)
        );

        return selection;
    }

    public static ExerciseSession GetSessionFromId(List<ExerciseSession> log)
    {
        var id = AnsiConsole.Ask<int>("Enter the ID of the entry");
        var session = log.Find(s => s.Id == id);

        if (session == null)
        {
            AnsiConsole.MarkupLine("[red]Invalid selection[/]");
            return GetSessionFromId(log);
        }

        return session;
    }

    public static ExerciseSession GetNewSession(ExerciseSession? oldSession)
    {
        var (start, end) = GetDates();
        var comments = GetComments();

        var session = oldSession ?? new ExerciseSession();

        session.Start = start;
        session.End = end;
        session.Comments = comments;
        session.Duration = end - start;

        return session;
    }
    public static (DateTime, DateTime) GetDates()
    {
        var start = AnsiConsole.Ask<DateTime>("Enter start date:");
        var end = AnsiConsole.Ask<DateTime>("Enter end date:");

        return (start, end);
    }

    public static string GetComments()
    {
        return AnsiConsole.Ask<string>("Enter any comments:");
    }
}