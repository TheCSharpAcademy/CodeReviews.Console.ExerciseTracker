using ExerciseTracker.kjanos89.Models;
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
    public Input input;

    public Controller(Service _service)
    {
        service = _service;
        input = new Input();
    }
    public void ShowMenu()
    {
        Console.Clear();
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
                GetAll();
                break;
            case '2':
                Add();
                break;
            case '3':
                Read();
                break;
            case '4':
                Update();
                break;
            case '5':
                Delete();
                break;
            default:
                Console.WriteLine("Wrong input, try again!");
                Task.Delay(1000).Wait();
                ShowMenu();
                break;
        }
    }

    private void Delete()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void Read()
    {
        throw new NotImplementedException();
    }

    public void GetAll()
    {
        Console.Clear();
        IEnumerable<Exercise> list = service.ListAll();
        foreach (Exercise exercise in list)
        {
            Console.WriteLine($"Id: {exercise.Id}, Start date: {exercise.Start}, End date: {exercise.End}, Whole duration: {exercise.Duration}, Comment: {exercise.Comments}.");
        }
        Console.WriteLine("\nPressing any button will return to the menu.");
        Console.ReadKey();
        ShowMenu();
        return;
    }

    public void Add()
    {
        Console.Clear();
        var exercise = input.GetExerciseData();
        if (exercise != null)
        {
            service.AddExercise(exercise.Start, exercise.End, exercise.Duration, exercise.Comments);
        }
        else
        {
            Console.WriteLine("Returned input not acceptable, returning to the menu.");
            ShowMenu();
            return;
        }
        ShowMenu();
        return;
    }
}