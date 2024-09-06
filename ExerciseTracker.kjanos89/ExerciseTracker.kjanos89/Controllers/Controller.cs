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

    }
    public void Selection(string choice)
    {

    }
}