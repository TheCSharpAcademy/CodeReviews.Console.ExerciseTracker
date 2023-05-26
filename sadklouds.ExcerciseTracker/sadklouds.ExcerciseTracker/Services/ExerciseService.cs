using sadklouds.ExcerciseTracker.Models;
using sadklouds.ExcerciseTracker.Repositries;
using sadklouds.ExcerciseTracker.UserInpit;

namespace sadklouds.ExcerciseTracker.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository _exerciseRepository)
        {
            this._exerciseRepository = _exerciseRepository;
        }

        public void AddExercise()
        {
            DateTime startDate = UserInput.GetStartDate();
            DateTime endDate = UserInput.GetEndDate(startDate);
            TimeSpan duration = endDate - startDate;
            ExerciseModel excercise = new ExerciseModel()
            {
                StartDate = startDate,
                EndDate = endDate,
                Duration = duration
            };

            _exerciseRepository.Add(excercise);
        }

        public void DeleteExercise()
        {
            throw new NotImplementedException();
        }

        public void GetAllExercises()
        {
            var exercises = _exerciseRepository.GetAll();
            if (exercises == null)
                Console.WriteLine("No excercises where found");
            else
            {
                foreach (var exercise in exercises)
                {
                    Console.WriteLine("template");
                }
            }
        }

        public void GetExercise()
        {
            int id = UserInput.GetIdInput();
            var exercise = _exerciseRepository.GetById(id);
            if (exercise == null)
                Console.WriteLine($"Excercise with Id:{id} was  not found!");
            else
                Console.WriteLine($"Id:{exercise.Id}, Start:{exercise.StartDate}, End:{exercise.EndDate}, Duration:{exercise.Duration}");
        }

        public void UpdateExercise()
        {
            int id = UserInput.GetIdInput();
            var currentExercise = _exerciseRepository.GetById(id);
            if (currentExercise == null)
            {
                Console.WriteLine("Excercise could not be found");
                return;
            }
            DateTime startDate = UserInput.GetStartDate();
            DateTime endDate = UserInput.GetEndDate(startDate);
            TimeSpan duration = endDate - startDate;
            ExerciseModel updatedModel = new ExerciseModel()
            {
                StartDate = startDate,
                EndDate = endDate,
                Duration = duration
            };
            _exerciseRepository.Update(updatedModel, currentExercise);

        }
    }
}
