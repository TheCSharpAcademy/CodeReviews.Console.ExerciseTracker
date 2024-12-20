using ExerciseTracker.Controllers;
using ExerciseTracker.Enums;
using ExerciseTracker.Utilities;

namespace ExerciseTracker.Views;

public class UpdateWeightsView(IExerciseController exerciseController) : UpdateView
{
    private readonly IExerciseController _exerciseController = exerciseController;
    public void Run(Enum SelectedEnum)
    {
        bool endUpdate = false;
        while (!endUpdate)
        {
            Console.Clear();
            ViewExtensions.GetEnumDescription(SelectedEnum, "Weights");
            var selectedEnum = ViewExtensions.GetViewChoice<UpdateWeightOptions>();

            switch (selectedEnum)
            {
                case UpdateWeightOptions.Start:
                    _exerciseController.Update(updateStart : true);
                    break;
                case UpdateWeightOptions.Finish:
                    _exerciseController.Update(updateFinish: true);
                    break;
                case UpdateWeightOptions.Comments:
                    _exerciseController.Update(updateComments: true);
                    break;
                case UpdateWeightOptions.Sets:
                    _exerciseController.Update(updateSets: true);
                    break;
                case UpdateWeightOptions.TotalWeight:
                    _exerciseController.Update(updateTotalWeight: true);
                    break;
                case UpdateWeightOptions.All:
                    _exerciseController.Update(
                        updateStart: true,
                        updateFinish: true,
                        updateSets: true,
                        updateTotalWeight: true,
                        updateComments: true
                    );
                    break;
                case UpdateWeightOptions.Exit:
                    endUpdate = true;
                    break;
            }
        }
    }
}