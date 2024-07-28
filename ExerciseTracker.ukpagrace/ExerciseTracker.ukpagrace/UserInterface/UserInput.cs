using System.Globalization;
using Spectre.Console;

namespace ExerciseTracker.ukpagrace.UserInterface
{
    public class UserInput
    {
        public DateTime GetStartDate()
        {
            var input = AnsiConsole.Ask<string>("[blue]Input your start time in the format of YYYY-MM-DD HH:MM am/pm[/]");

            DateTime startDate;
            while (!DateTime.TryParseExact(input, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                input = AnsiConsole.Ask<string>("[red]Start Date should be in the format of YYYY-MM-DD HH:MM am/pm[/]");
            }
            return startDate;
        }

        public DateTime GetEndDate()
        {
            var input = AnsiConsole.Ask<string>("[blue]Input your end time in the format of YYYY-MM-DD HH:MM am/pm[/]");

            DateTime endDate;
            while (!DateTime.TryParseExact(input, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                input = AnsiConsole.Ask<string>("[red]End Date should be in the format of YYYY-MM-DD HH:MM am/pm[/]");
            }
            return endDate;
        }

        public string DateInput(string filterFormat)
        {
            var input = AnsiConsole.Ask<string>($"[blue]Input your date in the format of {filterFormat}[/]");

            DateTime date;
            while (!DateTime.TryParseExact(input, filterFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                input = AnsiConsole.Ask<string>($"[blue]Date should be in the format of {filterFormat}[/]");
            }
            return date.ToString(filterFormat);
        }
        public bool ConfirmAction(string message)
        {
            if (!AnsiConsole.Confirm($"[blue]{message}[/]"))
            {
                AnsiConsole.MarkupLine("Ok... :(");
                return false;
            }

            return true;
        }

        public int GetNumberInput(string message)
        {

            var input = AnsiConsole.Ask<string>($"[blue]{message}[/]");

            while (!int.TryParse(input, out _) && Convert.ToInt32(input) < 0)
            {
                input = AnsiConsole.Ask<string>("[blue]Enter a valid input[/]");
            }
            return Convert.ToInt32(input);
        }



        public string GetStringInput()
        {

            return AnsiConsole.Prompt(
                new TextPrompt<string>("[green]Comment?[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]Comment Should not be empty[/]")
                    .Validate(text =>
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            return ValidationResult.Error("Input a comment");
                        }
                        return ValidationResult.Success();
                    })
            );
        }

    }
}
