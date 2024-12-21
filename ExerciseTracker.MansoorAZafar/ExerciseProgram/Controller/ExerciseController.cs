using ExerciseLibrary.Display;
using ExerciseLibrary.Utilities;
using ExerciseProgram.Model;
using ExerciseProgram.Model.ExerciseModel;

namespace ExerciseProgram.Controller;

internal class ExerciseController 
{   
    internal void UpdateExercise()
    {
        //Display all the data
        this.ReadExercise();    

        int id = UserInput.GetId(Dto.exerciseService.GetExerciseById);
        if(id == -1) return;

        Exercise existing_exercise = Dto.exerciseService.GetExerciseById(id);

        Exercise updated_exercise = UserInput.CreateExercise();
        existing_exercise.Update(updated_exercise);

        Dto.exerciseService.UpdateExercise(existing_exercise);    
    }

    internal void DeleteExercise()
    {
        //Display all the data
        this.ReadExercise();
        int id = UserInput.GetId(Dto.exerciseService.GetExerciseById);
        if(id == -1) return;

        Dto.exerciseService.DeleteExercise(id);
    }

    internal void CreateExercise()
    {
        if(Utilities.GetInput<int>("Enter -1 to go back otherwise, enter any other Whole Number to continue") == -1) return;
        System.Console.WriteLine();
        Dto.exerciseService.AddExercise(UserInput.CreateExercise());
    }

    internal void ReadExercise()
    {
        if(Cache.NeedUpdate)
        {
            Cache.UpdateList();
            Cache.NeedUpdate = false;
        }

        Display.DisplayListAsTable(Exercise.headers, Cache.exerciseModels);
        System.Console.WriteLine();
    }
}