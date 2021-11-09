using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.FollowingModels
{
    public class FollowingListItem
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public int FollowingId { get; set; }
    }
}
