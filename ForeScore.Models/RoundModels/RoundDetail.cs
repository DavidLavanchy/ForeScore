using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.RoundModels
{
    public class RoundDetail
    {
        public int RoundId { get; set; }
        public CourseDetail CourseDetail { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public string Description { get; set; }
        public int? Score { get; set; }
        [DisplayName("Is Public")]
        public bool? IsPublic { get; set; }
        [DisplayName("Is Featured")]
        public bool? IsFeatured { get; set; }
        [DisplayName("Date of Round")]
        public DateTimeOffset? DateOfRound { get; set; }
        public List<HoleData> HoleData { get; set; }
        public List<HoleData> FrontNine { get; set; }
        public List<HoleData> BackNine { get; set; }
    }
}
