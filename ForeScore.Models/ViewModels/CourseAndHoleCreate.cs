using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.ViewModels
{
    public class CourseAndHoleCreate
    {
        public CourseCreate CourseCreateModel { get; set; }
        public List<HoleCreateViewModel> HoleCreateViewModels { get; set; }
    }
}
