using System.Globalization;
using System.Text;
using Spectre.Console;
using static ExerciseTracker.K_MYR.Enums;

namespace ExerciseTracker.K_MYR;

internal class UserInput
{
    private IExerciseController _ExerciseController;
    public UserInput(IExerciseController exerciseController)
    {
        _ExerciseController = exerciseController;
    }

    public async void ShowMainMenu()
    {
        while(true)
        {
            AnsiConsole.Write(new Panel("[springgreen2_1]Exercise Tracker[/]").BorderColor(Color.DarkOrange3_1));
            var choice = AnsiConsole.Prompt(new SelectionPrompt<MainMenu>()
                                                .AddChoices(Enum.GetValues(typeof(MainMenu)).Cast<MainMenu>()));

            switch (choice)
            {
                case MainMenu.AddExercise:
                    await AddExercise();
                    break;
                case MainMenu.UpdateExercise:
                    await UpdateExercise();
                    break;
                case MainMenu.DeleteExercise:
                    await DeleteExercise();
                    break;
                case MainMenu.ShowAllExercise:
                    ShowAllExercises();
                    break;
                case MainMenu.Quit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private async Task DeleteExercise()
    {
        var training = GetExercise();

        if (training is not null)
            await _ExerciseController.DeleteAsync(training);
    }

    private async Task UpdateExercise()
    {
        var training = GetExercise();        

        if (training is not null)
        {
            (var startTime, var endTime) = GetExerciseTimes();
        
            Console.WriteLine("Comments: ");
            var comments = Console.ReadLine() ?? "";

            training.StartTime = startTime;
            training.EndTime = endTime;
            training.Duration = endTime - startTime;
            training.Comments = comments;

            await _ExerciseController.UpdateAsync(training);
        }
    }

    private async Task AddExercise()
    {
        (var startTime, var endTime) = GetExerciseTimes();
        
        Console.WriteLine("Comments: ");
        var comments = Console.ReadLine() ?? "";

        await _ExerciseController.AddAsync(new Exercise
        {
            StartTime = startTime,
            EndTime = endTime,
            Duration = endTime - startTime,
            Comments = comments 
        });    
    }

    private void ShowAllExercises()
    {       
        PrintAllExercises(_ExerciseController.GetAll().ToArray());
        Helpers.PrintAndWait("Press Any Key To Return");
    }
    
    private DateTime GetDate(string text, string format = "dd-mm-yy hh:mm")
    {
        var sb = new StringBuilder();
        bool enterPressed;
        ConsoleKeyInfo key;
        DateTime date;

        do
        {

            Console.Write($"{text}: ");
            Console.Write(format);
            Console.CursorLeft -= format.Length;

            enterPressed = false;
            sb.Clear();

            while (!enterPressed)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.CursorLeft -= 1;
                            Console.Write(format[sb.Length]);
                            Console.CursorLeft -= 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (sb.Length == format.Length)
                        {
                            enterPressed = true;
                            Console.Write('\n');
                        }
                        break;
                    default:
                        if (sb.Length < format.Length && !char.IsControl(key.KeyChar))
                        {
                            sb.Append(key.KeyChar);
                            AnsiConsole.Write($"{key.KeyChar}");
                        }
                        break;
                }
            }
        } while (!DateTime.TryParseExact(sb.ToString().Trim(), "dd-MM-yy HH:mm", new CultureInfo("de-DE"), DateTimeStyles.None, out date));

        return date;
    }

    private (DateTime, DateTime) GetExerciseTimes()
    {
        var startTime = GetDate("Training Start Time");
        var endTime = GetDate("Training End Time");

        while (endTime <= startTime)
        {
            AnsiConsole.Write(new Panel("[red]The Shift End Time Cannot Be Or Be Before The Shift Start Time[/]").BorderColor(Color.DarkOrange3_1));
            startTime = GetDate("Shift Start Time");
            endTime = GetDate("Shift End Time");
        }

        return (startTime, endTime);
    }

    private Exercise? GetExercise()
    {
        var trainings = _ExerciseController.GetAll().ToArray();

        PrintAllExercises(trainings);

        var id = AnsiConsole.Ask<int>("Please enter the Id or 0 to return: ");

        while(id < 0 || id > trainings.Length)
        {
            AnsiConsole.Write(new Markup("[red]Invalid Input[/]"));
            id = AnsiConsole.Ask<int>("Please enter the Id or 0 to return: ");
        }

        if(id == 0)
            return null;

        return trainings[id-1];
    }
    
    private void PrintAllExercises(Exercise[] data)
    {
        var table = new Table()
                        .BorderColor(Color.DarkOrange3_1)
                        .AddColumns("ID", "Start Time", "End Time", "Duration", "Comments");
        
        var exercises = data.ToArray().AsSpan();

        for (int i = 0; i < exercises.Length; i++)
        {
            table.AddRow((i+1).ToString(), exercises[i].StartTime.ToString(), exercises[i].EndTime.ToString(), exercises[i].Duration.ToString(), exercises[i].Comments);
        }

        AnsiConsole.Write(table);
    }
}
