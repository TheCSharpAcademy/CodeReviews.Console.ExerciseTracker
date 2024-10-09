using Exercise_Tracker.Challenge.Services;
using Spectre.Console;

namespace Exercise_Tracker.Challenge.Controllers;

public class CardioController
{
    private readonly CardioService _service;
    private readonly UserInput _userInput;
    public CardioController(CardioService service, UserInput userInput)
    {
        _service = service;
        _userInput = userInput;
    }
    public async Task Run()
    {
        bool exitApp = false;


        while (!exitApp)
        {
            Console.Clear();
            View.RenderTitle("Cardio (Raw SQL)", Color.CadetBlue, Color.Teal, "CARDIO DATA", "red", BoxBorder.Heavy);
            var selection = _userInput.ChooseCardioDataOperation();

            switch (selection)
            {
                case "Get All Cardios":
                    Console.Clear();
                    await GetAllExercises();
                    break;

                case "Create Cardio":
                    Console.Clear();
                    await CreateExercise();
                    break;

                case "Update Cardio":
                    Console.Clear();
                    var exercises = await _service.GetAllAsync();
                    if (exercises is null) return;

                    await UpdateExercise(exercises);
                    break;

                case "Delete Cardio":
                    Console.Clear();
                    exercises = await _service.GetAllAsync();
                    if (exercises is null) return;

                    await DeleteExercise(exercises);
                    break;
                case "Go Back To Menu":
                    Console.Clear();
                    exitApp = true;
                    break;
            }
        }
    }

    private async Task GetAllExercises()
    {
        var exercises = await _service.GetAllAsync();
        if (exercises is null) return;

        View.RenderTable(exercises, Color.GreenYellow);
        AnsiConsole.MarkupLine("[grey bold](Please 'enter' to continue')[/]");
        Console.ReadLine();
    }

    private async Task CreateExercise()
    {
        var exercise = _userInput.CreateExercise();
        Console.Clear();
        if (exercise == null) return;

        var createdExercise = await _service.CreateAsync(exercise);
        if (createdExercise == null)
        {
            View.RenderResult("Creation of Exercise Falied!!", "red", Color.Red1);
            Console.ReadLine();
        }
        else
        {
            View.RenderTable(new List<Exercise>() { createdExercise }, Color.Aqua);
            View.RenderResult($"Exercise with Id {createdExercise.Id} created", "green", Color.Green3);
            Console.ReadLine();
        }
    }

    private async Task UpdateExercise(List<Exercise> exercises)
    {
        View.RenderTable(exercises, Color.GreenYellow);
        if (exercises.Count() == 0)
        {
            AnsiConsole.MarkupLine("[grey bold](Press 'enter' to continue)[/]");
            Console.ReadLine();
        }
        else
        {
            var updateExercise = _userInput.ChooseUpdateExercise(exercises);
            if (updateExercise == null) return;

            var updatedExercise = await _service.UpdateAsync(updateExercise);
            Console.Clear();
            if (updatedExercise == null)
            {
                View.RenderResult("Creation of Exercise Falied!!", "red", Color.Red1);
                Console.ReadLine();
            }
            else
            {
                View.RenderTable(new List<Exercise>() { updatedExercise }, Color.Aqua);
                View.RenderResult($"Exercise with Id {updatedExercise.Id} Updated", "yellow", Color.Yellow3);
                Console.ReadLine();
            }

        }
    }

    private async Task DeleteExercise(List<Exercise> exercises)
    {
        View.RenderTable(exercises, Color.Red3_1);
        if (exercises.Count() == 0)
        {
            AnsiConsole.MarkupLine("[grey bold](Press 'enter' to continue)[/]");
            Console.ReadLine();
        }
        else
        {
            var deleteExercise = _userInput.ChooseDeleteExercise(exercises);
            if (deleteExercise == null) return;

            var deletedExercise = await _service.DeleteAsync(deleteExercise);
            Console.Clear();
            if (deletedExercise == null)
            {
                View.RenderResult("Creation of Exercise Falied!!", "red", Color.Red1);
                Console.ReadLine();
            }
            else
            {
                View.RenderTable(new List<Exercise>() { deletedExercise }, Color.Aqua);
                View.RenderResult($"Exercise with Id {deletedExercise.Id} Deleted", "red", Color.Red3);
                Console.ReadLine();
            }
        }
    }
}
