using ExerciseTracker.StanimalTheMan.Data;
using ExerciseTracker.StanimalTheMan.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.StanimalTheMan.Repository;

public class ExerciseRepository : IExerciseRepository
{
	private readonly ExerciseContext _context;

	public ExerciseRepository(ExerciseContext context)
	{
		_context = context;
	}

	public void AddExercise(Run run)
	{
		_context.Runs.Add(run);
		_context.SaveChanges();
	}

	public void DeleteExercise(int id)
	{
		var run = _context.Runs.Find(id);
		if (run != null)
		{
			_context.Runs.Remove(run);
			_context.SaveChanges();
		}
	}

	public IEnumerable<Run> GetAllExercises()
	{
		return _context.Runs.ToList();
	}

	public Run GetExerciseById(int id)
	{
		return _context.Runs.FirstOrDefault(run => run.Id == id);
	}

	public void UpdateExercise(Run run)
	{
		_context.Entry(run).State = EntityState.Modified;
		_context.SaveChanges();
	}
}
