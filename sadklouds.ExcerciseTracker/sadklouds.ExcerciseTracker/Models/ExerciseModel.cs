using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sadklouds.ExcerciseTracker.Models
{
    public class ExerciseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        [MaxLength(255)]
        public string? Comments { get; set; }
    }
}
