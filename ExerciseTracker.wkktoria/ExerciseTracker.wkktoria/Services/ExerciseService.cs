using ExerciseTracker.wkktoria.Data.Models;
using ExerciseTracker.wkktoria.Data.Repositories;

namespace ExerciseTracker.wkktoria.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public List<Exercise> GetAllExercises()
    {
        try
        {
            return _exerciseRepository.GetAllExercises();
        }
        catch (Exception)
        {
            throw new Exception("Could not get all exercises");
        }
    }

    public Exercise? GetExercise(int id)
    {
        try
        {
            return _exerciseRepository.GetExercise(id);
        }
        catch (Exception)
        {
            throw new Exception("Could not get exercise");
        }
    }

    public Exercise AddExercise(Exercise exercise)
    {
        try
        {
            return _exerciseRepository.AddExercise(exercise);
        }
        catch (Exception)
        {
            throw new Exception("Could not add exercise");
        }
    }

    public Exercise UpdateExercise(Exercise updatedExercise)
    {
        try
        {
            return _exerciseRepository.UpdateExercise(updatedExercise);
        }
        catch (Exception)
        {
            throw new Exception("Could not update exercise");
        }
    }

    public void DeleteExercise(Exercise exerciseToDelete)
    {
        try
        {
            _exerciseRepository.DeleteExercise(exerciseToDelete);
        }
        catch (Exception)
        {
            throw new Exception("Could not delete exercise");
        }
    }
}