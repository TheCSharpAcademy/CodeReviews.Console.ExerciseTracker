using Spectre.Console;

namespace ExerciseTracker.ConsoleApp.Views;

/// <summary>
/// The base class for any page view.
/// </summary>
internal abstract class BasePage
{
    #region Constants

    protected static readonly string PromptTitle = "Select an [blue]option[/]...";

    private static readonly Rule DividerLine = new Rule().RuleStyle("blueviolet").LeftJustified();

    #endregion
    #region Methods

    protected static void WriteFooter()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Markup($"Press any [blue]key[/] to continue...");
        Console.ReadKey();
    }

    protected static void WriteHeader(string pageTitle)
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(DividerLine);
        AnsiConsole.MarkupLine($"[bold blueviolet]{Constants.ApplicationTitle}[/]: [slateblue3]{pageTitle}[/]");
        AnsiConsole.Write(DividerLine);
        AnsiConsole.WriteLine();
    }

    #endregion
}
