using ExerciceTracker.Data.Models;
using System.Globalization;

namespace ExerciceTracker
{
    internal class UserInput
    {

        internal static Exercise GetUserInputExercise()
        {
            var exercise = new Exercise();
            DateTime startTime, endTime;

            // get start time
            Console.WriteLine("What's the start time? (hh:mm) \n");
            string userInputStart = Console.ReadLine();

            if (DateTime.TryParseExact(userInputStart, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
            {
                exercise.DateStart = startTime;
            }
            else
            {
                Console.WriteLine("Invalid input. (hh:mm)");
            }

            // get end time
            Console.WriteLine("What's the end time? (hh:mm) \n");
            string userInputEnd = Console.ReadLine();

            if (DateTime.TryParseExact(userInputEnd, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime))
            {
                exercise.DateEnd = endTime;
            }
            else
            {
                Console.WriteLine("Invalid input. (hh:mm)");
            }

            // get duration
            TimeSpan duration;
            duration = endTime - startTime;
            exercise.Duration = duration;

            // get comments
            Console.WriteLine("Want to add a comment?\n");
            string userInputComments = Console.ReadLine();
            exercise.Comments = userInputComments;

            return exercise;
        }
    }
}
