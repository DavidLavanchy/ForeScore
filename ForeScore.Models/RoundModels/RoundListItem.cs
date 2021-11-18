using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.RoundModels
{
    public class RoundListItem
    {
        [Required]
        public int RoundId { get; set; }
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
    }
}
