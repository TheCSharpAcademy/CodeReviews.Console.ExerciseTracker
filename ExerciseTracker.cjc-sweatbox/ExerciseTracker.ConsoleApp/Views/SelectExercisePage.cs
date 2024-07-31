using ExerciseTracker.ConsoleApp.Enums;
using ExerciseTracker.ConsoleApp.Models;
using ExerciseTracker.ConsoleApp.Services;
using ExerciseTracker.Extensions;
using Spectre.Console;

namespace ExerciseTracker.ConsoleApp.Views;

/// <summary>
/// A page to displays a list of exercises for selection.
/// </summary>
internal class SelectExercisePage : BasePage
{
    #region Constants

    private const string PageTitle = "Select Exercise";

    #endregion
    #region Methods - Internal

    internal static ExerciseDto? Show(IReadOnlyList<ExerciseDto> exercises)
    {
        WriteHeader(PageTitle);

        var option = GetOption(exercises);

        return option.Id == 0 ? null : exercises.First(x => x.Id == option.Id);
    }

    #endregion
    #region Methods - Private

    private static SelectionChoice GetOption(IReadOnlyList<ExerciseDto> exercises)
    {
        IEnumerable<SelectionChoice> pageChoices =
        [
            .. exercises.Select(x => new SelectionChoice { Id = x.Id, Name = x.ToSelectionChoice() }),
            new SelectionChoice { Name = MenuChoice.ClosePage.GetDescription() }
        ];

        return UserInputService.GetPageChoice(PromptTitle, pageChoices);
    }

    #endregion
}
