using ExerciseTrackerAPI.DataAccess;
using ExerciseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerAPI.Controllers
{
	[Route("api/ExerciseTracker")]
	[ApiController]
	public class ExerciseTrackerController : ControllerBase
	{
		private readonly ExerciseTrackerContext _context;

		public ExerciseTrackerController(ExerciseTrackerContext context)
		{
			_context = context;
		}

		// GET: api/ExerciseModels
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ExerciseModel>>> GetExercises()
		{
			if (_context.Exercises == null)
			{
				return NotFound();
			}
			return await _context.Exercises.ToListAsync();
		}

		// GET: api/ExerciseModels/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ExerciseModel>> GetExerciseModel(int id)
		{
			if (_context.Exercises == null)
			{
				return NotFound();
			}
			var exerciseModel = await _context.Exercises.FindAsync(id);

			if (exerciseModel == null)
			{
				return NotFound();
			}

			return exerciseModel;
		}

		// PUT: api/ExerciseModels/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutExerciseModel(int id, ExerciseModel exerciseModel)
		{
			if (id != exerciseModel.ExerciseId)
			{
				return BadRequest();
			}

			_context.Entry(exerciseModel).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ExerciseModelExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/ExerciseModels
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<ExerciseModel>> PostExerciseModel(ExerciseModel exerciseModel)
		{
			if (_context.Exercises == null)
			{
				return Problem("Entity set 'ExerciseTrackerContext.Exercises'  is null.");
			}
			_context.Exercises.Add(exerciseModel);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetExerciseModel), new { id = exerciseModel.ExerciseId }, exerciseModel);
		}

		// DELETE: api/ExerciseModels/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteExerciseModel(int id)
		{
			if (_context.Exercises == null)
			{
				return NotFound();
			}
			var exerciseModel = await _context.Exercises.FindAsync(id);
			if (exerciseModel == null)
			{
				return NotFound();
			}

			_context.Exercises.Remove(exerciseModel);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ExerciseModelExists(int id)
		{
			return (_context.Exercises?.Any(e => e.ExerciseId == id)).GetValueOrDefault();
		}
	}
}
