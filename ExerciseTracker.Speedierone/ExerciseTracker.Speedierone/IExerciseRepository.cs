using ExerciseTracker.Speedierone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercises> GetAll();
        List<Exercises> GetById(int id);
        void Add (Exercises exercises);
        void Update (Exercises exercises);
        void Delete (int id);
        void Save();
    }
}
