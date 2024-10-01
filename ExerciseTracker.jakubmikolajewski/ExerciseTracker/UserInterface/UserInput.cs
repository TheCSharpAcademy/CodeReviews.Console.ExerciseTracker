using Spectre.Console;
using ExerciseTracker.Models;

namespace ExerciseTracker.UserInterface;
internal class UserInput
{
    public static string ChooseMenuOption()
    {
        List<string> menuOptions = ["View all entries", "Add entry", "Update entry", "Delete entry", "Exit"];

        return AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose an option from the menu:")
            .AddChoices(menuOptions));
    }

    public static Exercise ChooseEntry(List<Exercise> exerciseList)
    {
        List<string> choices = exerciseList
            .Select(e => $"{e.Id}, {e.Date}, {e.StartTime}, {e.EndTime}, {e.Duration}, {e.Comments}")
            .ToList();

        string chosenEntry = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose an entry:")
            .AddChoices(choices));

        int chosenEntryId = Convert.ToInt32(chosenEntry.Remove(chosenEntry.IndexOf(",")));

        Exercise? exercise = exerciseList
            .Find(e => e.Id.Equals(chosenEntryId));

        if (exercise is null)
            return new();
        return exercise;
    }

    public static Exercise EnterExerciseProperties(Exercise exercise)
    {
        exercise.Date = Validator.ValidateDate();
        exercise.StartTime = Validator.ValidateStartTime();
        exercise.EndTime = Validator.ValidateEndTime(exercise.StartTime);
        exercise.Comments = Validator.ValidateString();
        return exercise;
    }
}
