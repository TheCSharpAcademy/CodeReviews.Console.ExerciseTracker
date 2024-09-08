﻿
using System.Globalization;

namespace ExerciseTracker.kjanos89;

public class Validation
{
    public bool IsEndLater(DateTime start, DateTime end)
    {
        
        return start < end;
    }

    public DateTime DateConverter(string date)
    {
        DateTime checkedDate;
        if (!DateTime.TryParse(date, out checkedDate))
        {
            Console.WriteLine("Date format accepted!");
        }
        else
        {
            Console.WriteLine("The format of the date is not acceptable, try again!");
        }
        return checkedDate;
    }

    public bool IsValidDate(string input)
    {
        DateTime date;
        if (DateTime.TryParseExact(input, "yyyy.MM.dd. HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}