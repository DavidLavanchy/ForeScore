using ForeScore.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.CourseModels
{
    public class CourseListItem : ContactInformation
    {
        public string Name { get; set; }
        public float Slope { get; set; }
        public float Rating { get; set; }
        public int Par { get; set; }

    }
}
