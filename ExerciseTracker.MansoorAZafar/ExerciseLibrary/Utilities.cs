namespace ExerciseLibrary.Utilities;

using Spectre.Console;

public static class Utilities 
{
    public static T GetSelection<T>(T[] enumerationValues,
                                    String title,
                                    Func<T, String>? alternateNames = null) where T: struct 
    => AnsiConsole.Prompt<T>(
          new SelectionPrompt<T>()
          .Title(title)
          .PageSize(15)
          .AddChoices<T>(enumerationValues)
          .UseConverter<T>(item => alternateNames != null 
                          ? alternateNames(item) : item.ToString() ?? "N/A") 
       );
    

    public static void PressKeyToContinue()
    {
        System.Console.WriteLine("\nPress any key to continue...");
        System.Console.ReadKey();
    }

    public static T GetInput<T>(String title, Func<T, bool>? validator = null) 
    => AnsiConsole.Prompt(
            new TextPrompt<T>(title)
                .Validate(
                    (item) => validator is not null ? validator(item) switch 
                        {
                            true => ValidationResult.Success(),
                            _ => ValidationResult.Error("Invalid Input")
                        } : ValidationResult.Success()
                )
        );
}