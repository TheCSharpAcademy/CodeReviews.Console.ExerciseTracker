namespace ExerciseTracker.Controllers;

public interface IExerciseController
{
    void ViewAll();
    void Add();
    void Update(
        bool updateStart = false,
        bool updateFinish = false,
        bool updateComments = false,
        bool updateSets = false,
        bool updateTotalWeight =  false,
        bool updateDistance = false
        );
    void Delete();
}