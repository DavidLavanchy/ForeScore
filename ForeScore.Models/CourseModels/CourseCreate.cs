using ForeScore.Contracts;
using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.CourseModels
{
    public class CourseCreate : ContactInformation
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Slope { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        [Range(69,74)]
        public int Par { get; set; }
        [Required]
        [Range(9,18)]
        public List<Hole> Holes { get; set; }
    }
}
