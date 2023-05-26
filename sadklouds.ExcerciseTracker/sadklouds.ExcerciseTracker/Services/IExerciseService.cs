using sadklouds.ExcerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sadklouds.ExcerciseTracker.Services
{
    public interface IExerciseService
    {
        public void GetAllExercises();
        public void DeleteExercise();
        public void UpdateExercise();
        public void AddExercise();
        public void GetExercise();
    }
}
