using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using Spectre.Console;

namespace ExerciseTracker.UserInterface;
internal class Menu
{
    private readonly ExercisesController _controller;

    public Menu(ExercisesController controller)
    {
        _controller = controller;
    }

    public void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            string menuOption = UserInput.ChooseMenuOption();

            try
            {
                switch (menuOption)
                {
                    case "View all entries":
                        List<Exercise> exerciseList = _controller.GetAllExercises();
                        Presentation.ShowTable(exerciseList, "All entries");
                        break;
                    case "Add entry":
                        Exercise exercise = new();
                        exercise = UserInput.EnterExerciseProperties(exercise);
                        _controller.AddExercise(exercise);
                        break;
                    case "Update entry":
                        exerciseList = _controller.GetAllExercises();
                        exercise = UserInput.ChooseEntry(exerciseList);
                        List<Exercise> showCurrent = [exercise];
                        Presentation.ShowTable(showCurrent, "Currently updating");
                        UserInput.EnterExerciseProperties(exercise);
                        _controller.UpdateExercise(exercise);
                        break;
                    case "Delete entry":
                        exerciseList = _controller.GetAllExercises();
                        exercise = UserInput.ChooseEntry(exerciseList);
                        _controller.DeleteExercise(exercise);
                        break;
                    case "Exit":
                        exit = true;
                        return;
                }
                AnsiConsole.Markup("[green]Operation successful.[/]");      
            }
            catch (Exception ex)
            {
                AnsiConsole.Markup($"[red]Something went wrong. Details: {ex.Message}[/]");
            }
            Console.ReadLine();
        }
    }
}
