using Spectre.Console;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Data.Repository;
using STUDY.ConsoleProjects.ExerciseTrackerFour.Models;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Service;
internal class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserInput _UserInput;
    public ExerciseService(IExerciseRepository exerciseRepository, IUserInput userInput)
    {
        _exerciseRepository = exerciseRepository;
        _UserInput = userInput;
    }
    public void ViewAllExerciseEntries()
    {
        var exercises = _exerciseRepository.GetExercises();

        if (exercises.Count == 0)
        {
            AnsiConsole.MarkupLine("404 - Cannot be found");
            MainMenu.ShowMainMenu();
        }

        else
        {
            DataVisualization.ShowDataInTable(exercises);
        }

        Console.WriteLine("View All Exercise Entries completed");
    } 
    public void ViewSpecificExerciseEntry()
    {        
        Console.WriteLine("Enter the ID of the exercise entry you want to view:");
        int exerciseId = int.Parse(Console.ReadLine());        

        Exercise? selectedExercise = _exerciseRepository.GetExerciseEntryById(exerciseId);

        if (selectedExercise is null)
        {
            AnsiConsole.MarkupLine("404 - Cannot be found");
            MainMenu.ShowMainMenu();
        }              

        Exercise exercise = _exerciseRepository.ViewSpecificExerciseEntry(exerciseId);

        DataVisualization.ShowSingleExercise(exercise);        
    }    
    public void AddExerciseEntry()
    {
        var (startTime, endTime, duration, comments) = _UserInput.GetUserInputForExcerciseEntry();

        Exercise exercise = new Exercise
        {
            StarTime = startTime,
            EndTime = endTime,
            Duration = duration.ToString(@"hh\:mm\:ss"),
            Comments = comments
        };

        _exerciseRepository.AddExerciseEntry(exercise);

        Console.WriteLine("Added Exercise Entry");
    } 
    public void UpdateExerciseEntry()
    {
        Console.WriteLine("Enter the ID of the exercise entry you want to Update:");
        int checkExerciseId = int.Parse(Console.ReadLine());

         Exercise? selectedExercise = _exerciseRepository.GetExerciseEntryById(checkExerciseId);

        if (selectedExercise is null)
        {
            AnsiConsole.MarkupLine("404 - Cannot be found");
            MainMenu.ShowMainMenu();
        }

        var (newStartTime, newEndTime, newDuration, newComments, exerciseId) = _UserInput.GetUserInputForUpdatedExcerciseEntry();
                
        Exercise newExercise = new Exercise
        {
            StarTime = newStartTime,
            EndTime = newEndTime,
            Duration = newDuration.ToString(@"hh\:mm\:ss"),
            Comments = newComments
        };

        _exerciseRepository.UpdateExerciseEntry(exerciseId, newExercise);

        Console.WriteLine($"Exercise entry with ID {exerciseId} updated successfully.");        
    }
    public void DeleteExerciseEntry()
    {
        Console.WriteLine("Enter the ID of the exercise entry you want to Delete:");
        int checkExerciseId = int.Parse(Console.ReadLine());

        Exercise? selectedExercise = _exerciseRepository.GetExerciseEntryById(checkExerciseId);

        if (selectedExercise is null)
        {
            AnsiConsole.MarkupLine("404 - Cannot be found");
            MainMenu.ShowMainMenu();
        }

        int exerciseId = _UserInput.GetUserInputToDelete();

        _exerciseRepository.DeleteExerciseEntry(exerciseId);         

        Console.WriteLine($"Exercise entry with ID {exerciseId} deleted successfully.");        
    }
}
