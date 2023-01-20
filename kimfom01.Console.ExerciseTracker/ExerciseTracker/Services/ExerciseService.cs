using ExerciseTracker.Dtos;
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
        List<Exercise> exercises = _exerciseRepository.GetExercises().ToList();

        var exercisesDtos = MapExerciseToDto(exercises);

        _tableVisualization.DisplayTable(exercisesDtos);

        Console.Write("Press Enter to continue");
        Console.ReadLine();
    }

    private static List<ExerciseViewDto> MapExerciseToDto(List<Exercise> exercises)
    {
        List<ExerciseViewDto> exercisesDtos = new();
        foreach (var exercise in exercises)
        {
            var hours = exercise.Duration?.Hours + (exercise.Duration?.Days * 24);
            var minutes = exercise.Duration?.Minutes;
            
            var duration = $"{hours} hrs, {minutes} mins";

            var temp = new ExerciseViewDto
            {
                Id = exercise.Id,
                StartDate = exercise.StartDate,
                EndDate = exercise.EndDate,
                Duration = duration,
                Comments = exercise.Comments
            };

            exercisesDtos.Add(temp);
        }

        return exercisesDtos;
    }

    public void GetExerciseById()
    {
        var id = _input.GetId();

        var exercise = _exerciseRepository.GetExerciseById(id);
        
        var exercisesDtos = MapExerciseToDto(new List<Exercise> { exercise });
        
        _tableVisualization.DisplayTable(exercisesDtos);

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