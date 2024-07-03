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
                    table.AddRow(exercise.Id.ToString(), exercise.StartExercise.ToString("yyyyMMdd HH:mm"), exercise.EndExercise.ToString("yyyyMMdd HH:mm"), exercise.DurationExercise.ToString(@"hh\:mm"), exercise.ExerciseComment);
                }

                AnsiConsole.Write(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying exercises: {ex.Message}");
            }
        }

        public async Task AddExerciseAsync(DateTime startExercise, DateTime endExercise, string comments)
        {
            var exercise = new ExerciseModel
            {
                StartExercise = startExercise,
                EndExercise = endExercise,
                DurationExercise = endExercise - startExercise, // Ensure this is within a day
                ExerciseComment = comments
            };

            await _service.AddExerciseAsync(exercise);
        }

        public async Task<ExerciseModel> GetExerciseByIdAsync(int id)
        {
            return await _service.GetExerciseByIdAsync(id);
        }

        public async Task UpdateExerciseAsync(int id, DateTime startExercise, DateTime endExercise, string comments)
        {
            var exercise = await _service.GetExerciseByIdAsync(id);
            if (exercise != null)
            {
                exercise.StartExercise = startExercise;
                exercise.EndExercise = endExercise;
                exercise.DurationExercise = endExercise - startExercise;
                exercise.ExerciseComment = comments;

                await _service.UpdateExerciseAsync(exercise);
            }
        }

        public async Task DeleteExerciseAsync(int id)
        {
            await _service.DeleteExerciseAsync(id);
        }
    }
}
