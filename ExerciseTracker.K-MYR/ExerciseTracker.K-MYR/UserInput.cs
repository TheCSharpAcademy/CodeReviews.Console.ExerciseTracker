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
            Console.Clear();
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
        Console.Clear();

        var training = GetExercise();

        if (training is not null)
            await _ExerciseController.DeleteAsync(training);
    }

    private async Task UpdateExercise()
    {
        Console.Clear();

        var training = GetExercise();        

        if (training is not null)
        {
            (var startTime, var endTime) = GetExerciseTimes();
        
            Console.WriteLine("Comments: ");
            var comments = Console.ReadLine() ?? "";

            training.StartTime = startTime;
            training.EndTime = endTime;
            training.Duration = (endTime - startTime).Ticks;
            training.Comments = comments;

            await _ExerciseController.UpdateAsync(training);
        }
    }

    private async Task AddExercise()
    {
        Console.Clear();

        (var startTime, var endTime) = GetExerciseTimes();
        
        Console.WriteLine("Comments: ");
        var comments = Console.ReadLine() ?? "";

        await _ExerciseController.AddAsync(new ExerciseInsertModel
        {
            StartTime = startTime,
            EndTime = endTime,
            Comments = comments 
        });    
    }

    private void ShowAllExercises()
    {
        Console.Clear();
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
            AnsiConsole.Write(new Markup("[red]Invalid Input[/]\n"));
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
                        .AddColumns("[springgreen2_1]ID[/]", "[springgreen2_1]Start Time[/]", "[springgreen2_1]End Time[/]", "[springgreen2_1]Duration[/]", "[springgreen2_1]Comments[/]");
        
        var exercises = data.ToArray().AsSpan();

        TimeSpan duration;

        for (int i = 0; i < exercises.Length; i++)
        {
            duration = TimeSpan.FromTicks(exercises[i].Duration);         
            table.AddRow((i+1).ToString(), 
                        exercises[i].StartTime.ToString("dd/MM/yyyy hh:mm"), 
                        exercises[i].EndTime.ToString("dd/MM/yyyy hh:mm"), 
                        string.Format("{0} h {1} m", duration.Hours + duration.Days * 24, duration.Minutes),
                        exercises[i].Comments);
        }

        AnsiConsole.Write(table);
    }
}
