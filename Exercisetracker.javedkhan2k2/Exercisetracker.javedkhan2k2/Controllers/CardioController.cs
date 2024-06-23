using Exercisetacker.Services.Interfaces;
using Exercisetacker.UI;

namespace Exercisetacker.Controllers;

public class CardioController
{
    private readonly ICardioService _cardioService;

    public CardioController(ICardioService cardioService)
    {
        _cardioService = cardioService;
    }

    public async Task DisplayAllExerciseSessions()
    {
        var cardios = await _cardioService.GetAllExercises();
        VisualizationEngine.DisplayAllExercises(cardios, "Showing All Cardio Sessions");
        VisualizationEngine.DisplayContinueMessage();
    }

    internal async Task AddExercise()
    {
        var cardio = UserInput.GetNewExercise();

        if (cardio == null)
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }
        
        var addedcardio = await _cardioService.AddExercise(cardio);
        if (addedcardio == null)
        {
            VisualizationEngine.DisplayFailureMessage("Cardio Session is not added to database.");
        }
        else
        {
            VisualizationEngine.DisplaySuccessMessage("Cardio Session is added to database successfully.");
        }
    }

    internal async Task UpdateExercise()
    {
        var cardios = await _cardioService.GetAllExercises();
        VisualizationEngine.DisplayAllExercises(cardios, "All Cardios Table");
        int cardioId = UserInput.GetIntInput();
        if(cardioId == 0)
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }

        var cardio = await _cardioService.GetExerciseById(cardioId);
        
        if(cardio == null)
        {
            VisualizationEngine.DisplayFailureMessage($"Cardio with id: [green]{cardioId}[/] not found.");
            return;
        }

        if(!UserInput.GetUpdateExercise(cardio))
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }
        if(await _cardioService.UpdateExercise(cardio) == 0)
        {
            VisualizationEngine.DisplayFailureMessage("Cardio is not updated.");
        }
        else
        {
            VisualizationEngine.DisplaySuccessMessage("Cardio is updated.");
        }
    }

    internal async Task DeleteExercise()
    {
        var cardios = await _cardioService.GetAllExercises();
        VisualizationEngine.DisplayAllExercises(cardios, "All Cardios Table");
        int cardioId = UserInput.GetIntInput();
        if(cardioId == 0)
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }

        var cardio = await _cardioService.GetExerciseById(cardioId);
        
        if(cardio == null)
        {
            VisualizationEngine.DisplayFailureMessage($"Cardio with id: [green]{cardioId}[/] not found.");
            return;
        }

        if(await _cardioService.DeleteExercise(cardio) == 0)
        {
            VisualizationEngine.DisplayFailureMessage("Cardio is not updated.");
        }
        else
        {
            VisualizationEngine.DisplaySuccessMessage("Cardio is updated.");
        }
    }
    
}