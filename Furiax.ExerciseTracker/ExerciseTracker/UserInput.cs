using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using Microsoft.Identity.Client;
using Spectre.Console;

namespace ExerciseTracker
{
	public class UserInput
	{
		private readonly ExerciseTrackerContext _context;
		public UserInput(ExerciseTrackerContext context)
		{
			_context = context;
		}
		public static ExerciseModel GetExerciseInfo()
		{
			var exercise = new ExerciseModel();
			string type = AnsiConsole.Ask<string>("What exercise did you do ? ").Trim();
			DateTime start = AnsiConsole.Ask<DateTime>("When did the exercise start ? format(yyyy-mm-dd hh:mm): ");
			DateTime end = AnsiConsole.Ask<DateTime>("When did the exercise end ? format (yyyy-mm-dd hh:mm): ");
			string comment = AnsiConsole.Prompt(new TextPrompt<string>("Add a comment about the exercise (optional): ")
				.AllowEmpty());
			

			exercise.ExerciseType = type;
			exercise.DateStart = start;
			exercise.DateEnd = end;
			exercise.Comments = comment;

			return exercise;
		}
		public void MainMenu()
		{
			IExerciseRepository exerciseRepository = new ExerciseRepository(_context);
			ExerciseService exerciseService = new ExerciseService(exerciseRepository);
			bool isAppAlive = true;
			while (isAppAlive)
			{
				Console.Clear();
				var option = AnsiConsole.Prompt(new SelectionPrompt<Menu>()
					.Title("What would you like to do?")
					.AddChoices(
						Menu.AddExercise,
						Menu.ViewAllExercises,
						Menu.ViewExercise,
						Menu.UpdateExercise,
						Menu.DeleteExercise,
						Menu.Quit
						));
				switch (option)
				{
					case Menu.AddExercise:
						exerciseService.AddExercise();
						break;
					case Menu.ViewAllExercises:
						exerciseService.GetAll();
						break;
					case Menu.ViewExercise:
						break;
					case Menu.UpdateExercise: break;
					case Menu.DeleteExercise:
						break;
					case Menu.Quit:
						isAppAlive = false;
						break;
				}
			}
		}
		enum Menu
		{
			AddExercise,
			ViewAllExercises,
			ViewExercise,
			UpdateExercise,
			DeleteExercise,
			Quit
		}
	}
}
