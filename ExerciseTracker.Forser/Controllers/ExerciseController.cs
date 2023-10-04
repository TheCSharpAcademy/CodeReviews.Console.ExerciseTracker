namespace ExerciseTracker.Forser.Controllers
{
    internal class ExerciseController : IExerciseController
    {
        private readonly IExerciseService _exerciseService;
        private readonly IUserInterface _exerciseUI;
        public ExerciseController(IExerciseService exerciseService, IUserInterface userInterface)
        {
            _exerciseService = exerciseService;
            _exerciseUI = userInterface;
        }

        public void Run()
        {
            if (_exerciseService == null)
            {
                throw new ArgumentNullException();
            }
            
            while(true)
            {
                int selectedOption = AnsiConsole.Prompt(Helpers.DisplayMainMenu()).Id;

                switch(selectedOption)
                {
                    case 0:
                        _exerciseService.DisplayExercises();
                        AnsiConsole.WriteLine("Press any key to return to main menu");
                        Console.ReadLine();
                        break;
                    case 1:
                        AddNewExercise();
                        break;
                    case 2:
                        DeleteExercise();
                        AnsiConsole.WriteLine("Press any key to return to main menu");
                        Console.ReadLine();
                        break;
                    case -1:
                        AnsiConsole.WriteLine("Goodbye!");
                        return;
                    default:
                        break;
                }
            }
        }
        private void DeleteExercise()
        {
            _exerciseService.DisplayExercises();
            int id = _exerciseUI.GetExerciseId(AnsiConsole.Ask<int>("Which exercise do you want to delete?"));
            if(id == -1) { return; }
            _exerciseService.DeleteExercise(id);
        }
        private void AddNewExercise()
        {
            DisplayNewExerciseView(out DateTime startDate, out DateTime endDate, out string? comments);
            bool isSaved = _exerciseService.AddExercise(startDate, endDate, comments);
            if(isSaved)
            {
                AnsiConsole.WriteLine("Exercise has been saved");
            }
            else
            {
                AnsiConsole.WriteLine("Exercise has not been saved");
            }
            AnsiConsole.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }
        private void DisplayNewExerciseView(out DateTime startDate, out DateTime endDate, out string? comments)
        {
            AnsiConsole.Clear();
            Helpers.RenderTitle("Add new exercise");

            startDate = AnsiConsole.Ask<DateTime>("What date did you start this exercise? Format : dd/MM/yyyy HH:mm:ss");
            endDate = AnsiConsole.Ask<DateTime>("What date did you finish this exercise? Format : dd/MM/yyyy HH:mm:ss");
            AnsiConsole.WriteLine("Any comments for this exercise?, press enter to continue");
            comments = Console.ReadLine();
        }
    }
}