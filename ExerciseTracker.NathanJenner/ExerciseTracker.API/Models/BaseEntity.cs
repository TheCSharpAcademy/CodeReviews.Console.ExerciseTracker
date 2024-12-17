using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExerciseTracker.API.Models;

public abstract class BaseEntity
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
}
