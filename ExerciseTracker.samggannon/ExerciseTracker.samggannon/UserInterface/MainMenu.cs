using static ExerciseTracker.samggannon.UserInterface.Enums;
using Spectre.Console;
using ExerciseTracker.samggannon.Controllers;
using ExerciseTracker.samggannon.Validation;

namespace ExerciseTracker.samggannon.UserInterface;

internal class MainMenu
{
    internal static void ShowMenu()
    {
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
                    ExerciseController.InsertSession();
                    break;
                case MenuOptions.ShowAllSessions:
                    ExerciseController.GetAllSessions();
                    break;
                case MenuOptions.EditSessionById:
                    ExerciseController.EditSession();
                    break;
                case MenuOptions.DeleteSessionById:
                    ExerciseController.DeleteSessionById();
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