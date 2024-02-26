using ExerciseTracker.StanimalTheMan;
using ExerciseTracker.StanimalTheMan.Controllers;
using ExerciseTracker.StanimalTheMan.Data;
using ExerciseTracker.StanimalTheMan.Repository;
using ExerciseTracker.StanimalTheMan.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

class Program
{
	static void Main(string[] args)
	{
		var connectionString = "Server=(LocalDb)\\LocalDBDemo;Database=Runs;Integrated Security=True;Encrypt=False";

		// Configure dependency injection container
		var serviceProvider = new ServiceCollection()
			.AddDbContext<ExerciseContext>(options =>
				options.UseSqlServer(connectionString))
			.AddSingleton<IExerciseRepository, ExerciseRepository>()
			.AddTransient<ExerciseService>()
			.AddTransient<ExerciseController>()
			.BuildServiceProvider();

		var exerciseController = serviceProvider.GetService<ExerciseController>();

		// Use exerciseController to interact with the application
		UserInput.ShowMainMenu(exerciseController);
	}


}
