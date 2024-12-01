using ExerciseTracker.TwilightSaw.Model;
using ExerciseTracker.TwilightSaw.Repository;

namespace ExerciseTracker.TwilightSaw.Service;

public class ExerciseService(IRepository<Exercise> repository)
{
    public void AddExercise(Exercise exercise)
    {
        repository.Add(exercise);
    }

    public List<Exercise> GetExercises()
    {
        return repository.GetAll().ToList();
    }

    public Exercise GetExercise(int id)
    {
        return repository.GetById(id);
    }
    public List<Exercise> GetExerciseByType(string type)
    {
        return repository.GetAllByType(t => t.Type == type).ToList();
    }

    public void UpdateExercise(Exercise exercise)
    {
        repository.Update(exercise);
    }

    public void DeleteExercise(int id)
    {
        repository.Delete(id);
    }
}