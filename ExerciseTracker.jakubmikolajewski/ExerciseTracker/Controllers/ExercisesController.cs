using ExerciseTracker.Models;
using ExerciseTracker.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseTracker.Controllers;
internal class ExercisesController
{
    private readonly ServiceProvider _provider;
    private IExerciseService? _service;

    public ExercisesController(ServiceProvider provider)
    {
        _provider = provider;
    }

    private IExerciseService Service
    {
        get => _service = _provider.GetService<IExerciseService>() ?? throw new NullReferenceException();
    }

    public void CreateDatabase()
    {
        Service.CreateDatabase();
    }

    public List<Exercise> GetAllExercises()
    {
        return Service.GetAllExercises();
    }

    public void AddExercise(Exercise exercise)
    {
        Service.AddExercise(exercise);
    }

    public void UpdateExercise(Exercise exercise)
    {
        Service.UpdateExercise(exercise);
    }

    public void DeleteExercise(Exercise exercise)
    {
        Service.DeleteExercise(exercise);
    }
}
