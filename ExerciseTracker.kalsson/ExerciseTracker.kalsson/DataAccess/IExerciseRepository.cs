using ExerciseTracker.kalsson.Models;

namespace ExerciseTracker.kalsson.DataAccess;

public interface IExerciseRepository
{
    /// <summary>
    /// Retrieves all exercises asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of ExerciseModel.</returns>
    Task<IEnumerable<ExerciseModel>> GetAllExercisesAsync();

    /// <summary>
    /// Gets an exercise by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the exercise to retrieve.</param>
    /// <returns>The exercise with the specified ID, or null if not found.</returns>
    Task<ExerciseModel> GetExerciseByIdAsync(int id);

    /// <summary>
    /// Adds a new exercise to the exercise repository.
    /// </summary>
    /// <param name="exercise">
    /// The exercise model object representing the exercise to be added.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    Task AddExerciseAsync(ExerciseModel exercise);

    /// <summary>
    /// Updates an exercise in the exercise repository.
    /// </summary>
    /// <param name="exercise">The updated exercise model.</param>
    /// <returns>A task representing the asynchronous update operation.</returns>
    Task UpdateExerciseAsync(ExerciseModel exercise);

    /// <summary>
    /// Deletes an exercise from the exercise repository.
    /// </summary>
    /// <param name="id">The ID of the exercise to be deleted.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteExerciseAsync(int id);
}