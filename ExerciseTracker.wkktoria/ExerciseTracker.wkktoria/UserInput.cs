using ExerciseTracker.wkktoria.Controllers;
using ExerciseTracker.wkktoria.Data.Models;
using ExerciseTracker.wkktoria.Data.Models.Dtos;
using Spectre.Console;

namespace ExerciseTracker.wkktoria;

public class UserInput
{
    private readonly string _dateFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
    private readonly IExerciseController _exerciseController;

    private readonly string _timeFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern;

    public UserInput(IExerciseController exerciseController)
    {
        _exerciseController = exerciseController;
    }

    public void Run()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .AddChoices("Add Exercise", "Edit Exercise", "Delete Exercise", "Show All Exercises",
                        "Show Exercise", "Quit")
            );

            switch (option)
            {
                case "Add Exercise":
                    AddExercise();
                    PressAnyKeyToContinue();
                    break;
                case "Edit Exercise":
                    EditExercise();
                    PressAnyKeyToContinue();
                    break;
                case "Delete Exercise":
                    DeleteExercise();
                    PressAnyKeyToContinue();
                    break;
                case "Show All Exercises":
                    ShowAllExercises();
                    PressAnyKeyToContinue();
                    break;
                case "Show Exercise":
                    ShowExercise();
                    PressAnyKeyToContinue();
                    break;
                case "Quit":
                    isAppRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void AddExercise()
    {
        try
        {
            var exercise = GetExerciseInput();

            _exerciseController.AddExercise(exercise);

            Console.Clear();

            WriteSuccess("Exercise has been added.");
        }
        catch (Exception e)
        {
            WriteError(e.Message);
        }
    }

    private void ShowAllExercises()
    {
        try
        {
            var exercises = _exerciseController.GetAllExercises();

            Console.Clear();

            if (exercises.Any())
                ShowExercisesTable(ExercisesToViewDtos(exercises));
            else
                Console.WriteLine("No exercises found.");
        }
        catch (Exception e)
        {
            WriteError(e.Message);
        }
    }

    private void ShowExercise()
    {
        try
        {
            var exercises = _exerciseController.GetAllExercises();

            Console.Clear();

            var exercise = GetExerciseSelection(exercises);

            _exerciseController.GetExercise(exercise.Id);

            Console.Clear();

            ShowExerciseDetails(ExerciseToViewDto(exercise));
        }
        catch (Exception e)
        {
            WriteError(e.Message);
        }
    }

    private void EditExercise()
    {
        try
        {
            var exercises = _exerciseController.GetAllExercises();

            Console.Clear();

            var exerciseToUpdate = GetExerciseSelection(exercises);

            ShowExerciseDetails(ExerciseToViewDto(exerciseToUpdate));

            var updatedExercise = GetUpdatedExerciseInput(exerciseToUpdate);

            _exerciseController.UpdateExercise(updatedExercise);

            Console.Clear();

            WriteSuccess("Exercise has been updated.");
        }
        catch (Exception e)
        {
            WriteError(e.Message);
        }
    }

    private void DeleteExercise()
    {
        try
        {
            var exercises = _exerciseController.GetAllExercises();

            Console.Clear();

            var exerciseToDelete = GetExerciseSelection(exercises);

            _exerciseController.DeleteExercise(exerciseToDelete);

            Console.Clear();

            WriteSuccess("Exercise has been deleted.");
        }
        catch (Exception e)
        {
            WriteError(e.Message);
        }
    }

    private DateTime GetFullDate(string forWhat)
    {
        var date = AnsiConsole.Ask<DateTime>($"{forWhat} date (format: {_dateFormat}):");
        var time = AnsiConsole.Ask<TimeSpan>($"{forWhat} time (format: {_timeFormat}):");

        return date.Add(time);
    }

    private Exercise GetExerciseInput()
    {
        var startDate = GetFullDate("Start");
        DateTime endDate;

        do
        {
            if (AnsiConsole.Confirm("Would you like to use the same date as start date for end date?"))
            {
                var date = startDate.Date;
                var time = AnsiConsole.Ask<TimeSpan>($"End time (format: {_timeFormat}):");
                endDate = date.Add(time);
            }
            else
            {
                endDate = GetFullDate("End");
            }

            if (!Validation.IsStartDateBeforeEndDate(startDate, endDate))
                WriteError("Start date cannot be after end date.");
        } while (!Validation.IsStartDateBeforeEndDate(startDate, endDate));

        var comment = string.Empty;

        if (AnsiConsole.Confirm("Would you like to add comment to exercise?"))
            comment = AnsiConsole.Ask<string>("Comment:");

        var exercise = new Exercise
        {
            StartDate = startDate,
            EndDate = endDate,
            Duration = endDate - startDate,
            Comment = comment
        };

        return exercise;
    }

    private Exercise GetUpdatedExerciseInput(Exercise exerciseToUpdate)
    {
        exerciseToUpdate.StartDate = AnsiConsole.Confirm("Would you like to edit start date?")
            ? GetFullDate("Start")
            : exerciseToUpdate.StartDate;

        do
        {
            exerciseToUpdate.EndDate = AnsiConsole.Confirm("Would you like to edit end date?")
                ? GetFullDate("End")
                : exerciseToUpdate.EndDate;

            if (!Validation.IsStartDateBeforeEndDate(exerciseToUpdate.StartDate, exerciseToUpdate.EndDate))
                WriteError("Start date cannot be after end date.");
        } while (!Validation.IsStartDateBeforeEndDate(exerciseToUpdate.StartDate, exerciseToUpdate.EndDate));

        exerciseToUpdate.Duration = exerciseToUpdate.EndDate - exerciseToUpdate.StartDate;

        exerciseToUpdate.Comment = AnsiConsole.Confirm("Would you like to edit comment?")
            ? AnsiConsole.Ask<string>("Comment:")
            : exerciseToUpdate.Comment;

        return exerciseToUpdate;
    }

    private static Exercise GetExerciseSelection(IEnumerable<Exercise> exercises)
    {
        var exercise = AnsiConsole.Prompt(
            new SelectionPrompt<Exercise>()
                .Title("Choose exercise")
                .AddChoices(exercises));

        return exercise;
    }

    private static List<ExerciseViewDto> ExercisesToViewDtos(IEnumerable<Exercise> exercises)
    {
        return exercises.Select(exercise => new ExerciseViewDto
        {
            StartDate = exercise.StartDate,
            EndDate = exercise.EndDate,
            Duration = exercise.Duration,
            Comment = exercise.Comment
        }).ToList();
    }

    private static ExerciseViewDto ExerciseToViewDto(Exercise exercise)
    {
        return new ExerciseViewDto
        {
            StartDate = exercise.StartDate,
            EndDate = exercise.EndDate,
            Duration = exercise.Duration,
            Comment = exercise.Comment
        };
    }

    private static void ShowExercisesTable(List<ExerciseViewDto> exercises)
    {
        var table = new Table
        {
            Title = new TableTitle("Exercises")
        };

        table.AddColumn("Start Date");
        table.AddColumn("End Date");
        table.AddColumn("Duration");
        table.AddColumn("Comment");

        foreach (var exercise in exercises)
            table.AddRow(
                exercise.StartDate.ToString("dd MMM yyyy"),
                exercise.EndDate.ToString("dd MMM yyyy"),
                exercise.Duration.ToString(),
                exercise.Comment!);


        AnsiConsole.Write(table);
    }

    private static void ShowExerciseDetails(ExerciseViewDto exercise)
    {
        var panel = new Panel($"""
                               Start Date: {exercise.StartDate:dd MMM yyyy}
                               End Date: {exercise.EndDate:dd MMM yyyy}
                               Duration: {exercise.Duration}
                               Comment: {exercise.Comment}
                               """)
        {
            Header = new PanelHeader("Exercise Details")
        };

        AnsiConsole.Write(panel);
    }

    private static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}