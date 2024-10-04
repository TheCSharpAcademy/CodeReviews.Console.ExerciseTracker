using Spectre.Console;

namespace ExerciseTracker;

public interface IValidator
{
    string ErrorMsg { get; set; }
    ValidationResult Validate(string? input);
}