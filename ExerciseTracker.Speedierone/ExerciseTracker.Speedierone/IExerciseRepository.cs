using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public interface IExerciseRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
