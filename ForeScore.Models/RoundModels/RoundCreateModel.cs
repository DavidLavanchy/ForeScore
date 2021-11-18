﻿using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public string Description { get; set; }
        [DisplayName("Is Public")]
        public bool? IsPublic { get; set; }
        [DisplayName("Is Featured")]
        public bool? IsFeatured { get; set; }
        [DisplayName("Date of Round")]
        public DateTimeOffset? DateOfRound { get; set; }
        public List<HoleDataCreate> FrontNine { get; set; }
        public List<HoleDataCreate> BackNine { get; set; }
    }
}
