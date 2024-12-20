using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class HistoryView(IExerciseController exerciseController)
{
    private readonly IExerciseController _exerciseController = exerciseController;
    private UpdateView _updateView { get; set; }
    
    internal void Run(MenuOptions selectedMenu, UserInterfaceOptions selectedSession)
    {
        bool endMainMenu = false;
        if (selectedSession == UserInterfaceOptions.Cardio)
            _updateView = new UpdateCardioView(exerciseController);
        else if (selectedSession == UserInterfaceOptions.Weights)
            _updateView = new UpdateWeightsView(exerciseController);
        
        while (!endMainMenu)
        {
            Console.Clear(); 
            
            string exerciseText = string.Empty;
            if (_updateView is UpdateCardioView)
                exerciseText = "Cardio";
            else if (_updateView is UpdateWeightsView)
                exerciseText = "Weights";
            
            ViewExtensions.GetEnumDescription(selectedMenu, exerciseText);
            
            var selectedEnum = ViewExtensions.GetViewChoice<HistoryOptions>();
            switch (selectedEnum)
            {
                case HistoryOptions.View:
                    Console.Clear();
                    _exerciseController.ViewAll();
                    Util.AskUserToContinue();
                    break;
                case HistoryOptions.Update:
                    _updateView.Run(selectedEnum);
                    break;
                case HistoryOptions.Delete:
                    Console.Clear();
                    ViewExtensions.GetEnumDescription(selectedEnum, exerciseText);
                    _exerciseController.Delete();
                    break;
                case HistoryOptions.Exit:
                    endMainMenu = true;
                    break;
            }
        }
    }
}