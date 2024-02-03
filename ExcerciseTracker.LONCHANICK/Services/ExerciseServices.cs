
using ExerciseTracker.LONCHANICK.Models;
using ExerciseTracker.LONCHANICK.Repository;
using ExerciseTracker.LONCHANICK.Services;
using Spectre.Console;

namespace ExerciseTracker.LONCHANICK.Services;

public class ExerciseServices : IExerciseServices
{
    private readonly IExerciseRepository ExerciseRepository; //= new();//dependency

    public ExerciseServices(IExerciseRepository ExcerciseRepositoryInjected)
    {
        ExerciseRepository=ExcerciseRepositoryInjected;
    }
    public void Add(ExerciseRecord exerciceRecord)
    {
        ExerciseRepository.Add(exerciceRecord);
    }
    public IEnumerable<ExerciseRecord> Get()
    {
        return ExerciseRepository.Get();
    }

    public void Delete(ExerciseRecord exerciceRecord)
    {
        ExerciseRepository.Delete(exerciceRecord);
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
