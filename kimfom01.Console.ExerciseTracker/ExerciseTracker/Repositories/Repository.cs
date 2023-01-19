using ExerciseTracker.Data;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

public abstract class Repository : IRepository
{
    private readonly ExerciseContext _exerciseContext;

    public Repository(ExerciseContext exerciseContext)
    {
        _exerciseContext = exerciseContext;
    }

    public virtual IEnumerable<Exercise> GetExercises()
    {
        return _exerciseContext.Exercises;
    }

    public virtual Exercise GetExerciseById(int id)
    {
        return _exerciseContext.Exercises.FirstOrDefault(x => x.Id == id);
    }

    public virtual void AddExercise(Exercise exercise)
    {
        _exerciseContext.Add(exercise);
    }

    public virtual void UpdateExercise(int id, Exercise exercise)
    {
        var exerciseToBeUpdated = GetExerciseById(id);

        exerciseToBeUpdated.EndDate = exercise.EndDate;
        exerciseToBeUpdated.Duration = exercise.Duration;
        exerciseToBeUpdated.Comments = exercise.Comments;
    }

    public virtual void DeleteExercise(int id)
    {
        var exerciseToBeDeleted = GetExerciseById(id);
        _exerciseContext.Remove(exerciseToBeDeleted);
    }

    public virtual int SaveChanges()
    {
        return _exerciseContext.SaveChanges();
    }
}