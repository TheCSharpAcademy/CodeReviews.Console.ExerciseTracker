using ExerciseTracker.Mefdev.Models;
using ExerciseTracker.Mefdev.Context;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Mefdev.Repositories;

public class ExerciseRepository : IRepository
{
    private readonly ExerciseContext _context;

    public ExerciseRepository(ExerciseContext context)
    {
        _context = context;
    }
    public void Create(Exercise entity)
    {
        try
        {
            entity.Duration = GetDuration(entity.DateStart, entity.DateEnd);
            _context.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Delete(int id)
    {
         try
        {
            var entity = _context.Exercises.Find(id);
            if(entity is not null){
                _context.Remove(entity);
            }
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IEnumerable<Exercise> GetAll()
    {
        try
        {
             return _context.Exercises.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Exercise? GetById(int id)
    {
        try
        {
            return _context.Exercises.Find(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Update(Exercise entity)
    {
        try
        {
            var exerciseToUpdate = _context.Exercises.Find(entity.Id);
            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.DateStart = entity.DateStart;
                exerciseToUpdate.DateEnd = entity.DateEnd;
                exerciseToUpdate.Duration = GetDuration(entity.DateStart, entity.DateEnd);
                exerciseToUpdate.Comments =entity.Comments;
                exerciseToUpdate.Type = entity.Type;

                _context.Exercises.Update(exerciseToUpdate);
                _context.Entry(exerciseToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
           
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private TimeSpan GetDuration(DateTime start, DateTime end)
    {
        if (end >= start)
        {
            return end - start;
        }
        else
        {
            throw new InvalidOperationException("End date must be after or equal to the start date.");
        }
    }
}