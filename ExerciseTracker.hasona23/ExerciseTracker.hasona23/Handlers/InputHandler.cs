using System.Globalization;
using ExerciseTracker.hasona23.Models;
using Spectre.Console;

namespace ExerciseTracker.hasona23.Handlers;

public class InputHandler
{
    private const string DateFormat = "dd/MM/yyyy";
    private const string TimeFormat = "HH:mm";
    public Exercise SelectExercise(List<Exercise> exercises)
    {
        var selectionPrompt = new SelectionPrompt<Exercise>()
            .Title("[yellow]Choose an Exercise: [/]")
            .AddChoices(exercises)
            .HighlightStyle(new Style(Color.Yellow));
      
        return AnsiConsole.Prompt(selectionPrompt);
    }

    public ExerciseCreate CreateExercise()
    {
        string? description = GetDescription();
        DateTime day =  GetDay();
        DateTime start = GetStartTime(day);
        DateTime end = GetEndTime(day,start);
        return new ExerciseCreate(description,start,end);
    }
    
    public DateTime GetStartTime(DateTime day)
    {
        DateTime start ;
        do
        {
            var startStr =  AnsiConsole.Prompt(new TextPrompt<string?>($"[yellow]Enter a start time ({TimeFormat}): [/]").PromptStyle(Color.White));
            bool success = DateTime.TryParseExact(startStr, TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out start);
            if (!success)
            {
                AnsiConsole.MarkupLine($"[red]Wrong Time Format. Check format is {TimeFormat}[/]");
                continue;
            }
            start = new DateTime(day.Year, day.Month, day.Day, start.Hour, start.Minute, 0);
            if (start > DateTime.Now)
            {
                AnsiConsole.MarkupLine("[red]Cant Accept future timings[/]");
            }
        } while (start > DateTime.Now || start == DateTime.MinValue);
        return start;
    }

    public DateTime GetEndTime(DateTime day, DateTime start)
    {
         DateTime end ;
         do
         {
             var endStr =  AnsiConsole.Prompt(new TextPrompt<string?>($"[yellow]Enter a End time ({TimeFormat}): [/]").PromptStyle(Color.White));
             bool success = DateTime.TryParseExact(endStr, TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out end);
             if (!success)
             {
                 AnsiConsole.MarkupLine($"[red]Wrong Time Format. Check format is {TimeFormat}[/]");
                 continue;
             }
             end = new DateTime(day.Year, day.Month, day.Day, end.Hour, end.Minute, 0);
             if (end > DateTime.Now)
             {
                 AnsiConsole.MarkupLine("[red]Cant Accept future timings[/]");
             }

             if (end <= start)
             {
                 end = end.AddDays(1);
             }
         } while (end > DateTime.Now || end == DateTime.MinValue);
         return end;
    }
    public DateTime GetDay()
    {
        DateTime day;
        do
        {
            var dayStr =  AnsiConsole.Prompt(new TextPrompt<string?>($"[yellow]Enter a date ({DateFormat}) or press enter for current: [/]").PromptStyle(Color.White).AllowEmpty());
            if (string.IsNullOrEmpty(dayStr))
            {
                day = DateTime.Today;
                break;
            }
            bool success = DateTime.TryParseExact(dayStr, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out day);
            if (!success)
            {
                AnsiConsole.MarkupLine($"[red]Wrong date format. Check format is ({DateFormat})[/]");

            }
            if (day > DateTime.Today)
            {
                AnsiConsole.MarkupLine("[red]Cant Accept Future date[/]");
            }
        }while(day == DateTime.MinValue || day > DateTime.Today);

        return day;
    }
    public string? GetDescription()
    {
        return AnsiConsole.Prompt(new TextPrompt<string?>("[yellow]Enter Description or press enter to skip: [/]").AllowEmpty().PromptStyle(new Style(Color.White)));
    }

    public ExerciseUpdate UpdateExercise()
    {
        //TODO: Get Exercise update
        throw new NotImplementedException();
    }
}