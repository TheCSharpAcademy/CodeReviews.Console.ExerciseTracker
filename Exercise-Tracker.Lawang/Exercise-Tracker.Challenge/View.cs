using Spectre.Console;

namespace Exercise_Tracker.Challenge;

public static class View
{
    public static void RenderTitle(string title, Color textColor, Color borderColor, string header, string headerColor, BoxBorder borderStyle)
    {
        var panel = new Panel(new FigletText($"{title}").Color(textColor))
                   .BorderColor(borderColor)
                   .PadTop(1)
                   .PadBottom(1)
                   .Header(new PanelHeader($"[{headerColor} bold]{header}[/]"))
                   .Border(borderStyle)
                   .Expand();

        AnsiConsole.Write(panel);
    }

    public static void RenderResult(string title, string color, Color borderColor)
    {
        var panel = new Panel(new Markup($"[{color} bold]{title}[/]"))
                           .BorderColor(borderColor)
                           .PadTop(1)
                           .PadBottom(1)
                           .Header(new PanelHeader("[blue3 bold]RESULT[/]"))
                           .Border(BoxBorder.Rounded)
                           .Expand();

        AnsiConsole.Write(panel);
    }
    public static void RenderTable(List<Exercise> exercises, Color Aqua)
    {
        if (exercises.Count() == 0)
        {
            Panel panel = new Panel(new Markup("[red bold]CONTACT IS EMPTY![/]"))
                .Border(BoxBorder.Heavy)
                .BorderColor(Color.IndianRed1_1)
                .Padding(1, 1, 1, 1)
                .Header("Result");

            AnsiConsole.Write(panel);
            return;
        }

        var table = new Table()
            .Border(TableBorder.Rounded)
            .Expand()
            .BorderColor(Aqua)
            .ShowRowSeparators();

        table.AddColumns(new TableColumn[]
        {
           new TableColumn("[darkgreen bold]Id[/]").Centered(),
           new TableColumn("[darkcyan bold]Start Date [/]").Centered(),
           new TableColumn("[red1 bold]End Date [/]").Centered(),
           new TableColumn("[darkcyan bold]Span[/]").Centered(),
           new TableColumn("[darkgreen bold]Comment[/]").Centered()
        });

        foreach (var exercise in exercises)
        {
            table.AddRow(
                new Markup($"[cyan1]{exercise.Id}[/]").Centered(),
                new Markup($"[turquoise2]{exercise.DateStart.ToString("D")}[/]").Centered(),
                new Markup($"[red]{exercise.DateEnd.ToString("D")}[/]").Centered(),
                new Markup($"[yellow]{exercise.Duration.Days}[/]").Centered(),
                new Markup($"[turquoise2]{exercise.Comments}[/]").Centered()

            );
        }

        AnsiConsole.Write(table);
    }

    public static void ShowDateInstruction()
    {
        var panel = new Panel(new Markup("Please enter a [green]Date[/] in (dd/MM/yy) format (e.g., [cyan]30/11/24[/] or [cyan]01/01/22[/]): \n\t\t[grey bold](press '0' to go back to Menu.)[/]"))
                .Header("[bold cyan]Date Input[/]", Justify.Center)
                .Padding(1, 1, 1, 1)
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Blue3);

        // Render the panel
        AnsiConsole.Write(panel);
    }
}
