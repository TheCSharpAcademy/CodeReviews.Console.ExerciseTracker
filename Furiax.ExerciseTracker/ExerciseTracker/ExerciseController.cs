using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using Spectre.Console;

namespace ExerciseTracker
{
	public class ExerciseController
	{
		public static ExerciseModel AddExercise()
		{
			var exercise = UserInput.GetExerciseInfo();
			return exercise;
		}
		public static void PrintExercisesTable(List<ExerciseModel> exercises)
		{
			var table = new Table();
			table.AddColumn("Id");
			table.AddColumn("Type");
			table.AddColumn("Start time");
			table.AddColumn("End time");
			table.AddColumn("Duration");
			table.AddColumn("Comment");

			foreach (var exercise in exercises)
			{
				table.AddRow(exercise.ExerciseId.ToString(), exercise.ExerciseType,
					exercise.DateStart.ToString(), exercise.DateEnd.ToString(), 
					exercise.Duration.ToString(), exercise.Comments);
			}
			AnsiConsole.Write(table);

			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
		}
		public static void PrintExercise(ExerciseModel exercise)
		{
			var panel = new Panel($@"Exercise: {exercise.ExerciseType}
Start time: {exercise.DateStart}
End time: {exercise.DateEnd}
Duration: {exercise.Duration}
Comment: {exercise.Comments}");
			panel.Header = new PanelHeader("Exercise info:");
			panel.Padding = new Padding(2, 2, 2, 2);

			AnsiConsole.Write(panel);
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
			Console.Clear();
		}

		internal static int GetIdOption(List<ExerciseModel> exercises)
		{
			int id = UserInput.GetIdOfExercise(exercises);
			return id;
		}
		internal static ExerciseModel GetUpdateInfo(ExerciseModel exercise)
		{
			var updatedExercise = UserInput.GetUpdatedInfo(exercise);
			return updatedExercise;
		}
	}
}
