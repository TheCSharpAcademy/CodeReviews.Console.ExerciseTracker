using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using ExerciseTracker.UserInput;
using ExerciseTracker.Visualization;

namespace ExerciseTracker.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IInput _input;
    private readonly ITableVisualization _tableVisualization;

    public ExerciseService(IExerciseRepository exerciseRepository, IInput input, ITableVisualization tableVisualization)
    {
        _exerciseRepository = exerciseRepository;
        _input = input;
        _tableVisualization = tableVisualization;
    }

    public void GetAllExercises()
    {
        var exercises = _exerciseRepository.GetExercises().ToList();

        _tableVisualization.DisplayTable(exercises);

        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }

    public void GetExerciseById()
    {
        var id = _input.GetId();

        var exercise = _exerciseRepository.GetExerciseById(id);
        
        _tableVisualization.DisplayTable(new List<Exercise> { exercise });

        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }

    public void RecordNewExercise()
    {
        var startDate = DateTime.Now;
        var exercise = new Exercise { StartDate = startDate };

        _exerciseRepository.AddExercise(exercise);
        _exerciseRepository.SaveChanges();
        Console.Clear();

        Console.WriteLine("New exercise recorded");

        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }

    public void UpdateExistingExercise()
    {
        var id = _input.GetId();
        var endDate = DateTime.Now;
        var comments = _input.GetComments();

        var exercise = new Exercise { EndDate = endDate, Comments = comments };

        _exerciseRepository.UpdateExercise(id, exercise);
        _exerciseRepository.SaveChanges();
        Console.Clear();

        Console.WriteLine("Exercise updated");

        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }

    public void DeleteExercise()
    {
        var id = _input.GetId();
        _exerciseRepository.DeleteExercise(id);
        _exerciseRepository.SaveChanges();
        Console.Clear();

        Console.WriteLine("Exercise deleted");

        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }
}