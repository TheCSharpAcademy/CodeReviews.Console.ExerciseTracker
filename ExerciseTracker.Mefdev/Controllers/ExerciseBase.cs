using Spectre.Console;

namespace ExerciseTracker.Mefdev.Controllers;

public class ExerciseBase
{
    public ExerciseBase()
    {
    }

    protected void DisplayItemTable<T>(T item)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.DodgerBlue3)
            .Width(150);

        var properties = item.GetType().GetProperties();

        foreach (var prop in properties)
        {
            table.AddColumn(new TableColumn(prop.Name));
        }
        var rowValues = properties.Select(prop => prop.GetValue(item)?.ToString() ?? "N/A").ToArray();
        table.AddRow(rowValues);

        AnsiConsole.Write(table);
        AnsiConsole.Confirm("Press any key to continue... ");
    }

    protected void DisplayAllItems<T>(List<T> items)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.DodgerBlue3)
            .Width(150);

        var firstItem = items.FirstOrDefault();
        if (firstItem != null)
        {
            foreach (var prop in firstItem.GetType().GetProperties())
            {
                table.AddColumn(new TableColumn(prop.Name));
            }
        }
        if (items != null && items.Count() > 0)
        {
            foreach (var item in items)
            {
                var rowValues = item.GetType().GetProperties()
                    .Select(prop => prop.GetValue(item)?.ToString() ?? "N/A")
                    .ToArray();

                table.AddRow(rowValues);
            }
        }
        AnsiConsole.Write(table);
        AnsiConsole.Confirm("Press any key to continue... ");
    }

    protected bool ConfirmDeletion(string itemName)
    {
        var confirm = AnsiConsole.Confirm($"Are you sure you want to delete [red]{itemName}[/]?");
        return confirm;
    }

    protected void DisplayMessage(string message, string color = "yellow")
    {
        AnsiConsole.MarkupLine($"[{color}]{message}[/]");
    }
}