using System.Data.Common;
using ExerciseTracker.StevieTV.Database;
using ExerciseTracker.StevieTV.Models;
using ExerciseTracker.StevieTV.Repositories;

namespace ExerciseTracker.StevieTV.Services;

public class ExerciseService : IExerciseRepository
{
    private readonly ExerciseContext _exerciseContext;

    public ExerciseService(ExerciseContext exerciseContext)
    {
        _exerciseContext = exerciseContext;
    }

    public List<Exercise> GetExercises()
    {
        return _exerciseContext.Exercises.ToList();
    }

    public bool AddExercise(Exercise exercise)
    {
        _exerciseContext.Exercises.Add(exercise);

        try
        {
            _exerciseContext.SaveChanges();
        }
        catch (DbException)
        {
            return false;
        }

        return true;
    }

    public bool RemoveExercise(Exercise exercise)
    {
        _exerciseContext.Exercises.Remove(exercise);

        try
        {
            _exerciseContext.SaveChanges();
        }
        catch (DbException)
        {
            return false;
        }

        return true;
    }
}