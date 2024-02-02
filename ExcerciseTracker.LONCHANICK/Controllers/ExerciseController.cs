using System.Data.Common;
using ExerciseTracker.LONCHANICK.Services;
using ExerciseTracker.LONCHANICK.Repository;

namespace ExerciseTracker.LONCHANICK.Controllers;

public class ExerciseController : IExerciseController
{
    private readonly IExerciseRepository ExerciseRepository; //= new();//dependency
    private readonly IExerciseServices ExerciseServices; //= new ();//dependency

    public ExerciseController(IExerciseRepository _ExerciseRepository,  IExerciseServices _ExerciseServices)
    {
        ExerciseRepository = _ExerciseRepository;
        ExerciseServices = _ExerciseServices;
    }

    public void Add()
    {
        var newExerciseRecord = ExerciseServices.NewExerciseRecord();
        ExerciseRepository.Add(newExerciseRecord);
    }

    public void Delete()
    {
        var allExRecords = ExerciseRepository.Get();

        var r = ExerciseServices.DeleteExerciseRecord(allExRecords);

        ExerciseRepository.Delete(r);
        ReadLine();
    }
    public void Update()
    {
        WriteLine("I owe u this one dude!");
        ReadLine();
    }
    public void GetAll()
    {
        var allExRecords = ExerciseRepository.Get();

        foreach(var record in allExRecords)
            WriteLine(record+"\n");

        ReadLine();
    }
}
