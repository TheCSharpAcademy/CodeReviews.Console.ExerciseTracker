using ExerciseTracker.StanimalTheMan.Controllers;
using ExerciseTracker.StanimalTheMan.Models;
using Spectre.Console;
using static ExerciseTracker.StanimalTheMan.Enums;

namespace ExerciseTracker.StanimalTheMan;

public class UserInput
{
	public static void ShowMainMenu(ExerciseController exerciseController)
	{
		var isAppRunning = true;
		while (isAppRunning)
		{
			Console.Clear();
			var option = AnsiConsole.Prompt(
				new SelectionPrompt<MenuOptions>()
				.Title("What would you like to do?")
				.AddChoices(
					MenuOptions.AddExercise,
					MenuOptions.DeleteExercise,
					MenuOptions.UpdateExercise,
					MenuOptions.GetAllExercises,
					MenuOptions.GetExerciseById,
					MenuOptions.Quit));

			switch (option)
			{
				case MenuOptions.GetAllExercises:
					exerciseController.GetAllExercises();
					break;
				case MenuOptions.GetExerciseById:
					exerciseController.GetAllExercises();
					// prompt user for id; if that is not acceptable, will make api request to fetch all valid ids
					int id;
					Console.WriteLine("Enter an id of the exercise you want to fetch info of");
					while (!Int32.TryParse(Console.ReadLine(), out id))
					{
						Console.WriteLine("Invalid id.  Enter an id of the run you want to fetch info of");
					}
					exerciseController.GetExerciseById(id);
					break;
				case MenuOptions.AddExercise:
					Console.WriteLine("Enter distance in miles (e.g. 1, 1.5, 2)");
					double distance;
					Console.WriteLine("Enter an id of the exercise you want to fetch info of");
					while (!double.TryParse(Console.ReadLine(), out distance))
					{
						Console.WriteLine("Invalid distance.  Enter an id of the run you want to fetch info of");
					}

					Console.WriteLine("Enter Start Time of exercise: ");
					var startTimeInfo = Utility.GetDateTimeInput();

					Console.WriteLine("Enter End Time of exercise: ");
					var endTimeInfo = Utility.GetDateTimeInput();
					while (endTimeInfo.dateTime < startTimeInfo.dateTime)
					{
						Console.WriteLine("End time has to be after start time.  Enter End Time of shift:");
						endTimeInfo = Utility.GetDateTimeInput();
					}

					Console.WriteLine("Enter any comments on your run");
					string comments = Console.ReadLine();

					TimeSpan duration = Utility.CalculateDuration(endTimeInfo.dateTime, startTimeInfo.dateTime);
					exerciseController.AddExercise(new Run() { Distance = distance, DateStart = startTimeInfo.dateTime, DateEnd = endTimeInfo.dateTime, Duration = duration, Comments = comments }); ;
					break;
				case MenuOptions.UpdateExercise:
					exerciseController.GetAllExercises();
					Console.WriteLine("Select id of exercise you want to update:");
					while (!Int32.TryParse(Console.ReadLine(), out id))
					{
						Console.WriteLine("Invalid id.  Enter an id of the exercise you want to fetch info of");
					}
					Console.WriteLine("Enter distance in miles (e.g. 1, 1.5, 2)");
					Console.WriteLine("Enter an id of the exercise you want to fetch info of");
					while (!double.TryParse(Console.ReadLine(), out distance))
					{
						Console.WriteLine("Invalid distance.  Enter an id of the run you want to fetch info of");
					}

					Console.WriteLine("Enter Start Time of exercise: ");
					startTimeInfo = Utility.GetDateTimeInput();

					Console.WriteLine("Enter End Time of exercise: ");
					endTimeInfo = Utility.GetDateTimeInput();
					while (endTimeInfo.dateTime < startTimeInfo.dateTime)
					{
						Console.WriteLine("End time has to be after start time.  Enter End Time of shift:");
						endTimeInfo = Utility.GetDateTimeInput();
					}

					Console.WriteLine("Enter any comments on your run");
					comments = Console.ReadLine();

					duration = Utility.CalculateDuration(endTimeInfo.dateTime, startTimeInfo.dateTime);
					exerciseController.UpdateExercise(new Run {Id = id,  Distance = distance, DateStart = startTimeInfo.dateTime, DateEnd = endTimeInfo.dateTime, Duration = duration, Comments = comments }); ;
					break;
				case MenuOptions.DeleteExercise:
					exerciseController.GetAllExercises();
					Console.WriteLine("Select id of exercise you want to delete:");
					while (!Int32.TryParse(Console.ReadLine(), out id))
					{
						Console.WriteLine("Invalid id.  Enter an id of the exercise you want to delete");
					}
					exerciseController.DeleteExercise(id);
					break;
				case MenuOptions.Quit:
					Console.WriteLine("Goodbye");
					isAppRunning = false;
					break;
			}
		}
	}
}
