using ExerciseTracker.TwilightSaw.Helpers;
using ExerciseTracker.TwilightSaw.Model;
using ExerciseTracker.TwilightSaw.Service;
using Microsoft.Identity.Client;
using Spectre.Console;

namespace ExerciseTracker.TwilightSaw.Controllers;

public class ExerciseController(ExerciseService service)
{
    public void AddExercise(string type)
    {
        Console.Clear();
        AnsiConsole.Write(new Rule("[cyan]Format - hh:mm[/]"));
        var addStartInput =  UserInput.CreateRegex("^(?:([0-1][0-9]|2[0-3]):([0-5][0-9])|0)$", "Insert the start of your Exercise", "Wrong format, try again.");
        if (addStartInput == "0") return;
        AnsiConsole.Write(new Rule("[cyan]Format - hh:mm[/]"));
        var addEndInput =  UserInput.CreateRegex("^(?:([0-1][0-9]|2[0-3]):([0-5][0-9])|0|(N|n))$", "Insert the end of your Exercise, N for time at this moment", "Wrong format.");
        addEndInput = addEndInput is "N" or "n" ? DateTime.Now.AddSeconds(-DateTime.Now.Second).ToShortTimeString() : addEndInput;
        if (addEndInput == "0") return;
        var addComments = UserInput.Create("Add the comments, leave this field empty");
        if (addComments == "0") return;

        DateTime.TryParse(addStartInput, out var startTime);
        DateTime.TryParse(addEndInput, out var endTime);
        var exercise = new Exercise(type, startTime, endTime, addComments == "" ? null : addComments);
        service.AddExercise(exercise);
        Validation.EndMessage("Exercise added successfully.");
    }

    public Exercise GetExercise(string type)
    {
        Console.Clear();
        var input = UserInput.CreateExerciseChoosingList(service.GetExerciseByType(type), "Return");
        return input;
    }

    public void DeleteExercise(Exercise exercise)
    {
        Console.Clear();
        service.DeleteExercise(exercise.Id);
        Validation.EndMessage("Exercise deleted successfully.");
    }

    public void ChangeExercise(Exercise exercise)
    {
        Console.Clear();
        var type = exercise.Type;
        var stringDate = exercise.StartTime.ToShortDateString();
        var stringStartTime = exercise.StartTime.TimeOfDay.ToString();
        var stringEndTime = exercise.EndTime.TimeOfDay.ToString();
        var comment = exercise.Comments;

        var changeInput = UserInput.CreateUpdateChoosingList([$"Type: {type}", 
            $"Date: {stringDate}", $"Start Time: {stringStartTime}", 
            $"End Time: {stringEndTime}", $"Comment: {comment}"],
            exercise, "Return");
        switch (changeInput)
        {
            case "1":
                var typeInput = UserInput.CreateChoosingList(["Cardio", "Weights"], "Return");
                if (typeInput == "Return") return;
                exercise.Type = typeInput;
                break;
            case "2":
                AnsiConsole.Write(new Rule("[olive]Format: dd.mm.yyyy[/]"));
                var newDateInput = UserInput.CreateRegex(@"^(?:([0-2][0-9]|3[01])\.(0[1-9]|1[0-2])\.(\d{4})|(T|t)|0)$",
                    "Insert your new date, T for today's date", "Wrong format, try again.");
                switch (newDateInput)
                {
                    case "0":
                        return;
                    case "T" or "t":
                        newDateInput = DateTime.Now.ToShortDateString();
                        break;
                }

                DateTime.TryParse(newDateInput, out var newDate);
                exercise.StartTime = newDate + exercise.StartTime.TimeOfDay;
                exercise.EndTime = newDate + exercise.EndTime.TimeOfDay;
                break;
            case "3":
                AnsiConsole.Write(new Rule("[olive]Format: hh:mm[/]"));
                var newStartTimeInput = UserInput.CreateRegex("^(?:([0-1][0-9]|2[0-3]):([0-5][0-9])|0)$",
                    "Insert the start of your Exercise", "Wrong format, try again.");
                if (newStartTimeInput == "0") return;

                DateTime.TryParse(newStartTimeInput, out var newStartTime);
                exercise.StartTime = exercise.StartTime.Date + newStartTime.TimeOfDay;
                break;
            case "4":
                AnsiConsole.Write(new Rule("[olive]Format: hh:mm[/]"));
                var newEndTimeInput = UserInput.CreateRegex("^(?:([0-1][0-9]|2[0-3]):([0-5][0-9])|0|(N|n))$", 
                    "Insert the end of your Exercise, N for time at this moment", "Wrong format.");
                if (newEndTimeInput == "0") return;
                newEndTimeInput = newEndTimeInput is "N" or "n" ? DateTime.Now.AddSeconds(-DateTime.Now.Second).ToShortTimeString() : newEndTimeInput;

                DateTime.TryParse(newEndTimeInput, out var newEndTime);
                exercise.EndTime = exercise.EndTime.Date + newEndTime.TimeOfDay;
                break;
            case "5":
                var newComment = UserInput.Create("Change your comment, leave this field empty");
                if (newComment == "0") return;
                exercise.Comments = newComment;
                break;
        }
        service.UpdateExercise(exercise);
        Validation.EndMessage("Changed successfully.");
    }
}