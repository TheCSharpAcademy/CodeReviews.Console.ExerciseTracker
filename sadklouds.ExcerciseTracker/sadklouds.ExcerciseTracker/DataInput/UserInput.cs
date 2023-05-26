using System.Globalization;

namespace sadklouds.ExcerciseTracker.UserInpit
{
    public class UserInput
    {
        public static int GetIdInput()
        {
            int id;
            Console.Write("Enter shift id: ");
            string? textId = Console.ReadLine();
            while (Validator.IsValid(textId) == false)
            {
                Console.WriteLine("Invalid id given");
                GetIdInput();
            }
            int.TryParse(textId, out id);
            return id;
        }

        public static DateTime GetStartDate()
        {
            Console.Write("Please enter exercise start date & time (dd/MM/yyyy HH:mm): ");
            string textDate = Console.ReadLine();
            DateTime startDate;
            while (Validator.IsValidDateFormat(textDate) == false)
            {
                Console.Write("Invalid start date format given, Correct formatting is dd/MM/yyyy HH:mm: ");
                textDate = Console.ReadLine();
            }
            DateTime.TryParseExact(textDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            return startDate;

        }

        public static DateTime GetEndDate(DateTime startDate)
        {
            Console.Write("Please enter exercise end date & time (dd/MM/yyyy HH:mm): ");
            string textDate = Console.ReadLine();
            DateTime endDate;
            while (Validator.IsValidDateFormat(textDate) == false)
            {
                Console.Write("Invalid end date format given. Correct formatting is dd/MM/yyyy HH:mm");
                textDate = Console.ReadLine();
            }
            DateTime.TryParseExact(textDate, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
            while (Validator.IsValidEndDate(textDate, startDate) == false)
            {
                Console.WriteLine("Exercise cannot end before it has started, Correct formatting is dd/MM/yyyy HH:mm.");
                GetEndDate(startDate);
            }
            return endDate;
        }
    }
}
