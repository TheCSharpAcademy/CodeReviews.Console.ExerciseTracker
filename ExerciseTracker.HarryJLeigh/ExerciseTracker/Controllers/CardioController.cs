using ExerciseTracker.Models;
using ExerciseTracker.Services;
using ExerciseTracker.Utilities;
using ExerciseTracker.Views;

namespace ExerciseTracker.Controllers;

public class CardioController(IExerciseService<Cardio> cardioService) : IExerciseController
{
    private readonly IExerciseService<Cardio> _cardioService = cardioService;

    public void ViewAll()
    {
        var cardioSessions = _cardioService.GetAllExercises().ToList();
        if (Util.SessionsAvailable(cardioSessions))
        {
            TableVisualisation.ShowCardioTable(cardioSessions);
            return;
        }
        Util.DisplayNoSessionsMessage("cardio");
    }

    public void Add()
    {
        if (Util.ReturnToMenu()) return;
        Cardio cardio = ExerciseExtensions.CreateCardio();
        _cardioService.AddExercise(cardio);
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
        if (Util.ReturnToMenu()) return;
        ViewAll();

        List<Cardio> cardioSessions = _cardioService.GetAllExercises().ToList();
        if (!Util.SessionsAvailable(cardioSessions)) return;

        int cardioId = UserInput.IdPrompt(cardioSessions);

        Cardio exerciseToUpdate = _cardioService.GetById(cardioId);

        if (updateStart)
            exerciseToUpdate.DateStart = ExerciseExtensions.GetExerciseStart(exerciseToUpdate.DateEnd, true);
        if (updateFinish) exerciseToUpdate.DateEnd = ExerciseExtensions.GetExerciseEnd(exerciseToUpdate.DateStart);
        if (updateDistance) exerciseToUpdate.Distance = ExerciseExtensions.GetDistance();
        if (updateComments) exerciseToUpdate.Comments = ExerciseExtensions.GetExerciseComments();

        if (updateStart || updateFinish)
            exerciseToUpdate.Duration = ExerciseExtensions.CalculateDuration(
                exerciseToUpdate.DateStart,
                exerciseToUpdate.DateEnd);

        _cardioService.UpdateExercise(exerciseToUpdate);
    }

    public void Delete()
    {
        if (Util.ReturnToMenu()) return;
        ViewAll();

        List<Cardio> cardioSessions = _cardioService.GetAllExercises().ToList();
        if (!Util.SessionsAvailable(cardioSessions)) return;

        int exerciseId = UserInput.IdPrompt(cardioSessions);
        _cardioService.DeleteExercise(exerciseId);
    }
}