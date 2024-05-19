using ExerciseTracker.Cactus.Service;

namespace ExerciseTracker.Cactus.Controller
{
    public class ExerciseController
    {
        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public void MainMenu()
        {
            Console.WriteLine("MainMenu");
        }
    }
}
