using System.Globalization;
using Spectre.Console;
using ExerciseTracker.kalsson.Services;
using ExerciseTracker.kalsson.Models;

namespace ExerciseTracker.kalsson.Controllers
{
    public class ExerciseController
    {
        private readonly ExerciseService _service;

        public ExerciseController(ExerciseService service)
        {
            _service = service;
        }

        public async Task DisplayAllExercisesAsync()
        {
            try
            {
                var exercises = await _service.GetAllExercisesAsync();
                var table = new Table().AddColumns("Id", "Start", "End", "Duration", "Comments");

                foreach (var exercise in exercises)
                {
                    if (exercise.ExerciseComment != null)
                        table.AddRow(exercise.Id.ToString(),
                            exercise.StartExercise.ToString(CultureInfo.CurrentCulture),
                            exercise.EndExercise.ToString(CultureInfo.CurrentCulture),
                            exercise.DurationExercise.ToString(), exercise.ExerciseComment);
                }

                AnsiConsole.Write(table);
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error displaying exercises: {ex.Message}[/]");
            }
        }

        public async Task AddExerciseAsync()
        {
            try
            {
                var startExercise = AnsiConsole.Ask<DateTime>("Enter the start time:");
                var endExercise = AnsiConsole.Ask<DateTime>("Enter the end time:");
                var comments = AnsiConsole.Ask<string>("Enter any comments:");

                var exercise = new ExerciseModel
                {
                    StartExercise = startExercise,
                    EndExercise = endExercise,
                    DurationExercise = endExercise - startExercise,
                    ExerciseComment = comments
                };

                await _service.AddExerciseAsync(exercise);
                AnsiConsole.MarkupLine("[green]Exercise added successfully![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error adding exercise: {ex.Message}[/]");
            }
        }

        public async Task UpdateExerciseAsync()
        {
            try
            {
                await DisplayAllExercisesAsync();
                var id = AnsiConsole.Ask<int>("Enter the ID of the exercise to update:");
                var exercise = await _service.GetExerciseByIdAsync(id);

                if (exercise != null)
                {
                    exercise.StartExercise = AnsiConsole.Ask<DateTime>("Enter the new start time:", exercise.StartExercise);
                    exercise.EndExercise = AnsiConsole.Ask<DateTime>("Enter the new end time:", exercise.EndExercise);
                    exercise.ExerciseComment = AnsiConsole.Ask<string>("Enter new comments:", exercise.ExerciseComment);
                    exercise.DurationExercise = exercise.EndExercise - exercise.StartExercise;

                    await _service.UpdateExerciseAsync(exercise);
                    AnsiConsole.MarkupLine("[green]Exercise updated successfully![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Exercise not found![/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error updating exercise: {ex.Message}[/]");
            }
        }

        public async Task DeleteExerciseAsync()
        {
            try
            {
                await DisplayAllExercisesAsync();
                var id = AnsiConsole.Ask<int>("Enter the ID of the exercise to delete:");
                var exercise = await _service.GetExerciseByIdAsync(id);

                if (exercise != null)
                {
                    await _service.DeleteExerciseAsync(id);
                    AnsiConsole.MarkupLine("[green]Exercise deleted successfully![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Exercise not found![/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error deleting exercise: {ex.Message}[/]");
            }
        }
    }
}
