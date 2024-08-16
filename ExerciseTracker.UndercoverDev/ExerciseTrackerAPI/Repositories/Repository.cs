using ExerciseTrackerAPI.Data;
using ExerciseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace ExerciseTrackerAPI.Repositories;
public class Repository : IRepository
{
    private readonly ExerciseTrackerContext _context;

    public Repository(ExerciseTrackerContext context)
    {
        _context = context;
    }
    
    public async Task<Weight?> CreateAsync(Weight weight)
    {
        ArgumentNullException.ThrowIfNull(weight);

        try
        {
            await _context.AddAsync(weight);
            await _context.SaveChangesAsync();
            return weight;
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"{nameof(weight)} failed to create: {ex.Message}");
            return null;
        }
    }

    public async Task<Weight?> DeleteAsync(int id)
    {
        try
        {
            if (!_context.Weights.Any(e => e.Id == id))
                return null;

            var weightToDelete = await _context.Weights.FindAsync(id);
            if (weightToDelete == null)
                return null;

            _context.Weights.Remove(weightToDelete);
            await _context.SaveChangesAsync();
            return weightToDelete;
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"Weight with id {id} failed to delete: {ex.Message}");
            return null;
        }
    }

    public async Task<List<Weight>> GetAllAsync()
    {
        try
        {
            if (!_context.Weights.Any())
                return [];

            return await _context.Weights.ToListAsync();
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"Failed to get all weights: {ex.Message}");
            return [];
        }
    }

    public async Task<Weight?> GetByIdAsync(int id)
    {
        try
        {
            if (!_context.Weights.Any(e => e.Id == id))
                return null;

            return await _context.Weights.FindAsync(id);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"Weight with id {id} failed to get: {ex.Message}");
            return null;
        }
    }

    public async Task<Weight?> UpdateAsync(int id, Weight weight)
    {
        ArgumentNullException.ThrowIfNull(weight);

        try
        {
            if (!_context.Weights.Any(e => e.Id == id))
                return null;

            var weightToUpdate = await _context.Weights.FirstOrDefaultAsync(w => w.Id == id);

            if (weightToUpdate == null)
                return null;

            weightToUpdate.DateStart = weight.DateStart;
            weightToUpdate.DateEnd = weight.DateEnd;
            weightToUpdate.Duration = weight.Duration;
            weightToUpdate.Comments = weight.Comments;
            
            await _context.SaveChangesAsync();
            return weight;
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"{nameof(weight)} with id {id} failed to update: {ex.Message}");
            return null;
        }
    }
}