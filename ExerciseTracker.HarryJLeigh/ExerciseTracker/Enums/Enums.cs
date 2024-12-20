using System.ComponentModel.DataAnnotations;

namespace ExerciseTracker.Enums;

internal enum UserInterfaceOptions
{
    [Display(Name = "Weights")] Weights,
    [Display(Name = "Cardio")] Cardio,
    [Display(Name = "Exit")] Exit
}
internal enum MenuOptions
{
    [Display(Name = "Add Exercise")] Add,
    [Display(Name = "Exercise History")] History,
    [Display(Name = "Exit")] Exit
}

internal enum HistoryOptions
{
    [Display(Name = "View all")] View,
    [Display(Name = "Update")] Update,
    [Display(Name = "Delete")] Delete,
    [Display(Name = "Exit")] Exit
}

internal enum UpdateWeightOptions
{
    [Display(Name = "Start")] Start,
    [Display(Name = "Finish")] Finish,
    [Display(Name = "Sets")] Sets,
    [Display(Name = "Total Weight")] TotalWeight,
    [Display(Name = "Comments")] Comments,
    [Display(Name = "All")] All,
    [Display(Name = "Exit")] Exit,
}

internal enum UpdateCardioOptions
{
    [Display(Name = "Start")] Start,
    [Display(Name = "Finish")] Finish,
    [Display(Name = "Distance")] Distance,
    [Display(Name = "Comments")] Comments,
    [Display(Name = "All")] All,
    [Display(Name = "Exit")] Exit,
}

