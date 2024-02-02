using ExerciseTracker.LONCHANICK.Models;

namespace ExerciseTracker.LONCHANICK.Services;

public interface IExerciseServices 
{
    ExerciseRecord NewExerciseRecord();
    ExerciseRecord DeleteExerciseRecord(IEnumerable<ExerciseRecord> options);

    // void Add (ExerciseRecord param);
    // void Delete (ExerciseRecord param);
    // void Update (ExerciseRecord param);
    // void Get (ExerciseRecord param);
}