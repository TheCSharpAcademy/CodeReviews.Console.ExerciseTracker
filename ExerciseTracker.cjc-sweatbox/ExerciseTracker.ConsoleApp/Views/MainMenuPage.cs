using ExerciseTracker.ConsoleApp.Controllers;
using ExerciseTracker.ConsoleApp.Engines;
using ExerciseTracker.ConsoleApp.Enums;
using ExerciseTracker.ConsoleApp.Services;

namespace ExerciseTracker.ConsoleApp.Views;

/// <summary>
/// The main menu page of the application.
/// </summary>
internal class MainMenuPage : BasePage
{
    #region Constants

    private const string PageTitle = "Main Menu";

    #endregion
    #region Fields

    private readonly IExerciseController _exerciseController;
    private readonly IExerciseTypeController _exerciseTypeController;
    private static readonly MenuChoice[] _pageChoices =
    [
        MenuChoice.ViewExercises,
        MenuChoice.CreateExercise,
        MenuChoice.UpdateExercise,
        MenuChoice.DeleteExercise,
        MenuChoice.CloseApplication,
    ];

    #endregion
    #region Constructors

    public MainMenuPage(IExerciseController exerciseController, IExerciseTypeController exerciseTypeController)
    {
        _exerciseController = exerciseController;
        _exerciseTypeController = exerciseTypeController;
    }

    #endregion
    #region Methods - Internal

    internal void Show()
    {
        var choice = MenuChoice.Default;

        while (choice != MenuChoice.CloseApplication)
        {
            WriteHeader(PageTitle);

            choice = UserInputService.GetMenuChoice(PromptTitle, _pageChoices);
            switch (choice)
            {
                case MenuChoice.CreateExercise:
                    CreateExercise();
                    break;
                case MenuChoice.DeleteExercise:
                    DeleteExercise();
                    break;
                case MenuChoice.UpdateExercise:
                    UpdateExercise();
                    break;
                case MenuChoice.ViewExercises:
                    ViewExercises();
                    break;
                default:
                    break;
            }
        }
    }

    #endregion
    #region Methods - Private

    private void CreateExercise()
    {
        var exerciseTypes = _exerciseTypeController.ReturnAsync().Result;

        var request = CreateExercisePage.Show(exerciseTypes);
        if (request is null)
        {
            return;
        }

        var result = _exerciseController.CreateAsync(request).Result;
        if (result)
        {
            MessagePage.Show("Create Exercise", "Exercise created successfully.");
        }
        else
        {
            MessagePage.Show("Create Exercise", "Failed to create exercise.");
        }
    }

    private void DeleteExercise()
    {
        var exercises = _exerciseController.ReturnAsync().Result;

        var exercise = SelectExercisePage.Show(exercises);
        if (exercise is null)
        {
            return;
        }

        var result = _exerciseController.DeleteAsync(exercise.Id).Result;
        if (result)
        {
            MessagePage.Show("Delete Exercise", "Exercise deleted successfully.");
        }
        else
        {
            MessagePage.Show("Delete Exercise", "Failed to delete exercise.");
        }
    }

    private void UpdateExercise()
    {
        var exercises = _exerciseController.ReturnAsync().Result;

        var exercise = SelectExercisePage.Show(exercises);
        if (exercise is null)
        {
            return;
        }

        var exerciseTypes = _exerciseTypeController.ReturnAsync().Result;

        var request = UpdateExercisePage.Show(exercise, exerciseTypes);
        if (request is null)
        {
            return;
        }

        var result = _exerciseController.UpdateAsync(request).Result;
        if (result)
        {
            MessagePage.Show("Update Exercise", "Exercise updated successfully.");
        }
        else
        {
            MessagePage.Show("Update Exercise", "Failed to update exercise.");
        }
    }

    private void ViewExercises()
    {
        var exercises = _exerciseController.ReturnAsync().Result;

        var table = TableEngine.GetExercisesTable(exercises);

        MessagePage.Show("View Exercises", table);
    }

    #endregion
}
