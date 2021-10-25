using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.FollowerModels
{
    public class FollowerListItem
    {
        [Required]
        public string Email { get; set; }
    }
}
