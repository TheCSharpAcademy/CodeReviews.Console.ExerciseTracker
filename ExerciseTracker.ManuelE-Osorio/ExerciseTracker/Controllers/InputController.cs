using System.Globalization;
using ExerciseTracker.Models;
using ExerciseTracker.UserInterface;
using ExerciseTracker.Validation;

namespace ExerciseTracker.Controllers;

public class InputController
{
    public static int? GetId()
    {
        string idString = "";
        string? errorMessage = null;
        ConsoleKeyInfo pressedKey;

        while(true)
        {
            MainUI.DisplayEnterId(errorMessage);
            Console.Write(idString);
            pressedKey = Console.ReadKey();
            
            switch(pressedKey.Key)
            {
                case(ConsoleKey.Enter):
                    if(InputValidation.IntValidation(idString))
                        return Convert.ToInt32(idString);

                    errorMessage = "Please enter a valid ID";
                    break;
                
                case(ConsoleKey.Backspace):
                    if(idString.Length > 0)
                        idString = idString.Remove(idString.Length-1);
                    break;
                
                default:
                    idString += pressedKey.KeyChar.ToString();
                    break;

                case(ConsoleKey.Escape):
                    return null; 
            }
        }
    }

    public static DateTime? GetDate(DateOptions dateType)
    {
        string dateString = "";
        string? errorMessage = null;
        ConsoleKeyInfo pressedKey;

        while(true)
        {
            MainUI.DisplayEnterDate(dateType, errorMessage);
            Console.Write(dateString);
            pressedKey = Console.ReadKey();
            
            switch(pressedKey.Key)
            {
                case(ConsoleKey.Enter):
                    if(InputValidation.DateValidation(dateString))
                        return Convert.ToDateTime(dateString, CultureInfo.InvariantCulture);

                    errorMessage = "Please enter a valid date";
                    break;
                
                case(ConsoleKey.Backspace):
                    if(dateString.Length > 0)
                        dateString = dateString.Remove(dateString.Length-1);
                    break;
                
                default:
                    dateString += pressedKey.KeyChar.ToString();
                    break;

                case(ConsoleKey.Escape):
                    return null; 
            }
        }
    }

    public static DateTime? GetDate(DateOptions dateType, DateTime? startDate)
    {
        string dateString = "";
        string? errorMessage = null;
        ConsoleKeyInfo pressedKey;

        while(true)
        {
            MainUI.DisplayEnterDate(dateType, errorMessage);
            Console.Write(dateString);
            pressedKey = Console.ReadKey();
            
            switch(pressedKey.Key)
            {
                case(ConsoleKey.Enter):
                    if(InputValidation.DateValidation(dateString, startDate))
                        return Convert.ToDateTime(dateString, CultureInfo.InvariantCulture);
                    errorMessage = "Please enter a valid date or a date after the start date";
                    break;
                
                case(ConsoleKey.Backspace):
                    if(dateString.Length > 0)
                        dateString = dateString.Remove(dateString.Length-1);
                    break;
                
                default:
                    dateString += pressedKey.KeyChar.ToString();
                    break;

                case(ConsoleKey.Escape):
                    return null; 
            }
        }
    }

    public static string GetComments()
    {
        throw new NotImplementedException(); //Implement
    }

    public static Running? GetRunningExercise()
    {
        var startDate = GetDate(DateOptions.start);
        if(startDate == null)
            return null;
        
        var endDate = GetDate(DateOptions.end, startDate);
        if(endDate == null)
            return null;
        
        var comments = GetComments();
        if(comments == null)
            return null;
        
        var inputExercise = new Running{StartDate = (DateTime)startDate, EndDate = (DateTime)endDate, Comments = comments};
        return inputExercise;
    }
}