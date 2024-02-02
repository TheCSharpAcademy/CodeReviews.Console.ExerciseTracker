using System.Data.Common;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

public class RunningRepository: IExerciseRepository<Running>
{
    private readonly ExerciseTrackerContext DbContext;
    public RunningRepository(ExerciseTrackerContext dbContext)
    {
        DbContext = dbContext;
    }
    public void Insert(Running model)
    {
        DbContext.RunningExercise.Add(model);
        DbContext.SaveChanges();
    }
    public IEnumerable<Running>? GetAll()
    {
        return DbContext.RunningExercise.AsEnumerable();
    }
    public Running? GetById(int id)
    {
        return DbContext.RunningExercise.Find(id);
    }

    public void Update(Running model)
    {

    }

    public void Delete(Running model)
    {

    }
}