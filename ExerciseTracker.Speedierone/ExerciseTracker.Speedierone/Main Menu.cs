using ExerciseTracker.Speedierone.Model;
using ExerciseTracker.Speedierone.Repository;

namespace ExerciseTracker.Speedierone
{
    public class Main_Menu
    {
       private readonly IExerciseRepository _exerciseService;
        private readonly UserInput _userInput;
        public Main_Menu(IExerciseRepository exerciseService, UserInput userInput)
        {
            _exerciseService = exerciseService;
            _userInput = userInput;
        }
        public void ShowMenu()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("Welcome to the exercise tracker app");
                Console.WriteLine("Please choose from the following options");
                Console.WriteLine("0 = Exit Program");
                Console.WriteLine("1 = View all exercises");
                Console.WriteLine("2 = View exercises by Id");
                Console.WriteLine("3 = Add new exercise");
                Console.WriteLine("4 = Update current exercise");
                Console.WriteLine("5 = Delete exercise");

                var command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        var tableList = _exerciseService.GetAll();
                        TableLayout.DisplayTableAll(tableList);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("Please enter Id of record you wish to view.");
                        var id = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                        var tableListId = _exerciseService.GetById(id);
                        TableLayout.DisplayTable(tableListId);
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Exercises newExercise = _userInput.GetSession();
                        _exerciseService.Add(newExercise);
                        Console.WriteLine("New sessions added.");
                        break;

                    case "4":
                        var viewTable = _exerciseService.GetAll();
                        TableLayout.DisplayTableAll(viewTable);
                        Console.WriteLine("Please enter ID of record you wish to update.");
                        if(int.TryParse(Console.ReadLine(), out id))
                        {
                            List<Exercises> exerciseList = _exerciseService.GetById(id);

                            if(exerciseList.Count > 0)
                            {
                                Exercises exerciseToUpdate = exerciseList[0];
                                _exerciseService.Update(exerciseToUpdate);
                                Console.WriteLine("Session Updated. Press any key to continue.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Exercise not found.");
                            }
                        }                      
                        break;

                    case "5":
                        var viewToDelete = _exerciseService.GetAll();
                        TableLayout.DisplayTableAll(viewToDelete);
                        Console.WriteLine("Please enter ID of session you wish to delete.");
                        var deleteId = Int32.Parse(Console.ReadLine());
                        _exerciseService.Delete(deleteId);
                        Console.WriteLine("Record deleted");
                        break;

                    default:
                        Console.WriteLine("Invalid entry.");
                        command = Console.ReadLine();
                        break;
                }
            }
        }
    }
}
