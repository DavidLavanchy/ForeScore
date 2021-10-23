using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.RoundModels
{
    public class RoundCreateModel
    {
        [Required]
        public int CourseId { get; set; }
        public string Description { get; set; }
        [Required]
        public int Score { get; set; }
        public Hole MyProperty { get; set; }
    }
}
