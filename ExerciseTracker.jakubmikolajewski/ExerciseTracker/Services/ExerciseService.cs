using ExerciseTracker.Data;
using ExerciseTracker.Models;

namespace ExerciseTracker.Services;
internal class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repository;

    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }

    public void CreateDatabase()
    {
        _repository.CreateDatabase();
    }

    public List<Exercise> GetAllExercises()
    {
        return _repository.GetAll();
    }

    public void AddExercise(Exercise exercise)
    {
        _repository.Add(exercise);
        _repository.Save();
    }

    public void DeleteExercise(Exercise exercise)
    {
        _repository.Delete(exercise);
        _repository.Save();
    }

    public void UpdateExercise(Exercise exercise)
    {
        _repository.Update(exercise);
        _repository.Save();
    }
}
