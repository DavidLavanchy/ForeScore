using ForeScore.Models.FollowerModels;
using ForeScore.Models.FollowingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.ViewModels
{
    public class FollowViewModel
    {
        public IEnumerable<FollowingListItem> Following { get; set; }

        public IEnumerable<FollowerListItem> Followers { get; set; }
    }
}
