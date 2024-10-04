namespace ExerciseTracker;

public class RepositoryDispatcher<T> : IRepository<T>
{
    private readonly Func<DbOption> selector;
    private readonly List<IRepository<T>> repositories;

    public RepositoryDispatcher(Func<DbOption> selector,
        List<IRepository<T>> repositories)
    {
        this.selector = selector;
        this.repositories = repositories;
    }

    public void Add(T entity)
    {
        CurrentRepository.Add(entity);
    }

    public void Delete(T entity)
    {
        CurrentRepository.Delete(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return CurrentRepository.GetAll();
    }

    public T? GetById(int id)
    {
        return CurrentRepository.GetById(id);
    }

    public void Update(T entity)
    {
        CurrentRepository.Update(entity);
    }

    private IRepository<T> CurrentRepository
    {
        get
        {
            IRepository<T>? repository = selector() switch
            {
                DbOption.SqlServerEntityFramework => repositories.Where(r => r.GetType() == typeof(ExerciseRepositoryEf)).FirstOrDefault(),
                DbOption.SqliteAdoNet => repositories.Where(r => r.GetType() == typeof(ExerciseAdoNetRepository)).FirstOrDefault(),
                _ => throw new NotImplementedException()
            } ?? throw new NotImplementedException(); 

            return repository;
        }
    }
}