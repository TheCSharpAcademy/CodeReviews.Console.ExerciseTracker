using ExerciseTracker.Models;
using ExerciseTracker.Repositories;

namespace ExerciseTracker.Controllers;

public class ExerciseController
{

    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseController(IExerciseRepository excerciseRepository)
    {
        _exerciseRepository = excerciseRepository;
    }

    public Exercise AddExercise(Exercise exercise)
    {
        exercise = _exerciseRepository.Insert(exercise);
        _exerciseRepository.Save();
        return exercise;

    }

    public void DeleteExercise(Exercise exercise)
    {
        _exerciseRepository.Delete(exercise);
        _exerciseRepository.Save();
    }

    public List<Exercise> GetAllExercises()
    {

        return _exerciseRepository.GetAll().ToList();

    }

    public Exercise UpdateExercise(Exercise exercise)
    {
        _exerciseRepository.Update(exercise);
        _exerciseRepository.Save();
        return exercise;
    }
}
