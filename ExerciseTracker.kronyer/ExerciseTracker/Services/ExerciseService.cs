using ExerciseTracker.Models;
using ExerciseTracker.Repositories.Interfaces;
using Spectre.Console;

namespace ExerciseTracker.Services;

internal class ExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public void AddExercise()
    {
        Exercise newExercise = new Exercise();

        newExercise.DateStart = UserInput.GetDateInputs();
        newExercise.DateEnd = UserInput.GetDateInputs();
        while (newExercise.DateEnd < newExercise.DateStart)
        {
            AnsiConsole.MarkupLine("End date must be greather than the start date");
            newExercise.DateEnd = UserInput.GetDateInputs();
        }
        newExercise.Comments = UserInput.GetCommentInput();
        newExercise.Duration = newExercise.DateEnd - newExercise.DateStart;

        _exerciseRepository.AddExercise(newExercise);
    }

    public void UpdateExercise()
    {
        Exercise newExercise = new Exercise();

        newExercise.DateStart = UserInput.GetDateInputs();
        newExercise.DateEnd = UserInput.GetDateInputs();
        newExercise.Comments = UserInput.GetCommentInput();
        newExercise.Duration = newExercise.DateEnd - newExercise.DateStart;

        _exerciseRepository.UpdateExercise(newExercise);
    }

    public void DeleteExercise()
    {
        int exercise = UserInput.GetExercise("delete");
        _exerciseRepository.DeleteExercise(exercise);
    }

    public Exercise GetExercise()
    {
        int exercise = UserInput.GetExercise("see");
        return _exerciseRepository.GetById(exercise);
    }

    public List<Exercise> GetAllExercises()
    {
        return _exerciseRepository.GetAll();
    }
}
