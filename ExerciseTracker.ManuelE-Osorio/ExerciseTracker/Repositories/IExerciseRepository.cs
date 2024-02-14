namespace ExerciseTracker.Repositories;

public interface IExerciseRepository<T> where T: class
{
    bool Insert(T model);
    IEnumerable<T>? GetAll();
    T? GetById(int id);
    bool Update(T model);
    bool Delete(T model);
}