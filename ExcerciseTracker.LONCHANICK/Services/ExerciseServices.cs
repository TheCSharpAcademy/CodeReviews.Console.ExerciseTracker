
using ExerciseTracker.LONCHANICK.Models;
using ExerciseTracker.LONCHANICK.Services;
using Spectre.Console;

namespace ExerciseTracker.LONCHANICK.Services;

public class ExerciseServices : IExerciseServices
{
    public ExerciseRecord NewExerciseRecord()
    {
        ExerciseRecord newSession = new(){DateStart = DateTime.Now};
        Write("New Session has been initialized, Press ENTER to finish.. ");
        ReadLine();
        newSession.DateEnd=DateTime.Now;
        Write("\nSession finished!");
        ReadLine();
        return newSession;
    }
    public ExerciseRecord DeleteExerciseRecord(IEnumerable<ExerciseRecord> options)
    {
        var r = Helpers.ExerciseRecordMenuPickable(options.ToList());
        WriteLine("Record to Delete:\n"+r);
        ReadLine();

        return r;
    }
}

public static class Helpers
{
    internal static ExerciseRecord ExerciseRecordMenuPickable(List<ExerciseRecord> exerciseRecods)
    {
        var picked = AnsiConsole.Prompt(new SelectionPrompt<ExerciseRecord>()
            .Title("Pick up one!")
            .AddChoices(exerciseRecods));
        return picked;
    }
}
