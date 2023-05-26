using sadklouds.ExcerciseTracker.DBContext;
using sadklouds.ExcerciseTracker.Models;

namespace sadklouds.ExcerciseTracker.Repositries;

public class ExerciseRepository : IExerciseRepository
{

    private readonly ExerciseContext _context;

    public ExerciseRepository(ExerciseContext _context)
    {
        this._context = _context;
    }

    public void Add(ExerciseModel entity)
    {
        var addedEntity = _context.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<ExerciseModel> GetAll()
    {
        var entities = _context.Set<ExerciseModel>().ToList();
        return entities;
    }

    public ExerciseModel GetById(int id)
    {
        return _context.Find<ExerciseModel>(id);
    }

    public void Update(ExerciseModel updatedEntity, ExerciseModel curentEntity)
    {
        curentEntity.StartDate = updatedEntity.StartDate;
        curentEntity.EndDate = updatedEntity.EndDate;
        curentEntity.Duration = updatedEntity.Duration;
        curentEntity.Comments = updatedEntity.Comments;
        
        _context.Update(curentEntity);
        _context.SaveChanges();
    }
}
