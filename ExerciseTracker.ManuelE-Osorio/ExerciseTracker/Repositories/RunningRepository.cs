using System.Data.Common;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

public class RunningRepository(ExerciseTrackerContext dbContext) : IExerciseRepository<Running>
{
    private readonly ExerciseTrackerContext DbContext = dbContext;

    public bool Insert(Running model)
    {
        DbContext.RunningExercise.Add(model);
        DbContext.SaveChanges();
        return true;
    }
    public IEnumerable<Running>? GetAll()
    {
        return DbContext.RunningExercise.AsEnumerable();
    }
    public Running? GetById(int id)
    {
        return DbContext.RunningExercise.Find(id);
    }

    public bool Update(Running model)
    {
        var runningToUpdate = GetById(model.Id);
        if ( runningToUpdate == null)
            return false;

        DbContext.Entry(runningToUpdate).CurrentValues.SetValues(model);
        DbContext.SaveChanges();
        return true;
    }

    public bool Delete(Running model)
    {
        var runningToDelete = DbContext.RunningExercise.Where(p => p.Id == model.Id).First();
        if ( runningToDelete == null)
            return false;

        DbContext.Remove(runningToDelete);
        DbContext.SaveChanges();
        return true;
    }
}