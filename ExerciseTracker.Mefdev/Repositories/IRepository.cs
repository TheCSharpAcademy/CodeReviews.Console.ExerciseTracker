using ExerciseTracker.Mefdev.Models;

namespace ExerciseTracker.Mefdev.Repositories;

public interface IRepository
{
    IEnumerable<Exercise> GetAll();
    Exercise? GetById(int id);
    void Create(Exercise entity);
    void Update(Exercise entity);
    void Delete(int id);
}