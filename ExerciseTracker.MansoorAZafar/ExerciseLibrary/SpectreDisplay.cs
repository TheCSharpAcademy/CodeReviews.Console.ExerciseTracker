namespace ExerciseLibrary.Display;
using Spectre.Console;

public static class Display 
{
    public static void Figlet(string title, String color="red", String justification = "center") 
    {
        Color colour = color.ToLower() switch 
        {
            "white" => Color.White,
            "blue" => Color.Blue,
            "black" => Color.Black,
            "yellow" => Color.Yellow,
            "green" => Color.Green,
            _ => Color.Red    
        };

        Justify justify = justification.ToLower() switch 
        {
            "left" => Justify.Left,
            "right" => Justify.Right,
            _ => Justify.Center
        };

        AnsiConsole.Write(
            new FigletText(title)
            .Justify(justify)
            .Color(colour)
        );
    }

    public static void DisplayListAsTable<T>(String[] headers, List<T> data)
    {
        Table table = new();

        foreach(String header in headers) {
            table.AddColumns(header);
        }

        foreach(var item in data) {
            List<String> row = [];

            foreach(var header in headers) {
                var property = typeof(T).GetProperty(header);
                row.Add(property.GetValue(item).ToString() ?? "N/A");
            }
            table.AddRow(row.ToArray());
        }

        AnsiConsole.Write(table);
        System.Console.WriteLine();
    }

    public static void DisplayHeader(String text, String justify = "center") {
        var heading = new Rule($"[red]{text}[/]");
        heading.Justify(justify.ToLower() switch {
            "left" => Justify.Left,
            "right" => Justify.Right,
            _ => Justify.Center
        });

        AnsiConsole.Write(heading);
        System.Console.WriteLine();
    }
}