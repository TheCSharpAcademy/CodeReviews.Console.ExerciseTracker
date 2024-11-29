using ExerciseTracker.Mefdev.UserInputs;
using ExerciseTracker.Mefdev.Services;
using ExerciseTracker.Mefdev.Models;
using Spectre.Console;

namespace ExerciseTracker.Mefdev.Controllers;

public class ExerciseController : ExerciseBase
{
    private readonly ExerciseService _exerciseService;
    private readonly UserInput _userInput;

    public ExerciseController(ExerciseService exerciseService, UserInput userInput)
    {
        _exerciseService = exerciseService;
        _userInput = userInput;
    }

    public void CreateExercise()
    {
        string type = _userInput.GetType();
        DateTime startDate = _userInput.GetStartDate();
        DateTime endDate = _userInput.GetEndDate();
        string comment = _userInput.GetComment();
        var exercise = new Exercise { DateStart = startDate, DateEnd = endDate, Type = type, Comments = comment };
        var data = _exerciseService.Create(exercise);
        if (data is false)
        {
            DisplayMessage("The Exercise is not created", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        DisplayMessage("The Exercise is created", "green");
        AnsiConsole.Confirm("Press any key to continue... ");
    }

    public void GetExercises()
    {
        var Exercises = _exerciseService.GetAll().ToList();
        if (Exercises.Count() < 1 && Exercises == null)
        {
            DisplayMessage("Nothing to show the data is empty", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        DisplayAllItems(Exercises);
    }

    public void GetExercise()
    {
        var Exercise = GetExercises("get");
        if (Exercise is null)
        {
            DisplayMessage("the data is empty or null", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        DisplayItemTable(Exercise);
    }

    public void DeleteExercise()
    {
        var exercice = GetExercises("delete");
        if (exercice is null)
        {
            DisplayMessage("the data is empty or null", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        var isDeleted =  _exerciseService.Delete(exercice.Id);
        if (!isDeleted)
        {
            DisplayMessage("The Exercise you're looking for is not found", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        DisplayMessage("The Exercise has been deleted", "green");
        AnsiConsole.Confirm("Press any key to continue... ");
    }

    public void UpdateExercise()
    {
        var oldWorkerExercise = GetExercises("update");
        if (oldWorkerExercise is null)
        {
            DisplayMessage("Nothing to show or the data is empty", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        string type = _userInput.GetType(oldWorkerExercise.Type);
        DateTime startDate = _userInput.GetStartDate(oldWorkerExercise.DateStart.ToString());
        DateTime endDate = _userInput.GetEndDate(oldWorkerExercise.DateEnd.ToString());
        string comment = _userInput.GetComment(oldWorkerExercise.Comments);

        var Exercise = _exerciseService.Update(new Exercise { Id=oldWorkerExercise.Id, DateStart=startDate, DateEnd=endDate, Comments=comment, Type=type});;
        if (Exercise is false)
        {
            DisplayMessage("The Exercise is not updated", "red");
            return;
        }
        DisplayMessage("The Exercise is updated", "green");
        AnsiConsole.Confirm("Press any key to continue... ");
    }

    private Exercise? GetExercises(string action)
    {
        var exercises = _exerciseService.GetAll();
        if (exercises == null)
        {
            DisplayMessage("Exercises are not found or Empty", "red");
            return null;
        }
        var id = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title($"Select a [red]Exercise[/] to {action}")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more choices)[/]")
            .AddChoices(exercises.Select(c => c.Id.ToString())));
        return _exerciseService.GetById(int.Parse(id));
    }
}