using ExerciseTracker.samggannon.Data.Models;

namespace ExerciseTracker.samggannon.Data.Repositories;

internal interface IExerciseRepository
{
    public void Add(Exercise entity);
    public void Delete(Exercise entity);
    public IEnumerable<Exercise> GetAll();
    public Exercise GetById(int id);
    public void Update(Exercise entity);
}
