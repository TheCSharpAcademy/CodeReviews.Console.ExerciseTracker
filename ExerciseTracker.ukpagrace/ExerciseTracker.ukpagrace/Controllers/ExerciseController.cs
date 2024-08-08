using ExerciseTracker.ukpagrace.Interfaces;
using ExerciseTracker.ukpagrace.Model;
using ExerciseTracker.ukpagrace.UserInterface;
using Spectre.Console;

namespace ExerciseTracker.ukpagrace.Controllers
{
    public class ExerciseController
    {
        public readonly IExerciseService<Exercise> _exerciseService;
        private readonly UserInput userInput = new();
        private readonly Validation validation = new();

        public ExerciseController(IExerciseService<Exercise> exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public void AddExercise()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Add an Exercise")
                    .Color(Color.Green));
                var startDate = userInput.GetStartDate();
                var endDate = userInput.GetEndDate();

                if (validation.ValidateRange(startDate, endDate))
                {
                    throw new Exception("Start Date cannot be greater than endDate");
                }
                var duration = endDate - startDate;

                var comment = userInput.GetStringInput();

                var exercise = new Exercise()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = duration,
                    Comment = comment,
                };
                _exerciseService.AddExercise(exercise);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetExercises()
        {
            try
            {
                AnsiConsole.Write(new FigletText("All Exercises")
                    .Color(Color.DodgerBlue1));
                var exercises = _exerciseService.GetExercises();
                var table = new Table();
                table.AddColumn(new TableColumn("Id").Centered());
                table.AddColumn(new TableColumn("StartTime").Centered());
                table.AddColumn(new TableColumn("EndTime").Centered());
                table.AddColumn(new TableColumn("Comment").Centered());

                foreach (var exercise in exercises)
                {
                    table.AddRow(new Markup($"[blue]{exercise.Id}[/]"),
                        new Markup($"[blue]{exercise.StartDate}[/]"),
                        new Markup($"[blue]{exercise.EndDate}[/]"),
                        new Markup($"[blue]{exercise.Comment}[/]")
                    );
                }
                AnsiConsole.Write(table);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetExercise()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Get an Exercise")
                    .Color(Color.Green));
                int id = userInput.GetNumberInput("Enter Id of Exercise");

                var exercise = _exerciseService.GetExercise(id);
                if (exercise == null)
                {
                    throw new Exception("Exercise with this Id does not exist");
                }
                var table = new Table();
                table.AddColumn(new TableColumn("Id").Centered());
                table.AddColumn(new TableColumn("StartTime").Centered());
                table.AddColumn(new TableColumn("EndTime").Centered());
                table.AddColumn(new TableColumn("Comment").Centered());

                table.AddRow(new Markup($"[blue]{exercise.Id}[/]"),
                    new Markup($"[blue]{exercise.StartDate}[/]"),
                    new Markup($"[blue]{exercise.EndDate}[/]"),
                    new Markup($"[blue]{exercise.Comment}[/]")
                );
                AnsiConsole.Write(table);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void UpdateExercise()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Get an Exercise")
                .Color(Color.Green));

                int id = userInput.GetNumberInput("Enter Id of Exercise");

                var exercise = _exerciseService.GetExercise(id);
                if (exercise == null)
                {
                    throw new Exception("Exercise with this Id does not exist");
                }
                var startDate = userInput.GetStartDate();
                var endDate = userInput.GetEndDate();

                if (validation.ValidateRange(startDate, endDate))
                {
                    throw new Exception("Start Date cannot be greater than endDate");
                }
                var duration = endDate - startDate;

                var comment = userInput.GetStringInput();

                exercise.StartDate = startDate;
                exercise.EndDate = endDate;
                exercise.Comment = comment;
                exercise.Duration = duration;
                _exerciseService.UpdateExercise(exercise);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DeleteExercise()
        {
            try
            {
                AnsiConsole.Write(new FigletText("Get an Exercise")
                .Color(Color.Green));

                int id = userInput.GetNumberInput("Enter Id of Exercise");

                var exercise = _exerciseService.GetExercise(id);
                if (exercise == null)
                {
                    throw new Exception("Exercise with this Id does not exist");
                }
                _exerciseService.DeleteExercise(exercise);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
