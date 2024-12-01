using ExerciseTracker.TwilightSaw.Controllers;
using ExerciseTracker.TwilightSaw.Helpers;
using Spectre.Console;

namespace ExerciseTracker.TwilightSaw.View;

public class Menu(ExerciseController controller)
{
    public void AddMenu()
    {
        while(true)
        {
            Console.Clear();
            AnsiConsole.Write(new Rule("[olive]Welcome to the Exercise Tracker![/]"));
            var typeInput = UserInput.CreateChoosingList(["Cardio", "Weights"], "Exit");
            if (typeInput == "Exit") break;
            var end = false;
            while (!end)
            {
                Console.Clear();
                AnsiConsole.Write(new Rule($"[olive]{typeInput}[/]"));
                switch (UserInput.CreateChoosingList(["Add the exercise", "Your exercises"], "Return"))
                {
                    case "Add the exercise":
                        controller.AddExercise(typeInput);
                        break;
                    case "Your exercises":
                        while (true)
                        {
                            var chosenExercise = controller.GetExercise(typeInput);
                            Console.Clear();
                            AnsiConsole.Write(new Rule($"[olive]{chosenExercise.StartTime.ToShortDateString()} " +
                                                       $"{chosenExercise.StartTime.TimeOfDay} " +
                                                       $"{chosenExercise.EndTime.TimeOfDay}[/]"));
                            if (chosenExercise.Comments == "Return") break;
                            switch (UserInput.CreateChoosingList(["Update exercise information", "Delete the exercise"],
                                        "Return"))
                            {
                                case "Update exercise information":
                                    controller.ChangeExercise(chosenExercise);
                                    break;
                                case "Delete the exercise":
                                    controller.DeleteExercise(chosenExercise);
                                    break;
                                case "Return":
                                    break;
                            }
                        }
                        break;
                    case "Return":
                        end = true;
                        break;
                }
            }
        }
    }
}