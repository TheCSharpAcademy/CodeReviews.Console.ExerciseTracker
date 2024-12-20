using ExerciseTracker.Repository;

namespace ExerciseTracker.Services;

public class ExerciseService<T>(IRepository<T> exerciseRepository) : IExerciseService<T> where T : class
{
    private readonly IRepository<T> _exerciseRepository = exerciseRepository;
    
    public T GetById(int id) => _exerciseRepository.GetById(id);
    public IEnumerable<T> GetAllExercises() => _exerciseRepository.GetAll().ToList();

    public void AddExercise(T entity) => _exerciseRepository.Add(entity);

    public void UpdateExercise(T entity) => _exerciseRepository.Update(entity);

    public void DeleteExercise(int id)
    {
        T exerciseToDelete = _exerciseRepository.GetById(id);
        _exerciseRepository.Delete(exerciseToDelete);
    }
}