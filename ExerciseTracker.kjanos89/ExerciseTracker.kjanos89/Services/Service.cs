using ExerciseTracker.kjanos89.Models;
using ExerciseTracker.kjanos89.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.kjanos89.Services;

public class Service
{
    IExerciseRepository repo;

    public Service(IExerciseRepository repository)
    {
        repo = repository;
    }

    public void ListAll()
    {
        repo.ListAll();
    }

    public void AddExercise(DateTime start, DateTime end, TimeSpan duration, string comment)
    {
        Exercise exercise = new Exercise
        {
            Start = start,
            End = end,
            Duration = duration,
            Comments = comment
        };
        repo.Create(exercise);
    }

    public Exercise ReadExercise(int id)
    {
        return repo.Read(id);
    }

    public void UpdateExercise(DateTime start, DateTime end, TimeSpan duration, string comment)
    {
        Exercise newExercise = new Exercise
        {
            Start = start,
            End = end,
            Duration = duration,
            Comments = comment
        };
        repo.Update(newExercise);
    }

    public void DeleteExercise(int id)
    {
        repo.Delete(id);
    }
}