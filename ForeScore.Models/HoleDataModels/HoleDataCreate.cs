using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.HoleDataModels
{
    public class HoleDataCreate
    {
        [Required]
        public int? Score { get; set; }
        public int? DrivingDistance { get; set; }
        public int? HolePar { get; set; }
        public int? Putts { get; set; }
        public bool? Penalty { get; set; }
        public bool? FairwayHit { get; set; }
        [Required]
        public int HoleNumber { get; set; }
        public int RoundId { get; set; }
    }
}
