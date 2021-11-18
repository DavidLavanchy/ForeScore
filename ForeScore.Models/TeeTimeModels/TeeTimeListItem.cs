using ForeScore.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.TeeTimeModels
{
    public class TeeTimeListItem
    {
        public int CourseId { get; set; }
        [DisplayName("Date of Tee Time")]
        public DateTimeOffset? DateOfTeeTime { get; set; }
        public CourseDetail CourseDetail { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public int TeeTimeId { get; set; }
    }
}
