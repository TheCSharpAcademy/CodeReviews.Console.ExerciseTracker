using ExerciseTracker.API.Models;
using ExerciseTracker.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController(IGenericRepository<Exercise> exerciseRepository) : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public async Task<List<Exercise>> GetAll()
        {
            return await exerciseRepository.GetAllAsync();
        }

        [HttpPost]
        [Route("add")]
        public async Task Add(Exercise entity)
        {
            await exerciseRepository.AddAsync(entity);
        }

        [HttpPatch]
        [Route("update")]
        public async Task Update(Exercise entity)
        {
            await exerciseRepository.UpdateAsync(entity);
        }
    }
}
