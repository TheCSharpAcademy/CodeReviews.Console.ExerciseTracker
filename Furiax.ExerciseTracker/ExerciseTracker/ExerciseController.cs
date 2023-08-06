using ExerciseTracker.Models;
using ExerciseTracker.Repositories;
using Spectre.Console;

namespace ExerciseTracker
{
	public class ExerciseController
	{
		//private readonly IExerciseRepository _exerciseRepository;
		//public ExerciseController(IExerciseRepository exerciseRepository)
		//{
		//	_exerciseRepository = exerciseRepository;
		//}
		//private readonly ExerciseService _exerciseService;
  //      public ExerciseController(ExerciseService exerciseService)
  //      {
  //          _exerciseService = exerciseService;
  //      }
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
	}
}
