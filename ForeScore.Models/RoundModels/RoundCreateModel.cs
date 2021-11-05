using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ForeScore.Models.RoundModels
{
    public class RoundCreateModel
    {
        public RoundCreateModel(){}
        public CourseDetail CourseDetail { get; set; }
        public int RoundId { get; set; }
        [Required]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsFeatured { get; set; }
        public DateTimeOffset? DateOfRound { get; set; }
        [Range(9, 18)]
        public List<HoleDataCreate> HoleData { get; set; }
    }
}
