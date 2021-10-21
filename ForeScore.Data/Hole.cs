using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Hole
    {
        [Key]
        public int HoleId { get; set; }
        public int Par { get; set; }
        public int Distance { get; set; }
        public int Score { get; set; }
        public float DrivingDistance { get; set; }
        public int Putts { get; set; }
        public bool Penalty { get; set; }
        public bool FairwayHit { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
