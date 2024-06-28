using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.Models
{
    internal class Enums
    {
        internal enum MainMenuOptions
        {
            AddExerciseSession,
            ExerciseSessionHistory,
            ExitProgram
        }

        internal enum CreateViewUpdateDeleteMenuOptions
        {
            AddExerciseSession,
            ViewSession,
            UpdateSession,
            DeleteSession,
            Back
        }

    }
}
