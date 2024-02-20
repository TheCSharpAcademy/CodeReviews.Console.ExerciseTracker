using ExerciseTracker.UserInterface;

namespace ExerciseTracker.Controllers;

public class MenuController
{
    public static void Start()
    {
        MainUI.DisplayWelcomeMessage();
        MainMenu();
    }

    public static void MainMenu()
    {
        ConsoleKey pressedKey;
        bool runMainMenu = true;
        do
        {
            MainUI.DisplayMainMenu();
            pressedKey = Console.ReadKey(false).Key;
            switch (pressedKey)
            {
                case(ConsoleKey.NumPad1):
                    ListExerciseMenu();
                    break;
                case(ConsoleKey.NumPad2):
                    InsertExerciseMenu();
                    break;
                case(ConsoleKey.NumPad3):
                    UpdateMenu();
                    break;
                case(ConsoleKey.NumPad4):
                    DeleteMenu();
                    break;      
                case(ConsoleKey.Escape):
                case(ConsoleKey.Backspace):
                    runMainMenu = false;
                    break;                                  
            }
        }
        while(runMainMenu);
        MainUI.DisplayExitMessage();
    }

    public static void ListExerciseMenu()
    {
        throw new NotImplementedException();
    }

    public static void InsertExerciseMenu()
    {
        throw new NotImplementedException();
    }

    public static void UpdateMenu()
    {
        throw new NotImplementedException();
    }

    public static void DeleteMenu()
    {
        throw new NotImplementedException();
    }
}