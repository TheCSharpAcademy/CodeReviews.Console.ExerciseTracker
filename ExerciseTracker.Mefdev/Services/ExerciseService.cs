using ExerciseTracker.Mefdev.Models;
using ExerciseTracker.Mefdev.Repositories;

namespace ExerciseTracker.Mefdev.Services;

public class ExerciseService: IExercise
{
    private readonly IRepository _repository;

    public ExerciseService(IRepository repository)
    {
        _repository = repository;
    }

    public bool Create(Exercise entity)
    {
        try
        {
            var previousEntity = _repository.GetById(entity.Id);
            if (previousEntity != null)
            {
                return false;
            }
            _repository.Create(entity);
            return true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return false;
            }
            _repository.Delete(entity.Id);
            return true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Exercise> GetAll()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return null;
        }
    }
       
    public Exercise? GetById(int id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return null;
        }
    }

    public bool Update(Exercise entity)
    {
        try
        {
            var currentEntity = _repository.GetById(entity.Id);
            if (currentEntity is null)
            {
                return false;
            }
            _repository.Update(entity);
            return true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return false;
        }
    }
}