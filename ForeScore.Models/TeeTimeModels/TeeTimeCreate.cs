using System;
using System.Collections.Generic;
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
        public DateTimeOffset DateOfTeeTime { get; set; }
        public string CourseName { get; set; }

        public TeeTimeCreate(){}
    }
}
