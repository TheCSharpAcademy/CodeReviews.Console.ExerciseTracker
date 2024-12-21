namespace ExerciseProgram.Model;

using ExerciseProgram.Model.ExerciseModel;
using ExerciseProgram.Repository;

internal class ExerciseService
{
    private readonly IRepository<Exercise> ExerciseRepository;

    public ExerciseService(IRepository<Exercise> repository) 
    {
        this.ExerciseRepository = repository;
    }

    public Exercise GetExerciseById(int id)
    {
        return this.ExerciseRepository.GetById(id);
    }

    public List<Exercise> GetAllExercise()
    {
        return this.ExerciseRepository.GetAll();
    }

    public void AddExercise(Exercise exercise)
    {
        this.ExerciseRepository.Add(exercise);
        Cache.NeedUpdate = true;
    }

    public void UpdateExercise(Exercise exercise)
    {
        this.ExerciseRepository.Update(exercise);
        Cache.NeedUpdate = true;
    }

    public void DeleteExercise(int id)
    {
        this.ExerciseRepository.Delete(Dto.exerciseService.GetExerciseById(id));
        Cache.NeedUpdate = true;
    }

}