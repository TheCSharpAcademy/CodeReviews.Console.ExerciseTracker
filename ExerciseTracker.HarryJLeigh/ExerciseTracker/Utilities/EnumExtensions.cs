using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExerciseTracker.Utilities;

public static class EnumExtensions
{
    internal static string GetEnumDisplayName(Enum enumValue)
    {
        var displayAttribute = enumValue
            .GetType()
            .GetField(enumValue.ToString())
            ?.GetCustomAttribute<DisplayAttribute>();
        return displayAttribute?.Name ?? enumValue.ToString();
    }
}