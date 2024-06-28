using ExerciseTracker.kalsson.Models;
using ExerciseTracker.kalsson.Services;
using Spectre.Console;

namespace ExerciseTracker.kalsson.Controllers;

public class ExerciseController
{
    private readonly ExerciseService _service;

        public ExerciseController(ExerciseService service)
        {
            _service = service;
        }

        public async Task DisplayAllExercisesAsync()
        {
            var exercises = await _service.GetAllExercisesAsync();
            var table = new Table().AddColumns("Id", "Start", "End", "Duration", "Comments");

            foreach (var exercise in exercises)
            {
                table.AddRow(exercise.Id.ToString(), exercise.StartExercise.ToString(), exercise.EndExercise.ToString(), exercise.DurationExercise.ToString(), exercise.ExerciseComment);
            }

            AnsiConsole.Write(table);
        }

        public async Task AddExerciseAsync()
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

        public async Task UpdateExerciseAsync()
        {
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

        public async Task DeleteExerciseAsync()
        {
            var id = AnsiConsole.Ask<int>("Enter the ID of the exercise to delete:");
            await _service.DeleteExerciseAsync(id);
            AnsiConsole.MarkupLine("[green]Exercise deleted successfully![/]");
        }
}