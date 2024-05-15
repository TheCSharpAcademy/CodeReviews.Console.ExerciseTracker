using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.samggannon.UserInterface
{
    internal class Enums
    {
        public enum MenuOptions
        {
            AddSession,
            ShowAllSessions,
            ShowSessionById,
            EditSessionById,
            DeleteSessionById,
            Back,
        }

        public enum UpdateOptions
        {
            UpdateStartTime,
            UpdateEndTime,
            UpdateComments,
            Back
        }

        public enum ExerciseOptions
        {
            CardioSession,
            ResistanceTraining,
            DevelopersDisclaimer,
            Quit
        }

        public enum ResistanceOptions
        {
            AddWorkout,
            ShowAllWorkouts,
            ShowworkoutById,
            EditWorkoutById,
            DeleteWorkoutById,
            Back,
        }

        public enum ResistanceType
        {
            Pushups,
            Situps,
            PullUps,
            DumbbellCurls,
            None
        }
    }
}
