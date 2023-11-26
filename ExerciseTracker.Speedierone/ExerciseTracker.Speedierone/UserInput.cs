using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Speedierone
{
    internal class UserInput
    {
        public static void ShowAll()
        {
            var exerciseRepository = new ExerciseRepository();
            var exercises = exerciseRepository.GetAll();
            TableLayout.DisplayTableAll(exercises);
        }
    }
}
