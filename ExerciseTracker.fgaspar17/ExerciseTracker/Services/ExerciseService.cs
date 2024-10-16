using Spectre.Console;

namespace ExerciseTracker;

public class ExerciseService
{
    private readonly IExerciseController _controller;
    public ExerciseService(IExerciseController controller)
    {
        _controller = controller;
    }
    public void CreateExercise()
    {
        MenuPresentation.PresentMenu("[blue]Inserting[/]");
        bool isCancelled;
        string start, end, comments;

        DateTimeValidator dateValidator = new();

        (isCancelled, start) = AskForStartDate(dateValidator);
        if (isCancelled) return;

        FutureDateTimeValidator futureDateTimeValidator = new(dateValidator, Convert.ToDateTime(start));

        (isCancelled, end) = AskForEndDate(Convert.ToDateTime(start), futureDateTimeValidator);
        if (isCancelled) return;

        (isCancelled, comments) = AskForComment();
        if (isCancelled) return;

        bool inserted = _controller.CreateExercise(new Exercise
        {
            DateStart = Convert.ToDateTime(start),
            DateEnd = Convert.ToDateTime(end),
            Comments = comments,
        });

        if (inserted)
        {
            AnsiConsole.MarkupLine("[green]Exercise Session inserted successfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Error inserted the Exercise Session[/]");
        }
        Prompter.PressKeyToContinuePrompt();
    }

    public void UpdateExercise()
    {
        MenuPresentation.PresentMenu("[yellow]Updating[/]");
        bool isCancelled;
        string exerciseId, start, end, comments;

        ShowExerciseTable();

        ExistingModelValidator<string, Exercise> existingExercise = new()
        {
            ErrorMsg = "Exercise Id doesn't exist.",
            GetModel = GetExerciseById
        };

        (isCancelled, exerciseId) = AskForExerciseId(existingExercise);
        if (isCancelled) return;

        DateTimeValidator dateValidator = new();

        (isCancelled, start) = AskForStartDate(dateValidator);
        if (isCancelled) return;

        FutureDateTimeValidator futureDateTimeValidator = new(dateValidator, Convert.ToDateTime(start));

        (isCancelled, end) = AskForEndDate(Convert.ToDateTime(start), futureDateTimeValidator);
        if (isCancelled) return;

        (isCancelled, comments) = AskForComment();
        if (isCancelled) return;

        bool updated = _controller.UpdateExercise(new Exercise
        {
            Id = Convert.ToInt32(exerciseId),
            DateStart = Convert.ToDateTime(start),
            DateEnd = Convert.ToDateTime(end),
            Comments = comments
        });

        if (updated)
        {
            AnsiConsole.MarkupLine("[green]Exercise Session updated successfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Error updating the Exercise Session[/]");
        }
        Prompter.PressKeyToContinuePrompt();
    }

    public void DeleteExercise()
    {
        MenuPresentation.PresentMenu("[red]Deleting[/]");
        bool isCancelled;
        string id;

        ShowExerciseTable();

        ExistingModelValidator<string, Exercise> existingExercise = new()
        {
            ErrorMsg = "Exercise Id doesn't exist.",
            GetModel = GetExerciseById
        };

        (isCancelled, id) = AskForExerciseId(existingExercise);
        if (isCancelled) return;

        if (_controller.DeleteExercise(_controller.GetExerciseById(int.Parse(id))!))
        {
            AnsiConsole.MarkupLine("[green]Exercise Session deleted successfully[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Error deleting the Exercise Session[/]");
        }
        Prompter.PressKeyToContinuePrompt();
    }

    public void ShowExercises()
    {
        ShowExerciseTable();
        Prompter.PressKeyToContinuePrompt();
    }

    public void ChangeExerciseDatabase()
    {
        GlobalConfig.ChangeCurrentDatabase();
    }

    private Exercise? GetExerciseById(string exerciseId)
    {
        bool parsed = int.TryParse(exerciseId, out int id);

        return parsed ? _controller.GetExerciseById(id) : null;
    }
    public static (bool IsCancelled, string Result) AskForExerciseId(params IValidator[] validators)
    {
        string message = "Enter an Exercise Id";
        return Prompter.PromptWithValidation(message, validations: validators);
    }

    public static (bool IsCancelled, string Result) AskForStartDate(params IValidator[] validators)
    {
        string message = "Enter a Start Date. Format: (yyyy-MM-dd HH:mm)";
        return Prompter.PromptWithValidation(message, defaultValue: DateTime.Now.ToString(), validations: validators);
    }

    public static (bool IsCancelled, string Result) AskForEndDate(DateTime startDate, params IValidator[] validators)
    {
        string message = "Enter a End Date. Format: (yyyy-MM-dd HH:mm)";
        return Prompter.PromptWithValidation(message, defaultValue: startDate.AddHours(2).ToString(), validations: validators);
    }

    public static (bool IsCancelled, string Result) AskForComment(params IValidator[] validators)
    {
        string message = "Enter Comments";
        return Prompter.PromptWithValidation(message, allowEmpty: true, validations: validators);
    }

    public void ShowExerciseTable()
    {
        List<Exercise> exercises = _controller.GetExercises().ToList();
        OutputRenderer.ShowTable(exercises, "Exercises");
    }
}