using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.HoleModels
{
    public class HoleEdit
    {
        [Required]
        public int HoleId { get; set; }
        public int HoleNumber { get; set; }
        public int Par { get; set; }
        public int Distance { get; set; }
    }
}
