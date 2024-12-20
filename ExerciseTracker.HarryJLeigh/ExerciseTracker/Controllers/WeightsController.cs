using ExerciseTracker.Models;
using ExerciseTracker.Services;
using ExerciseTracker.Utilities;
using ExerciseTracker.Views;

namespace ExerciseTracker.Controllers;

public class WeightsController(IExerciseService<Weights> weightsService) : IExerciseController
{
    private readonly IExerciseService<Weights> _weightService = weightsService;

    public void ViewAll()
    {
        var weightSessions = _weightService.GetAllExercises().ToList();
        if (Util.SessionsAvailable(weightSessions))
        {
            TableVisualisation.ShowWeightsTable(weightSessions);
            return;
        }

        Util.DisplayNoSessionsMessage("weight");
    }

    public void Add()
    {
        if (Util.ReturnToMenu()) return;
        Weights weight = ExerciseExtensions.CreateWeights();
        _weightService.AddExercise(weight);
    }

    public void Update(
        bool updateStart = false,
        bool updateFinish = false,
        bool updateComments = false,
        bool updateSets = false,
        bool updateTotalWeight = false,
        bool updateDistance = false
    )

    {
        List<Weights> weights = _weightService.GetAllExercises().ToList();
        if (Util.ReturnToMenu()) return;
        ViewAll();
        if (!Util.SessionsAvailable(weights)) return;

        int exerciseId = UserInput.IdPrompt(weights);
        Weights exerciseToUpdate = _weightService.GetById(exerciseId);

        if (updateStart)
            exerciseToUpdate.DateStart = ExerciseExtensions.GetExerciseStart(exerciseToUpdate.DateEnd, true);
        if (updateFinish) exerciseToUpdate.DateEnd = ExerciseExtensions.GetExerciseEnd(exerciseToUpdate.DateStart);
        if (updateSets) exerciseToUpdate.Sets = ExerciseExtensions.GetSets();
        if (updateTotalWeight) exerciseToUpdate.TotalWeight = ExerciseExtensions.GetTotalWeight();
        if (updateComments) exerciseToUpdate.Comments = ExerciseExtensions.GetExerciseComments();
       

        if (updateStart || updateFinish)
            exerciseToUpdate.Duration = ExerciseExtensions.CalculateDuration(
                exerciseToUpdate.DateStart,
                exerciseToUpdate.DateEnd);

        _weightService.UpdateExercise(exerciseToUpdate);
    }

    public void Delete()
    {
        if (Util.ReturnToMenu()) return;
        ViewAll();

        List<Weights> weights = _weightService.GetAllExercises().ToList();
        if (!Util.SessionsAvailable(weights)) return;
        
        int exerciseId = UserInput.IdPrompt(weights);
        _weightService.DeleteExercise(exerciseId);
    }
}