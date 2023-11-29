using ExerciseTracker.Speedierone.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public class UserInput
    {
        internal static string CheckDate()
        {
            string dateString = Console.ReadLine();
            string format = "dd/MM/yyyy";

            while (!DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Console.WriteLine($"Invalid format. Please enter in format {format}.");
                dateString = Console.ReadLine();
            }
            return dateString;
        }

        public static bool CheckEndDate(string startDate, string endDate)
        {
            var startDateParsed = DateTime.Parse(startDate);
            var endDateParsed = DateTime.Parse(endDate);

            if(startDateParsed > endDateParsed)
            {
                Console.WriteLine("End date is before start date. Press any button to continue");
                return false;
            }
            if(endDateParsed > startDateParsed.AddDays(1))
            {
                Console.WriteLine("End date must be less then 1 day from start date.");
                return false;
            }
            return true;
        }
        public static string CheckTime()
        {
            string timeString = Console.ReadLine();
            string format = "HH:mm";

            while (!DateTime.TryParseExact(timeString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Console.WriteLine($"Invalid format. Please enter in format {format}");
                timeString = Console.ReadLine();
            }
            return timeString;
        }

        public TimeSpan GetDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;
            return duration;
        }

        public DateTime CombinedDateTime(string date, string time)
        {
            var userDate = date;
            var userTime = time;

            DateTime parsedDate = DateTime.Parse(userDate);
            DateTime parsedTime = DateTime.Parse(userTime);

            DateTime combinedDateTime = new DateTime(
                parsedDate.Year,
                parsedDate.Month,
                parsedDate.Day,
                parsedTime.Hour,
                parsedTime.Minute,
                0);

            return combinedDateTime;
        }
        public Exercises GetSession()
        {
            Console.WriteLine("Please enter start date in format dd/mm/yyyy");
            var startDate = CheckDate();

            Console.WriteLine("Please enter start time in format hh:mm");
            var startTime = CheckTime();

            var combinedStartDate = CombinedDateTime(startDate, startTime);
            var stringCombinedStartDate = combinedStartDate.ToString();

            Console.WriteLine("Please enter end date in format dd/mm/yyyy");
            var endDate = CheckDate();

            Console.WriteLine("Please enter end time in format hh:mm");
            var endTime = CheckTime();

            var combinedEndDate = CombinedDateTime(endDate, endTime);
            var stringCombinedEndDate = combinedEndDate.ToString(); 

            var checkEndDate = CheckEndDate(stringCombinedStartDate, stringCombinedEndDate);

            while(checkEndDate = false)
            {
                Console.WriteLine("End date is before start date. Press any key to try again.");
                endDate = CheckDate();
                endTime = CheckTime();
            }
            var duration = GetDuration(combinedStartDate, combinedEndDate);

            Console.WriteLine("Please enter any comments you wish to make. Press enter when finished or wish to leave it blank.");
            var comments = Console.ReadLine();

            return new Exercises
            {
                DateStart = combinedStartDate,
                DateEnd = combinedEndDate,
                Duration = duration,
                Comments = comments
            };
        }
    }
}
