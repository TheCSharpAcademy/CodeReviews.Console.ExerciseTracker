using Exercisetacker.Services.Interfaces;
using Exercisetacker.UI;

namespace Exercisetacker.Controllers;

public class JoggingController
{
    private readonly IJoggingService _joggingService;

    public JoggingController(IJoggingService joggingService)
    {
        _joggingService = joggingService;
    }

    public async Task DisplayAllExerciseSessions()
    {
        var joggings = await _joggingService.GetAllExercises();
        VisualizationEngine.DisplayAllExercises(joggings, "Showing All Jogging Sessions");
        VisualizationEngine.DisplayContinueMessage();
    }

    internal async Task AddExercise()
    {
        var jogging = UserInput.GetNewExercise();

        if (jogging == null)
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }
        
        var addedjogging = await _joggingService.AddExercise(jogging);
        if (addedjogging == null)
        {
            VisualizationEngine.DisplayFailureMessage("Jogging Session is not added to database.");
        }
        else
        {
            VisualizationEngine.DisplaySuccessMessage("Jogging Session is added to database successfully.");
        }
    }

    internal async Task UpdateExercise()
    {
        var joggings = await _joggingService.GetAllExercises();
        VisualizationEngine.DisplayAllExercises(joggings, "All Joggings Table");
        int joggingId = UserInput.GetIntInput();
        if(joggingId == 0)
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }

        var jogging = await _joggingService.GetExerciseById(joggingId);
        
        if(jogging == null)
        {
            VisualizationEngine.DisplayFailureMessage($"Jogging with id: [green]{joggingId}[/] not found.");
            return;
        }

        if(!UserInput.GetUpdateExercise(jogging))
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }
        if(await _joggingService.UpdateExercise(jogging) == 0)
        {
            VisualizationEngine.DisplayFailureMessage("Jogging is not updated.");
        }
        else
        {
            VisualizationEngine.DisplaySuccessMessage("Jogging is updated.");
        }
    }

    internal async Task DeleteExercise()
    {
        var joggings = await _joggingService.GetAllExercises();
        VisualizationEngine.DisplayAllExercises(joggings, "All Joggings Table");
        int joggingId = UserInput.GetIntInput();
        if(joggingId == 0)
        {
            VisualizationEngine.DisplayCancelOperation();
            return;
        }

        var jogging = await _joggingService.GetExerciseById(joggingId);
        
        if(jogging == null)
        {
            VisualizationEngine.DisplayFailureMessage($"Jogging with id: [green]{joggingId}[/] not found.");
            return;
        }

        if(await _joggingService.DeleteExercise(jogging) == 0)
        {
            VisualizationEngine.DisplayFailureMessage("Jogging is not updated.");
        }
        else
        {
            VisualizationEngine.DisplaySuccessMessage("Jogging is updated.");
        }
    }
    
}