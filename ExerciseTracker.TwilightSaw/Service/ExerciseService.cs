using ExerciseTracker.TwilightSaw.Model;
using ExerciseTracker.TwilightSaw.Repository;

namespace ExerciseTracker.TwilightSaw.Service;

public class ExerciseService(IRepository<Exercise> repository, IRepository<Exercise> dapperRepository)
{
    public void AddExercise(Exercise exercise)
    {
        if(exercise.Type == "Cardio")
            repository.Add(exercise);
        else dapperRepository.Add(exercise);
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
        if (exercise.Type == "Cardio")
            repository.Update(exercise);
        else dapperRepository.Update(exercise);
    }

    public void DeleteExercise(int id)
    {
        repository.Delete(id);
    }
}