using static ExerciseTracker.samggannon.UserInterface.Enums;
using Spectre.Console;
using ExerciseTracker.samggannon.Services;
using ExerciseTracker.samggannon.Validation;
using ExerciseTracker.samggannon.Controllers;
using ExerciseTracker.samggannon.Data.Repositories;

namespace ExerciseTracker.samggannon.UserInterface;

internal class MainMenu
{
    internal static void ShowMenu()
    {
        IExerciseRepository exerciseRepository = new ExerciseRepository();
        ExerciseService exerciseService = new ExerciseService(exerciseRepository);
        ExerciseController exerciseController = new ExerciseController(exerciseService);

        bool appIsRunning = true;

        while (appIsRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    MenuOptions.AddSession,
                    MenuOptions.ShowAllSessions,
                    MenuOptions.EditSessionById,
                    MenuOptions.DeleteSessionById,
                    MenuOptions.DevelopersDisclaimer,
                    MenuOptions.Quit
                    ));

            switch (option)
            {
                case MenuOptions.AddSession:
                    exerciseController.InsertSession();
                    break;
                case MenuOptions.ShowAllSessions:
                    exerciseController.GetAllSessions();
                    break;
                case MenuOptions.EditSessionById:
                    exerciseController.EditSession();
                    break;
                case MenuOptions.DeleteSessionById:
                    exerciseController.DeleteSessionById();
                    break;
                case MenuOptions.DevelopersDisclaimer:
                    ConsoleMessages.DevelopersNote();
                    break;
                case MenuOptions.Quit:
                    appIsRunning = false;
                    Environment.Exit(0);
                    break;

            }
        }
    }
}