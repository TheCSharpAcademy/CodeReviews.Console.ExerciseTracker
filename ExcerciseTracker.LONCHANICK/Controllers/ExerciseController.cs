using ExerciseTracker.LONCHANICK.Services;
using Spectre.Console;
using ExerciseTracker.LONCHANICK.Models;

namespace ExerciseTracker.LONCHANICK.Controllers;

public class ExerciseController : IExerciseController
{
    private readonly IExerciseServices ExerciseServices;

    public ExerciseController(IExerciseServices _ExerciseServices)
    {
        ExerciseServices = _ExerciseServices;
    }

    public void Add()
    {
        ExerciseRecord newExer = new(){DateStart = DateTime.Now};
        Write("\tNew Session has been initialized, Press ENTER When finished.. ");
        ReadLine();
        newExer.DateEnd=DateTime.Now;

        newExer.Duration = CtrHelper.TimeSpanCalculator(newExer.DateStart, newExer.DateEnd);
        CtrHelper.PrintTimeSpan(newExer.Duration);
        ExerciseServices.Add(newExer);
        Console.ReadLine();
    }

    public void Delete()
    {
        var allExRecords = ExerciseServices.Get();
        var recordToDelete = CtrHelper.ExercMenuPickable(allExRecords);
        ExerciseServices.Delete(recordToDelete);
    }
    public void Update()
    {
        WriteLine("I owe u this one dude!");
        ReadLine();
    }
    public void GetAll()
    {
        var allExRecords = ExerciseServices.Get();
        CtrHelper.PrintExerciseRecords(allExRecords);
        ReadLine();
    }
}

public class CtrHelper()
{
    public static TimeSpan TimeSpanCalculator(DateTime init, DateTime final)=>(final-init);

    public static void PrintTimeSpan(TimeSpan timeSpan)
    {
        var panel = new Panel
        ($"Hours: {timeSpan.Hours}\nMinutes: {timeSpan.Minutes}\nSeconds: {timeSpan.Seconds}")
        {
            Header = new PanelHeader("Total Span"),
            Padding = new Padding(1, 1, 1, 1)
        };

        AnsiConsole.Write(panel);
    }
    public static void PrintExerciseRecords(IEnumerable<ExerciseRecord> ExRecords)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Init");
        table.AddColumn("End");
        table.AddColumn("Span");
        table.AddColumn("Comments");

        foreach (var exRecord in ExRecords)
        {
            TimeSpan aux = exRecord.Duration;
            table.AddRow
                (exRecord.ID.ToString(),
                exRecord.DateStart.ToString(),
                exRecord.DateEnd.ToString(),
                $"Hours: {aux.Hours} - Minutes: {aux.Minutes} - Seconds: {aux.Seconds}",
                exRecord.Comments??"No Comments");
        }

        AnsiConsole.Write(table);
        
    }
    public static ExerciseRecord ExercMenuPickable(IEnumerable<ExerciseRecord> ExerRecords)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<ExerciseRecord>()
            .Title("Choose any Record")
            .AddChoices(ExerRecords));
    }
}
