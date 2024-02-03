using exerciseTracker.doc415.context;
using exerciseTracker.doc415.Models;
using exerciseTracker.doc415.Repository;

namespace exerciseTracker.doc415.Service;

internal class ExerciseService
{
    IExerciseRepository _repository;



    public void AddExercise(string type, DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comments)
    {
        Exercise newExercise = new Exercise
        {
            DateStart = dateStart,
            DateEnd = dateEnd,
            Duration = duration,
            Comments = comments,
            Type = type
        };
        if (type == "Cardio")
            _repository = new ExerciseRepository(new ExerciseDbContext());
        else
            _repository = new ExerciseRepositoryDapper();
        _repository.Insert(newExercise);
    }

    public IEnumerable<Exercise> GetExerciseList()
    {
        _repository= new ExerciseRepository(new ExerciseDbContext());
        // _repository = new ExerciseRepositoryDapper(); since it is view operation either of them can be used
        return _repository.GetAll();
    }

    public void DeleteExercise(int id)
    {
        _repository = new ExerciseRepository(new ExerciseDbContext());
        // _repository = new ExerciseRepositoryDapper();since it is delete operation either of them can be used
        _repository.Delete(id);
    }

    public void UpdateExercise(int id, string type, DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comments)
    {
        Exercise newExercise = new Exercise
        {
            Id = id,
            DateStart = dateStart,
            DateEnd = dateEnd,
            Duration = duration,
            Comments = comments,
            Type = type
        };
        if (type == "Cardio")
            _repository = new ExerciseRepository(new ExerciseDbContext());
        else
            _repository = new ExerciseRepositoryDapper();
        _repository.Update(newExercise);
    }

    public Exercise GetExerciseById(int id)
    {
        _repository = new ExerciseRepository(new ExerciseDbContext());
        // _repository = new ExerciseRepositoryDapper();since it is view operation either of them can be used  

        return _repository.GetById(id);
    }
}
