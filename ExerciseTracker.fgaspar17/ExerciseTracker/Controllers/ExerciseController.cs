using Spectre.Console;

namespace ExerciseTracker;

public class ExerciseController : IExerciseController
{
    private readonly IRepository<Exercise> _repository;

    public ExerciseController(IRepository<Exercise> repository)
    {
        _repository = repository;
    }

    public IEnumerable<Exercise> GetExercises() => _repository.GetAll();
    public Exercise? GetExerciseById(int id) => _repository.GetById(id);
    public bool CreateExercise(Exercise exercise)
    {
        try
        {
            _repository.Add(exercise);
            return true;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return false;
        }
    }
    public bool UpdateExercise(Exercise exercise)
    {
        try
        {
            _repository.Update(exercise);
            return true;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return false;
        }
    }
    public bool DeleteExercise(Exercise exercise)
    {
        try
        {
            _repository.Delete(exercise);
            return true;
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return false;
        }
    }
}