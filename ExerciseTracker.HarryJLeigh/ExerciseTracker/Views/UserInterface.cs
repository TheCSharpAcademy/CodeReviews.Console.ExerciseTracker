using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class UserInterface(IExerciseController weightController, IExerciseController cardioController)
{
    private readonly WeightView _weightView = new WeightView(weightController);
    private readonly CardioView _cardioView = new CardioView(cardioController);

    internal void Run()
    {
        bool endMainMenu = false;
        while (!endMainMenu)
        {
            Console.Clear();
            var selectedEnum = ViewExtensions.GetViewChoice<UserInterfaceOptions>();
            
            switch (selectedEnum)
            {
                case UserInterfaceOptions.Weights:
                    _weightView.Run(selectedEnum);
                    break;
                case UserInterfaceOptions.Cardio:
                    _cardioView.Run(selectedEnum);
                    break;
                case UserInterfaceOptions.Exit:
                    endMainMenu = true;
                    break;
            }
        }
    }
}