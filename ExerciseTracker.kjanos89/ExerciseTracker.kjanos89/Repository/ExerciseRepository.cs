using ExerciseTracker.kjanos89.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.kjanos89.Repository;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ExerciseDbContext context;

    public ExerciseRepository(ExerciseDbContext _context)
    {
        context = _context;
    }

    public void Create(Exercise exercise)
    {
       context.Exercises.Add(exercise);
       context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.Remove(id);
        context.SaveChanges();
    }

    public IEnumerable<Exercise> ListAll()
    {
        List<Exercise> list = context.Exercises.ToList();
        return list;
    }

    public Exercise Read(int id)
    {
        return context.Exercises.Find(id);
    }

    public void Update(Exercise exercise)
    {
        var recordToUpdate = context.Exercises.Find(exercise.Id);
        if (recordToUpdate != null)
        {
            recordToUpdate.Start = exercise.Start;
            recordToUpdate.End = exercise.End;
            recordToUpdate.Duration = exercise.Duration;
            recordToUpdate.Comments = exercise.Comments;
        }
        context.Exercises.Update(recordToUpdate);
        context.Entry(recordToUpdate).State = EntityState.Modified;
        context.SaveChanges();
    }
}