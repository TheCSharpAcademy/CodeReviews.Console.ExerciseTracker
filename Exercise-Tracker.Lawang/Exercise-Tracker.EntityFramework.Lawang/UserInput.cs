using System;
using Exercise_Tracker.EntityFramework.Lawang.Models;
using Microsoft.Identity.Client;
using Spectre.Console;

namespace Exercise_Tracker.EntityFramework.Lawang;

public class UserInput
{
    public string ChooseMenuOperation()
    {
        var listOfMenuOption = new List<string>()
        {
            "Get All Exercises",
            "Create Exercise",
            "Update Exercise",
            "Delete Exercise",
            "Exit"
        };

        return GetSelection(listOfMenuOption, "[yellow bold]Choose your operation[/]", "Select from the Menu given below");
    }

    private string GetSelection(List<string> listOfOption, string heading, string title)
    {
        AnsiConsole.Write(new Rule($"{heading}").LeftJustified().RuleStyle("red"));
        Console.WriteLine();

        var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title($"{title}")
            .MoreChoicesText("[grey bold](Press 'up' and 'down' key to navigate)[/]")
            .AddChoices(listOfOption)
            .HighlightStyle(Color.Blue3)
            .WrapAround()
        );

        return selection;
    }

    public Exercise? CreateExercise()
    {
        AnsiConsole.Write(new Rule("[skyblue1 bold]CREATE EXERCISE[/]").RuleStyle("red").LeftJustified());
        View.ShowDateInstruction();

        var startDate = DateCreation("Start", "green");
        if (startDate == null) return null;

        var endDate = DateCreation("End", "darkorange");
        if (endDate == null) return null;

        if (endDate < startDate)
        {
            View.RenderResult("End Date cannot be smaller than start date!!! Please Try again!", "red", Color.Red1);
            Console.ReadLine();
            return null;
        }

        var comments = AnsiConsole.Ask<string>("[yellow1 bold]Write Comment: [/]");

        return new Exercise() { DateStart = startDate.Value, DateEnd = endDate.Value, Comments = comments };

    }

    private DateTime? DateCreation(string time, string color)
    {
        var startDate = AnsiConsole.Ask<string>($"[{color} bold]Enter the {time} Date: [/]");
        if (startDate == "0") return null;

        var validDate = Validation.ValidateDate(startDate);
        while (validDate == null)
        {
            startDate = AnsiConsole.Ask<string>("[red bold]Please enter the date in correct format[/]: (eg. 02/05/24, 12/09/11) => ");
            Console.WriteLine();
            if (startDate == "0") return null;
            validDate = Validation.ValidateDate(startDate);
        }

        return validDate;
    }

    public Exercise? ChooseUpdateExercise(List<Exercise> exercises)
    {
        AnsiConsole.Write(new Rule("[skyblue1 bold]UPDATE EXERCISE[/]").RuleStyle("red").LeftJustified());
        AnsiConsole.MarkupLine("\n[grey bold](Press '0' to go back to menu)[/]\n");
        int updateId = AnsiConsole.Ask<int>("[olive bold]Enter the Id to Update: [/]");

        while (!Validation.ValidateId(exercises, updateId))
        {
            if (updateId == 0) return null;

            AnsiConsole.MarkupLine($"[red bold]Id: {updateId} doesn't exist in the database. Please Enter another Id.[/]");
            updateId = AnsiConsole.Ask<int>("[olive bold]Please Enter the Id in present in the above table: [/]");
        }

        var exercise = exercises.First(ex => ex.Id == updateId);
        var updateExercise = new Exercise()
        {
            Id = updateId,
            DateStart = exercise.DateStart,
            DateEnd = exercise.DateEnd,
            Comments = exercise.Comments
        };
        Console.Clear();

        View.ShowDateInstruction();
        Console.WriteLine();
        var confirmation = AnsiConsole.Prompt(new ConfirmationPrompt("[yellow]Do you want to update [green]Start Date[/]?[/]"));
        if (confirmation)
        {
            var startDate = DateCreation("Start", "green");
            if (startDate == null) return null;
            updateExercise.DateStart = startDate.Value;
        }

        Console.WriteLine();
        confirmation = AnsiConsole.Prompt(new ConfirmationPrompt("[yellow]Do you want to update [red]End Date[/]?[/]"));

        if (confirmation)
        {
            var endDate = DateCreation("End", "red");
            if (endDate == null) return null;
            updateExercise.DateEnd = endDate.Value;
        }

        if (updateExercise.DateEnd < updateExercise.DateStart)
        {
            View.RenderResult("End Date cannot be smaller than start date!!! Please Try again!", "red", Color.Red1);
            Console.ReadLine();
            return null;
        }

        Console.WriteLine();
        confirmation = AnsiConsole.Prompt(new ConfirmationPrompt("[yellow]Do you want to update comment ?[/]"));
        if (confirmation)
        {
            var comments = AnsiConsole.Ask<string>("[yellow1 bold]Update Comment: [/]");
            if (comments == "0") return null;
            updateExercise.Comments = comments;
        }

        exercise.DateStart = updateExercise.DateStart;
        exercise.DateEnd = updateExercise.DateEnd;
        exercise.Comments = updateExercise.Comments;

        return exercise;

    }

    public Exercise? ChooseDeleteExercise(List<Exercise> exercises)
    {
        AnsiConsole.Write(new Rule("[skyblue1 bold]DELETE EXERCISE[/]").RuleStyle("red").LeftJustified());
        AnsiConsole.MarkupLine("\n[grey bold](Press '0' to go back to menu)[/]\n");
        int deleteId = AnsiConsole.Ask<int>("[olive bold]Enter the Id to Update: [/]");

        while (!Validation.ValidateId(exercises, deleteId))
        {
            if (deleteId == 0) return null;

            AnsiConsole.MarkupLine($"[red bold]Id: {deleteId} doesn't exist in the database. Please Enter another Id.[/]");
            deleteId = AnsiConsole.Ask<int>("[olive bold]Please Enter the Id in present in the above table: [/]");
        }

        return exercises.First(ex => ex.Id == deleteId);

    }
}
