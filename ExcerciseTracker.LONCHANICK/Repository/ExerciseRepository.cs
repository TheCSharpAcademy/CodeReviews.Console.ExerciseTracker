using ExerciseTracker.LONCHANICK.Data;
using ExerciseTracker.LONCHANICK.Models;

namespace ExerciseTracker.LONCHANICK.Repository;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ExerciseDbContext _db;// = new();

    public ExerciseRepository(ExerciseDbContext db)
    {
        _db=db;        
    }

    public void Add(ExerciseRecord param)
    {
        _db.ExerciseRecords.Add(param);
        _db.SaveChanges();
    }

    public void Delete(ExerciseRecord param)
    {
        _db.ExerciseRecords.Remove(param);
        _db.SaveChanges();
    }

    public IEnumerable<ExerciseRecord> Get()
    {
        return _db.ExerciseRecords;
    }

    public void Update(ExerciseRecord param)
    {
        _db.ExerciseRecords.Update(param);
    }
}
