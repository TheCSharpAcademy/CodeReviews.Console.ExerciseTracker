using Spectre.Console;
using ExerciseTracker.kalsson.Controllers;

namespace ExerciseTracker.kalsson;

public class UserInput
{
    private readonly ExerciseController _controller;

    public UserInput(ExerciseController controller)
    {
        _controller = controller;
    }

    public async Task RunAsync()
    {
        var exit = false;
        while (!exit)
        {
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .AddChoices("View Exercises", "Add Exercise", "Update Exercise", "Delete Exercise", "Exit"));

            switch (choice)
            {
                case "View Exercises":
                    await _controller.DisplayAllExercisesAsync();
                    break;
                case "Add Exercise":
                    await AddExerciseAsync();
                    break;
                case "Update Exercise":
                    await UpdateExerciseAsync();
                    break;
                case "Delete Exercise":
                    await DeleteExerciseAsync();
                    break;
                case "Exit":
                    exit = true;
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private async Task AddExerciseAsync()
    {
        try
        {
            var startExercise = ParseDateTime("Enter the start time (format: yyyyMMdd HH:mm):");
            var endExercise = ParseDateTime("Enter the end time (format: yyyyMMdd HH:mm):");

            if (endExercise <= startExercise)
            {
                Console.WriteLine("End time must be after start time.");
                return;
            }

            var comments = AnsiConsole.Ask<string>("Enter any comments:");

            await _controller.AddExerciseAsync(startExercise, endExercise, comments);
            Console.WriteLine("Exercise added successfully!");
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            Console.WriteLine($"Error adding exercise: {errorMessage}");
        }
    }

    private async Task UpdateExerciseAsync()
    {
        try
        {
            await _controller.DisplayAllExercisesAsync();
            var id = AnsiConsole.Ask<int>("Enter the ID of the exercise to update:");
            var exercise = await _controller.GetExerciseByIdAsync(id);

            if (exercise != null)
            {
                var startExercise = ParseDateTime("Enter the new start time (format: yyyyMMdd HH:mm):", exercise.StartExercise);
                var endExercise = ParseDateTime("Enter the new end time (format: yyyyMMdd HH:mm):", exercise.EndExercise);

                if (endExercise <= startExercise)
                {
                    Console.WriteLine("End time must be after start time.");
                    return;
                }

                var comments = AnsiConsole.Ask<string>("Enter new comments:", exercise.ExerciseComment);

                await _controller.UpdateExerciseAsync(id, startExercise, endExercise, comments);
                Console.WriteLine("Exercise updated successfully!");
            }
            else
            {
                Console.WriteLine("Exercise not found!");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            Console.WriteLine($"Error updating exercise: {errorMessage}");
        }
    }

    private async Task DeleteExerciseAsync()
    {
        try
        {
            await _controller.DisplayAllExercisesAsync();
            var id = AnsiConsole.Ask<int>("Enter the ID of the exercise to delete:");
            var exercise = await _controller.GetExerciseByIdAsync(id);

            if (exercise != null)
            {
                await _controller.DeleteExerciseAsync(id);
                Console.WriteLine("Exercise deleted successfully!");
            }
            else
            {
                Console.WriteLine("Exercise not found!");
            }
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            Console.WriteLine($"Error deleting exercise: {errorMessage}");
        }
    }

    private DateTime ParseDateTime(string prompt, DateTime? defaultValue = null)
    {
        DateTime result;
        while (true)
        {
            string input;
            if (defaultValue.HasValue)
            {
                Console.WriteLine($"{prompt} [default: {defaultValue.Value:yyyyMMdd HH:mm}]");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultValue.Value;
                }
            }
            else
            {
                input = AnsiConsole.Ask<string>(prompt);
            }

            if (DateTime.TryParseExact(input, "yyyyMMdd HH:mm", null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result;
            }

            Console.WriteLine("Invalid format. Please enter the date and time in the format: yyyyMMdd HH:mm");
        }
    }
}
