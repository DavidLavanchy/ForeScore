using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.FollowerModels
{
    public class FollowerCreate
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Id { get; set; }
        public string FullName { get; set; }
    }
}
