using ExerciseTracker.kjanos89.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.kjanos89.Repository;

public interface IExerciseRepository
{
    IEnumerable<Exercise> ListAll();
    void Create(Exercise exercise);
    Exercise Read(int id);
    void Update(Exercise exercise);
    void Delete(int id);
}