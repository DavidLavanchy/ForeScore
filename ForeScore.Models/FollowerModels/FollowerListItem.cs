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
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public int FollowerId { get; set; }
        public string Id { get; set; }
    }
}
