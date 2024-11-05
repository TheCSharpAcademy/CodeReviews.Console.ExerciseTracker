using ExerciseTracker.hasona23.Enums;
using ExerciseTracker.hasona23.Handlers;
using ExerciseTracker.hasona23.Models;
using ExerciseTracker.hasona23.Services;

namespace ExerciseTracker.hasona23.Controllers;

public class ExerciseController(ExerciseService exerciseService)
{
    private void AddExercise()
    {
        //TODO:  to get exerciseCreate
        //exerciseService.AddExercise(exercise);
        throw new NotImplementedException();
    }

    private void UpdateExercise()
    {
        //TODO: Get Update exercise
        //exerciseService.UpdateExercise(exercise);
        throw new NotImplementedException();
    }

    private void DeleteExercise()
    {
        //TODO: Get the id of deleted exercide
        //exerciseService.DeleteExercise();
        throw new NotImplementedException();
    }

    private void GetAllExercises()
    {
        VisualisationHandler.DisplayExercisesTable(exerciseService.GetAllExercises());
    }
    
    public void HandleExercises()
    {
        switch (MenuBuilder.GetExerciseOption())
        {
            case ExerciseOptions.Add:
                AddExercise();
                break;
            case ExerciseOptions.Delete:
                DeleteExercise();
                break;
            case ExerciseOptions.Update:
                UpdateExercise();
                break;
            case ExerciseOptions.ReadAll:
                GetAllExercises();
                break;
        }
    }
}