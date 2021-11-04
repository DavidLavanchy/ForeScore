using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.ViewModels
{
    public class HoleCreateViewModel
    {
        public int HoleNumber { get; set; }
        [Required]
        public int Par { get; set; }
        [Required]
        public int Distance { get; set; }
    }
}
