using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.FollowingModels
{
    public class FollowingAdd
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Id { get; set; }
    }
}
