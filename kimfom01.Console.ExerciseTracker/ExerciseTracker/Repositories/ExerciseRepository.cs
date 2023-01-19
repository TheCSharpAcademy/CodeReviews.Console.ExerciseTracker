using ExerciseTracker.Data;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repositories;

public class ExerciseRepository : Repository, IExerciseRepository
{
    public ExerciseRepository(ExerciseContext exerciseContext) : base(exerciseContext)
    {
    }

    public override void UpdateExercise(int id, Exercise exercise)
    {
        var oldExercise = GetExerciseById(id);

        if(exercise is null)
        {
            Console.WriteLine("This exercise does not exist!");
            return;
        }

        var duration = exercise.EndDate - oldExercise.StartDate;

        exercise.Duration = duration;

        base.UpdateExercise(id, exercise);
    }
}