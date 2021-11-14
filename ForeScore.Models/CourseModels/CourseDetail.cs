using ForeScore.Contracts;
using ForeScore.Data;
using ForeScore.Models.HoleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForeScore.Data.Course;

namespace ForeScore.Models.CourseModels
{
    public class CourseDetail
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public float? Slope { get; set; }
        public float? Rating { get; set; }
        public int? Par { get; set; }
        public List<Hole> FrontNine { get; set; }
        public List<Hole> BackNine { get; set; }
        public List<Hole> Holes { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

      
        [DisplayName("State")]
        public State StateOfResidence { get; set; }

        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Url]
        [DisplayName("Website")]
        public string Website { get; set; }
    }
}
