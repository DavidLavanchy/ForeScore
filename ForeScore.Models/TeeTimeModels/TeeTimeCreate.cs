using ForeScore.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.TeeTimeModels
{
    public class TeeTimeCreate
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Date of Tee Time")]
        public DateTimeOffset? DateOfTeeTime { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public CourseDetail CourseDetail { get; set; }
        public TeeTimeCreate(){}
    }
}
