using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class UpdateCardioView(IExerciseController exerciseController)  : UpdateView
{
    private readonly IExerciseController _exerciseController = exerciseController;
    public void Run(Enum SelectedEnum)
    {
        bool endUpdate = false;
        while (!endUpdate)
        {
            Console.Clear();
            ViewExtensions.GetEnumDescription(SelectedEnum, "Cardio");
            var selectedEnum = ViewExtensions.GetViewChoice<UpdateCardioOptions>();

            switch (selectedEnum)
            {
                case UpdateCardioOptions.Start:
                    _exerciseController.Update(updateStart : true);
                    break;
                case UpdateCardioOptions.Finish:
                    _exerciseController.Update(updateFinish: true);
                    break;
                case UpdateCardioOptions.Comments:
                    _exerciseController.Update(updateComments: true);
                    break;
                case UpdateCardioOptions.Distance:
                    _exerciseController.Update(updateDistance: true);
                    break;
                case UpdateCardioOptions.All:
                    _exerciseController.Update(
                        updateStart: true,
                        updateFinish: true,
                        updateDistance : true,
                        updateComments: true
                        );
                    break;
                case UpdateCardioOptions.Exit:
                    endUpdate = true;
                    break;
            }
        }
    }
}