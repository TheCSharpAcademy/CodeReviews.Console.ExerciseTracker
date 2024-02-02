using ExerciseTracker.LONCHANICK.Models;

namespace ExerciseTracker.LONCHANICK.Repository;


public interface IExerciseRepository
{
    IEnumerable<ExerciseRecord> Get();
    void Add(ExerciseRecord param);
    void Update(ExerciseRecord param);
    void Delete(ExerciseRecord param);

}