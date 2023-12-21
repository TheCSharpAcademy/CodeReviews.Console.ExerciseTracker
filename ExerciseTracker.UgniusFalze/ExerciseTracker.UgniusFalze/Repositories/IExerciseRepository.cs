using ExerciseTracker.UgniusFalze.Models;

namespace ExerciseTracker.UgniusFalze.Repositories;

public interface IExerciseRepository
{
    public Pullup? GetExercise(int id);
    public List<Pullup> GetExercises();
    public bool InsertExercise(Pullup pullup);
    public bool UpdateExercise(Pullup pullup);
    public bool DeleteExercise(int id);
}