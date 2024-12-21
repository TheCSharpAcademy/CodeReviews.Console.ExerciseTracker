using ExerciseProgram.Model.ExerciseModel;

namespace ExerciseProgram.Model;

// Idea:
/*
* Hold a reference of all the items in a List
*   -> Less expensive to check a list over the database
* 
* Each actual update on the database should update the flag
* At the start of the program, it should get all the data 
* from the database to ensure its updated
* 
*/
internal static class Cache {
    internal static List<Exercise>? exerciseModels = [];
    internal static bool NeedUpdate = false;

    internal static void UpdateList()
    {
        exerciseModels = DTO.exerciseService.GetAllExercise();
    }
}