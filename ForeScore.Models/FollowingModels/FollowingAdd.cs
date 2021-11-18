using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [DisplayName("Who To Follow")]
        public List<WhoToFollowListItem> WhoToFollow { get; set; }
    }
}
