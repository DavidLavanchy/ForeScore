using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.LikeModels
{
    public class LikeEdit
    {
        [Required]
        public int LikeId { get; set; }
    }
}
