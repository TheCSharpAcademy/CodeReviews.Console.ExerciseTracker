using Exercisetacker.Data;
using Exercisetacker.DTOs;
using Exercisetacker.Entities;
using Exercisetacker.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercisetacker.Repositories;

public class JoggingRepository : IJoggingRepository
{
    private readonly JoggingDbContext _context;

    public JoggingRepository(JoggingDbContext context)
    {
        _context = context;
    }

    public async Task<Excercise> AddExercise(Excercise exercise)
    {
        _context.Add(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    public async Task<int> UpdateExercise(Excercise exercise)
    {
        _context.Update(exercise);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteExercise(Excercise exercise)
    {
        _context.Remove(exercise);
        return await _context.SaveChangesAsync();
        
    }

    public async Task<List<Excercise>?> GetAllExercise() => await _context.Excercises.ToListAsync();

    public async Task<Excercise?> GetExerciseById(int id) => await _context.Excercises.FirstOrDefaultAsync(j => j.Id == id);
    
}