using ExerciseTracker.Speedierone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    public class ExerciseService
    {
        private readonly IExerciseRepository<Exercises> _exerciseRepository;

        public ExerciseService(IExerciseRepository<Exercises> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public void AddExercise(Exercises exercises)
        {
            _exerciseRepository.Add(exercises);
        }
    }
}
