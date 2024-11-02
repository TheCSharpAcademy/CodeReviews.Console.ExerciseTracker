using ExerciseTracker.hasona23.Data;
using ExerciseTracker.hasona23.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.hasona23.Repository;

public class ExerciseRepository : IExerciseRepository
{ 
    private readonly ExerciseTrackerContext _context;

    public ExerciseRepository()
    {
        _context = new ExerciseTrackerContext();
        _context.Database.Migrate();
    }

    public List<Exercise> GetAllExercises()
    {
        return _context.Exercises.ToList();
    }

    public Exercise? GetExercise(int id)
    {
        return _context.Exercises.Find(id);
    }

    public void AddExercise(ExerciseCreate exercise)
    {
        _context.Exercises.Add(new Exercise(exercise));
        _context.SaveChanges();
    }

    public bool UpdateExercise(ExerciseUpdate newExercise)
    {
        throw new NotImplementedException();
    }

    public bool DeleteExercise(int id)
    {
        throw new NotImplementedException();
    }
    
}