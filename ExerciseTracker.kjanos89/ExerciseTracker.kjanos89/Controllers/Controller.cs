using ExerciseTracker.kjanos89.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.kjanos89.Controllers;

public class Controller
{
    private readonly Service service;

    public Controller(Service _service)
    {
        service = _service;
    }
    public void ShowMenu()
    {
        Console.WriteLine("Choose an option from below:");
        Console.WriteLine("1 - List every record");
        Console.WriteLine("2 - Add record");
        Console.WriteLine("3 - Get a record by id");
        Console.WriteLine("4 - Update a record by id");
        Console.WriteLine("5 - Delete a record by id");
        Console.WriteLine("0 - Exit");
        string choice = Console.ReadLine();
        while (String.IsNullOrEmpty(choice))
        {
            Console.WriteLine("Wrong input, please try again!");
            choice = Console.ReadLine();
        }
        Selection(choice[0]);
    }
    public void Selection(char choice)
    {
        switch (choice)
        {
            case '0':
                Environment.Exit(0);
                break;
            case '1':
                service.ListAll();
                break;
            case '2':
                service.AddExercise();
                break;
            case '3':
                service.ReadExercise();
                break;
            case '4':
                service.UpdateExercise();
                break;
            case '5':
                service.DeleteExercise();
                break;
            default:
                Console.WriteLine("Wrong input, try again!");
                Task.Delay(1000).Wait();
                ShowMenu();
                break;
        }
    }
}