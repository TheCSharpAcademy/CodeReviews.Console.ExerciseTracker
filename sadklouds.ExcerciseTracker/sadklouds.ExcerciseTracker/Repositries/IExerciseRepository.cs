using sadklouds.ExcerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sadklouds.ExcerciseTracker.Repositries
{
    public interface IExerciseRepository
    {
        public void Add(ExerciseModel entity);
        public void  Update (ExerciseModel updatedEntity, ExerciseModel curentEntity);
        public ExerciseModel GetById(int id);
        public IEnumerable<ExerciseModel> GetAll();
        
    }
}
