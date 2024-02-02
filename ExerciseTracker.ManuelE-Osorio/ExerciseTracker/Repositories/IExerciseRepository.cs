namespace ExerciseTracker.Repositories;

public interface IExerciseRepository<T> where T: class
{
    void Insert(T model);
    IEnumerable<T>? GetAll();
    T? GetById(int id);
    void Update(T model);
    void Delete(T model);
}