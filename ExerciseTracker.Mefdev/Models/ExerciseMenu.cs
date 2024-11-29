using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExerciseTracker.Mefdev.Models;

public static class ExerciseMenu
{
    public enum Options
    {
        [Display(Name = "Create an exercise")]
        Create,

        [Display(Name = "Delete an exercise")]
        Delete,

        [Display(Name = "Update an exercise")]
        Update,

        [Display(Name = "View an exercise")]
        View,

        [Display(Name = "View exercises")]
        ViewAll,

        [Display(Name = "Quit")]
        Quit
    }

    public static string GetDisplayName(this Enum value)
    {
        var fieldInfo = value.GetType().GetMember(value.ToString())?.FirstOrDefault();
        var attribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();
        return attribute?.Name;
    }
}