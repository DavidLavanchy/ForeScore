using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class HoleData
    {
        [Key]
        public int HoleDataId { get; set; }
        public int? HolePar { get; set; }
        public int HoleNumber { get; set; }
        public int? Score { get; set; }
        public int? DrivingDistance { get; set; }
        public int? Putts { get; set; }
        public bool? Penalty { get; set; }
        public bool? FairwayHit { get; set; }
        [Required]
        [ForeignKey(nameof(Round))]
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }
    }
}
