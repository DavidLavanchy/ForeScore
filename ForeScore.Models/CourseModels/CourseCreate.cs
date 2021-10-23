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
        public string Name { get; set; }
        public float Slope { get; set; }
        public float Rating { get; set; }
        [Range(69,74)]
        public int Par { get; set; }
        [Range(9,18)]
        public List<Hole> Holes { get; set; }
    }
}
