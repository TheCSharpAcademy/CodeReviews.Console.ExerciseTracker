using ExerciseTracker.kalsson.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.kalsson.DataAccess;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ExerciseDbContext _context;

    public ExerciseRepository(ExerciseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExerciseModel>> GetAllExercisesAsync()
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task<ExerciseModel> GetExerciseByIdAsync(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task AddExerciseAsync(ExerciseModel exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExerciseAsync(ExerciseModel exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteExerciseAsync(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}