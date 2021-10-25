using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.RoundModels
{
    public class RoundDetail
    {
        public int CourseId { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFeatured { get; set; }
        public DateTimeOffset DateOfRound { get; set; }
        public List<HoleData> HoleData { get; set; }
    }
}
