using ExerciseTracker.StevieTV.Models;
using ExerciseTracker.StevieTV.Repositories;

namespace ExerciseTracker.StevieTV.Controllers;

public class ExerciseController : IExerciseController
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public List<Exercise> GetExercises()
    {
        return _exerciseRepository.GetExercises();
    }

    public bool AddExercise(Exercise exercise)
    {
        return _exerciseRepository.AddExercise(exercise);
    }

    public bool RemoveExercise(Exercise exercise)
    {
        return _exerciseRepository.RemoveExercise(exercise);
    }
}