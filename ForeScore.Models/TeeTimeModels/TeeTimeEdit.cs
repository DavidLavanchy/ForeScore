using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.TeeTimeModels
{
    public class TeeTimeEdit
    {
        [Required]
        public int TeeTimeId { get; set; }
        public int CourseId { get; set; }
        public DateTimeOffset DateOfTeeTime { get; set; }
    }
}
