using Spectre.Console;

namespace ExerciseTracker;

public class ExerciseMenuHandler
{
    private readonly ExerciseService _exerciseService;

    public ExerciseMenuHandler(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }
    public void Display()
    {
        MenuPresentation.MenuDisplayer<ExerciseMenuOptions>(() => $"[blue]Exercise Menu {EnumHelper.GetTitle(GlobalConfig.CurrentDatabase)}[/]", HandleMenuOptions);
    }

    private bool HandleMenuOptions(ExerciseMenuOptions option)
    {

        switch (option)
        {
            case ExerciseMenuOptions.Quit:
                return false;
            case ExerciseMenuOptions.CreateExerciseSession:
                _exerciseService.CreateExercise();
                break;
            case ExerciseMenuOptions.UpdateExerciseSession:
                _exerciseService.UpdateExercise();
                break;
            case ExerciseMenuOptions.DeleteExerciseSession:
                _exerciseService.DeleteExercise();
                break;
            case ExerciseMenuOptions.ShowExerciseSessions:
                _exerciseService.ShowExercises();
                break;
            case ExerciseMenuOptions.ChangeExerciseDatabase:
                _exerciseService.ChangeExerciseDatabase();
                break;
            default:
                AnsiConsole.WriteLine($"Unknow option: {option}");
                break;
        }

        return true;
    }
}