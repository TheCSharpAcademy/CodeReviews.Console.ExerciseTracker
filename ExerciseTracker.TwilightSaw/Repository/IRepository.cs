namespace ExerciseTracker.TwilightSaw.Repository;

public interface IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAllByType(Func<T, bool> predicate);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}