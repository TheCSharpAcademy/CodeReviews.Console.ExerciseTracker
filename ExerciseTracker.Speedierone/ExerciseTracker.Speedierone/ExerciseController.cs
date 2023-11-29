using ExerciseTracker.Speedierone.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public class ExerciseController
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public IEnumerable<Exercises> ViewAll()
        {
            var allExercises = _exerciseRepository.GetAll();
            return allExercises;
        }
        
        public void AddExercise(Exercises exercises)
        {
            _exerciseRepository.Add(exercises);
            _exerciseRepository.Save();
        }
        public void UpdateExercise(Exercises exercises)
        {
            _exerciseRepository.Update(exercises);
            _exerciseRepository.Save();
        }
        public void DeleteExercise(int id)
        {
            _exerciseRepository.Delete(id);
            _exerciseRepository.Save();

        }
    }
}
