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
        int id = int.Parse(_userInput.GetId());
        var oldWorkerExercise = _exerciseService.GetById(id);
        if (oldWorkerExercise is not null)
        {
            DisplayMessage("The Exercise is already exists", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        string type = _userInput.GetType();
        DateTime startDate = _userInput.GetDate();
        DateTime endDate = _userInput.GetDate();
        string comment = _userInput.GetComment();
        var exercise = new Exercise { DateStart = startDate, DateEnd = endDate, Type = type, Comments = comment };
        var data = _exerciseService.Create(exercise);
        if (data is false)
        {
            DisplayMessage("The Exercise is not created", "red");
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
        int id = int.Parse(_userInput.GetId());
        var Exercise =  _exerciseService.GetById(id);
        if (Exercise is null)
        {
            DisplayMessage("Nothing to show or the data is empty", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        DisplayItemTable(Exercise);
    }

    public void DeleteExercise()
    {
        int id = int.Parse(_userInput.GetId());
        var isDeleted =  _exerciseService.Delete(id);
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
        int id = int.Parse(_userInput.GetId());
        var oldWorkerExercise =  _exerciseService.GetById(id);
        if (oldWorkerExercise is null)
        {
            DisplayMessage("Nothing to show or the data is empty", "red");
            AnsiConsole.Confirm("Press any key to continue... ");
            return;
        }
        string type = _userInput.GetType(oldWorkerExercise.Type);
        DateTime startDate = _userInput.GetDate(oldWorkerExercise.DateStart.ToString());
        DateTime endDate = _userInput.GetDate(oldWorkerExercise.DateEnd.ToString());
        string comment = _userInput.GetComment(oldWorkerExercise.Comments);

        var Exercise =  _exerciseService.Update(new Exercise { Id=oldWorkerExercise.Id, DateStart=startDate, DateEnd=endDate, Comments=comment, Type=type});;
        if (Exercise is false)
        {
            DisplayMessage("The Exercise is not updated", "false");
            return;
        }
        DisplayMessage("The Exercise is updated", "green");
        AnsiConsole.Confirm("Press any key to continue... ");
    }
}