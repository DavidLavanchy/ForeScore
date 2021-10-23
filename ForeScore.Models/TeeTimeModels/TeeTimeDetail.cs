using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.TeeTimeModels
{
    public class TeeTimeDetail
    {
        public int CourseId { get; set; }
        public DateTimeOffset DateOfTeeTime{ get; set; }
    }
}
