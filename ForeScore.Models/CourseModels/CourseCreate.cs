using ForeScore.Contracts;
using ForeScore.Data;
using ForeScore.Models.HoleModels;
using ForeScore.Models.ViewModels;
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
    public class CourseCreate 
    {
        public CourseCreate(){}

        [Required]
        public string Name { get; set; }
        [Required]
        public float? Slope { get; set; }
        [Required]
        public float? Rating { get; set; }
        [Required]
        [Range(69,74)]
        public int? Par { get; set; }
        public List<HoleCreateViewModel> Holes { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        [Required]
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
