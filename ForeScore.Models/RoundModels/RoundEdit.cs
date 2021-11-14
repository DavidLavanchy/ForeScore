using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.RoundModels
{
    public class RoundEdit
    {
        [Required]
        public int RoundId { get; set; }
        public CourseDetail CourseDetail { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsFeatured { get; set; }
        public DateTimeOffset? DateOfRound { get; set; }
        public List<HoleDataEdit> HoleData { get; set; }
        public List<HoleDataEdit> FrontNine { get; set; }
        public List<HoleDataEdit> BackNine { get; set; }
    }
}
