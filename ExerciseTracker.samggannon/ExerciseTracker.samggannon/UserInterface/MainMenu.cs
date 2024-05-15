using static ExerciseTracker.samggannon.UserInterface.Enums;
using Spectre.Console;
using ExerciseTracker.samggannon.Services;
using ExerciseTracker.samggannon.Validation;
using ExerciseTracker.samggannon.Controllers;
using ExerciseTracker.samggannon.Data.Repositories;
using ExerciseTracker.samggannon.Data.Models;

namespace ExerciseTracker.samggannon.UserInterface;

internal class MainMenu
{
    internal static void ShowMenu()
    {
        bool appIsRunning = true;

        while (appIsRunning)
        {
            Console.Clear();
            ConsoleMessages.WelcomeMessage();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ExerciseOptions>()
                .Title("What type of exercise would you like to track?")
                .AddChoices(
                    ExerciseOptions.CardioSession,
                    ExerciseOptions.ResistanceTraining,
                    ExerciseOptions.DevelopersDisclaimer,
                    ExerciseOptions.Quit
                    ));

            switch (option)
            {
                case ExerciseOptions.CardioSession:
                    ShowCardioMenu();
                    break;
                case ExerciseOptions.ResistanceTraining:
                    ShowResistanceTrainingMenu();
                    break;
                case ExerciseOptions.DevelopersDisclaimer:
                    ConsoleMessages.DevelopersNote();
                    break;
                case ExerciseOptions.Quit:
                    appIsRunning = false;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("An unexpected and unresolved error has occcured. Press [enter] to terminate the program.");
                    appIsRunning = false;
                    Environment.Exit(1);
                    break;
            }
        }
    }

    private static void ShowResistanceTrainingMenu()
    {
        IExerciseRepository exerciseRepository = new ResistanceRespository();
        ExerciseService exerciseService = new ExerciseService(exerciseRepository);
        ExerciseController exerciseController = new ExerciseController(exerciseService);

        bool appIsRunning = true;

        while (appIsRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ResistanceOptions>()
                .Title("What would you like to do?")
                .AddChoices(
                    ResistanceOptions.AddWorkout,
                    ResistanceOptions.ShowAllWorkouts,
                    ResistanceOptions.EditWorkoutById,
                    ResistanceOptions.DeleteWorkoutById,
                    ResistanceOptions.Back
                    ));

            switch (option)
            {
                case ResistanceOptions.AddWorkout:
                    exerciseController.InsertSession();
                    break;
                case ResistanceOptions.ShowAllWorkouts:
                    exerciseController.GetAllSessions();
                    break;
                case ResistanceOptions.EditWorkoutById:
                    exerciseController.EditSession();
                    break;
                case ResistanceOptions.DeleteWorkoutById:
                    exerciseController.DeleteSessionById();
                    break;
                case ResistanceOptions.Back:
                    appIsRunning = false;
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("An unexpected and unresolved error has occcured. Press [enter] to terminate the program.");
                    appIsRunning = false;
                    Environment.Exit(1);
                    break;

            }
        }
    }

    internal static void ShowCardioMenu()
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
                    MenuOptions.Back
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
                case MenuOptions.Back:
                    appIsRunning = false;
                    ShowMenu();
                    break;
                default:
                    Console.WriteLine("An unexpected and unresolved error has occcured. Press [enter] to terminate the program.");
                    appIsRunning = false;
                    Environment.Exit(1);
                    break;

            }
        }
    }

    internal static Exercise UpdateMenu(Exercise exerciseSession)
    {
        bool isUpdating = true;

        while(isUpdating)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<UpdateOptions>()
                .Title("What would you like to update?")
                .AddChoices(
                    UpdateOptions.UpdateStartTime,
                    UpdateOptions.UpdateEndTime,
                    UpdateOptions.UpdateComments,
                    UpdateOptions.Back
                    ));

            switch (option)
            {
                case UpdateOptions.UpdateStartTime:
                    exerciseSession.DateStart = UserInput.GetDateTime("start");
                    break;
                case UpdateOptions.UpdateEndTime:
                    exerciseSession.DateEnd = UserInput.GetDateTime("end");
                    break;
                case UpdateOptions.UpdateComments:
                    exerciseSession.Comments = UserInput.GetComments();
                    break;
                case UpdateOptions.Back:
                    isUpdating = false;
                    exerciseSession.Duration = UserInput.CalculateDuration(exerciseSession.DateStart, exerciseSession.DateEnd);
                    return exerciseSession;
                default:
                    Console.WriteLine("An unexpeceted and unresolved error has occcured. Press [enter] to terminate the program.");
                    isUpdating = false;
                    Environment.Exit(1);
                    break;
                     
            }
        }

        return exerciseSession;
    }
}
