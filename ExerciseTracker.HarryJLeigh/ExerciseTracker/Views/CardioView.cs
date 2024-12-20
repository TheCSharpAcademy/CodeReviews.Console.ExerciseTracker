using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class CardioView(IExerciseController controller)
{
    private readonly IExerciseController _cardioController = controller;
    private readonly HistoryView _historyView = new HistoryView(controller);
    internal void Run(UserInterfaceOptions selectedEnum)
    {
        bool endCardio = false;
        while (!endCardio)
        {
            Console.Clear();
            ViewExtensions.GetEnumDescription(selectedEnum);
            var enumChoice = ViewExtensions.GetViewChoice<MenuOptions>();

            switch (enumChoice)
            {
                case MenuOptions.Add:
                    Console.Clear();
                    ViewExtensions.GetEnumDescription(enumChoice, "Cardio");
                    _cardioController.Add();
                    break;
                case MenuOptions.History:
                    _historyView.Run(enumChoice, selectedEnum);
                    break;
                case MenuOptions.Exit:
                    endCardio = true;
                    break;
            }
        }
    }
}