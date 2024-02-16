using ExerciseTracker.Models;

namespace ExerciseTracker.UserInterface;

public class MainUI
{
    public static void DisplayWelcomeMessage()
    {      
        Console.WriteLine("Welcome to the exercise tracker app!");
        Thread.Sleep(2000);
    }

    public static void DisplayMainMenu(List<Running>? exerciseList = null)
    {
        Console.Clear();
        TableUI.PrintTable(exerciseList);
        Console.WriteLine("Please select one of the following options:\n"+
            "1) Display all running logs\n"+
            "2) Insert a new runnig log\n"+
            "3) Update an existing running log\n"+
            "4) Delete a running log\n");
    }

    public static void DisplaySelectionMenu<T>(ConfirmationOptions confirmationOption, List<T> exerciseList) where T : class  //pagination and selection?
    {
        Console.Clear();
        Console.WriteLine($"Please select the log to {confirmationOption} and press Enter:");
        TableUI.PrintTable(exerciseList);
    }

    public static void DisplayConfirmationPromt(ConfirmationOptions confirmationOption)
    {
        Console.Clear();
        Console.WriteLine($"Do you want to {confirmationOption} the selected log? [y/N]");  //testing enums
    }

    public static void DisplayModifyMenu<T>(T exerciseToModify) where T : IExerciseModel  //Add selections
    {
        Console.Clear();
        Console.WriteLine("Select the field you want to modify:");
        Console.WriteLine($"1) Start Date: {exerciseToModify.StartDate}\n"+
            $"2) End Date: {exerciseToModify.EndDate}\n"+
            $"3) Comments: {exerciseToModify.Comments}");
    }

    public static void DisplayEnterId(string? errorMessage = null)
    {
        Console.Clear();
        if(errorMessage != null)
            Console.WriteLine($"Error: {errorMessage}");

        Console.WriteLine("Please enter a log ID:");
    }

    public static void DisplayEnterDate(DateOptions dateType, string? errorMessage = null)
    {
        Console.Clear();
        if(errorMessage != null)
            Console.WriteLine($"Error: {errorMessage}");
        
        Console.WriteLine($"Please enter a {dateType} date with the following format yyyy/MM/dd hh:mm");
    }

    public static void DisplayExitMessage()
    {
        Console.Clear();
        Console.WriteLine("Thank you for using the exercise tracker app!");
        Thread.Sleep(2000);
    }
}