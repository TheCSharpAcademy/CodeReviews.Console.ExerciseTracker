using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class HistoryView(IExerciseController exerciseController)
{
    private readonly IExerciseController _exerciseController = exerciseController;
    private IUpdateView UpdateView { get; set; }
    
    internal void Run(MenuOptions selectedMenu, UserInterfaceOptions selectedSession)
    {
        bool endMainMenu = false;
        if (selectedSession == UserInterfaceOptions.Cardio)
            UpdateView = new UpdateCardioView(exerciseController);
        else if (selectedSession == UserInterfaceOptions.Weights)
            UpdateView = new UpdateWeightsView(exerciseController);
        
        while (!endMainMenu)
        {
            Console.Clear(); 
            
            string exerciseText = string.Empty;
            if (UpdateView is UpdateCardioView)
                exerciseText = "Cardio";
            else if (UpdateView is UpdateWeightsView)
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
                    UpdateView.Run(selectedEnum);
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