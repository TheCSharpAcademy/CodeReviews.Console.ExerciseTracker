using Exercisetacker.Data;
using Exercisetacker.DTOs;
using Exercisetacker.Entities;
using Exercisetacker.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercisetacker.Repositories;

public class CardioRepository : ICardioRepository
{
    private readonly CardioDbContext _context;

    public CardioRepository(CardioDbContext context)
    {
        _context = context;
    }

    public async Task<Excercise> AddExercise(Excercise exercise)
    {
        var result = await _context.Add(exercise);
        
        return result;
    }

    public async Task<int> UpdateExercise(Excercise exercise)
    {
        int result = await _context.Update(exercise);
        return result;
    }

    public async Task<int> DeleteExercise(Excercise exercise)
    {
        int result = await _context.Remove(exercise);
        return result;
        
    }

    public async Task<List<Excercise>?> GetAllExercise() => await _context.GetAllAsync();

    public async Task<Excercise?> GetExerciseById(int id) => await _context.FirstOrDefaultAsync(id);
    
}