using ExerciseTracker.wkktoria.Data.Models;

namespace ExerciseTracker.wkktoria.Data.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly AppDbContext _context;

    public ExerciseRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Exercise> GetAllExercises()
    {
        try
        {
            return _context.Exercises.ToList();
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't retrieve entities: {e.Message}");
        }
    }

    public Exercise? GetExercise(int id)
    {
        try
        {
            return _context.Exercises.FirstOrDefault(exercise => exercise.Id == id);
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't retrieve entity: {e.Message}");
        }
    }

    public Exercise AddExercise(Exercise exercise)
    {
        if (exercise == null) throw new ArgumentNullException(nameof(exercise));

        try
        {
            _context.Add(exercise);
            _context.SaveChanges();

            return exercise;
        }
        catch (Exception e)
        {
            throw new Exception($"{nameof(exercise)} could not be saved: {e.Message}");
        }
    }

    public Exercise UpdateExercise(int id, Exercise updatedExercise)
    {
        if (updatedExercise == null)
            throw new ArgumentNullException(nameof(updatedExercise));
        if (id != updatedExercise.Id) throw new ArgumentException("Invalid arguments");

        try
        {
            _context.Update(updatedExercise);
            _context.SaveChanges();

            return updatedExercise;
        }
        catch (Exception e)
        {
            throw new Exception($"{nameof(updatedExercise)} could not be updated: {e.Message}");
        }
    }

    public void DeleteExercise(int id, Exercise exerciseToDelete)
    {
        if (exerciseToDelete == null)
            throw new ArgumentNullException(nameof(exerciseToDelete));
        if (id != exerciseToDelete.Id) throw new ArgumentException("Invalid arguments");

        try
        {
            _context.Remove(exerciseToDelete);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception($"{nameof(exerciseToDelete)} could not be deleted: {e.Message}");
        }
    }
}