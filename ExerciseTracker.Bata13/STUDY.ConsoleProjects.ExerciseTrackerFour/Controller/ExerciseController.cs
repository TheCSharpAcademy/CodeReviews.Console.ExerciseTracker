using STUDY.ConsoleProjects.ExerciseTrackerFour.Service;

namespace STUDY.ConsoleProjects.ExerciseTrackerFour.Controller;
public class ExerciseController
{
    private readonly IExerciseService _exerciseService;
    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }
    public void ViewAllExerciseEntries()
    {
        _exerciseService.ViewAllExerciseEntries();
    }
    public void ViewSpecificExerciseEntry()
    {
        _exerciseService.ViewSpecificExerciseEntry();
    }
    public void AddExerciseEntry()
    {
        _exerciseService.AddExerciseEntry();
    }
    public void UpdateExerciseEntry()
    {
        _exerciseService.UpdateExerciseEntry();
    }
    public void DeleteExerciseEntry()
    {
        _exerciseService.DeleteExerciseEntry();
    }
}
