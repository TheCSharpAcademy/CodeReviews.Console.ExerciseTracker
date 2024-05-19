using ExerciceTracker.Cactus;

namespace ExerciseTracker.Cactus
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
