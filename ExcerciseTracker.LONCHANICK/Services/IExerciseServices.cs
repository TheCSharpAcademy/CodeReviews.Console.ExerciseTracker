using ExerciseTracker.LONCHANICK.Models;

namespace ExerciseTracker.LONCHANICK.Services;

public interface IExerciseServices 
{
    void Add(ExerciseRecord exerciceRecord);
    IEnumerable<ExerciseRecord> Get();
    void Delete(ExerciseRecord exerciceRecord);
}