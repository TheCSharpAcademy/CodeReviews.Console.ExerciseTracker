using ExerciseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciseTrackerAPI.Controllers;
public interface IExerciseTrackerController
{
    Task<List<Weight>> GetWeights();
    Task<Weight?> GetWeightById(int id);
    Task<Weight> AddWeight(Weight weight);
    Task<Weight?> UpdateWeight(int id, Weight weight);
    Task<Weight?> DeleteWeight(int id);
}