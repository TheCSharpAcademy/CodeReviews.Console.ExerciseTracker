namespace ExerciseTracker;

public class UserInterface
{
    private readonly ExerciseMenuHandler _exerciseMenuHandler;

    public UserInterface(ExerciseMenuHandler exerciseMenuHandler)
    {
        _exerciseMenuHandler = exerciseMenuHandler;
    }
    public void Run()
    {
        _exerciseMenuHandler.Display();
    }
}