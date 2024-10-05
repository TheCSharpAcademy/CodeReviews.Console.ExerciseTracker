using Spectre.Console;

namespace Exercise_Tracker.Challenge.Controllers;

public class ApplicationController
{
    private readonly UserInput _userInput;
    private readonly CardioController _cardioController;
    private readonly WeightController _weightController;
    public ApplicationController(UserInput userInput, CardioController cardioController, WeightController weightController)
    {
       _userInput = userInput; 
       _cardioController = cardioController;
       _weightController = weightController;
    }
    public async Task Run()
    {
        bool exitApp = false;

        while(!exitApp)
        {
            Console.Clear();
            View.RenderTitle("Exercise-Tracker (Challenge)", Color.DarkSeaGreen3, Color.Fuchsia, "APPLICATION", "blue3", BoxBorder.Double);
            
            var option = _userInput.ChooseExerciseType();

            switch(option)
            {
                case "Weights (EF Core)":
                    await _weightController.Run();
                    break;

                case "Cardio (Raw SQL)":
                    await _cardioController.Run();
                    break;

                case "Exit":
                    Console.Clear();
                    View.RenderTitle("Have a nice day!!", Color.DarkSeaGreen3, Color.Fuchsia, "APPLICATION", "blue3", BoxBorder.Double);
                    exitApp = true;
                    break;
            }
            

        }
    }
}
