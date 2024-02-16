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
        var pressedKey = new ConsoleKey();
        bool runMainMenu = true;
        do
        {
            MainUI.DisplayMainMenu();  //how to fix this?
            pressedKey = Console.ReadKey(false).Key;
            switch(pressedKey)
            {
                case(ConsoleKey.NumPad1):
                    break;
                case(ConsoleKey.NumPad2):
                    break;
                case(ConsoleKey.NumPad3):
                    break;
                case(ConsoleKey.NumPad4):
                    break;      
                case(ConsoleKey.Escape):
                case(ConsoleKey.Backspace):
                    runMainMenu = false;
                    break;                                  
            }
        }
        while(runMainMenu);
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