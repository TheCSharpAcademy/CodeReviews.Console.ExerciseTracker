using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class WeightView(IExerciseController controller)
{
    private readonly IExerciseController _weightController = controller;
    private readonly HistoryView _historyView = new HistoryView(controller);
    internal void Run(UserInterfaceOptions selectedEnum)
    {
        bool endWeight = false;
        while (!endWeight)
        {
            Console.Clear();
            ViewExtensions.GetEnumDescription(selectedEnum);
            var enumChoice = ViewExtensions.GetViewChoice<MenuOptions>();
            switch (enumChoice)
            {
                case MenuOptions.Add:
                    Console.Clear();
                    ViewExtensions.GetEnumDescription(enumChoice, "Weights");
                    _weightController.Add();
                    break;
                case MenuOptions.History:
                    _historyView.Run(enumChoice, selectedEnum);
                    break;
                case MenuOptions.Exit:
                    endWeight = true;
                    break;
            }
        }
    }
}